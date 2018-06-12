using IntegralMallAPI.Common;
using IntegralMallAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IntegralMallAPI.Controllers
{
    public class OrderController : ApiController
    {
        private IntegralMallContext db = new IntegralMallContext();
        private SqlHelper dataContext = new SqlHelper();

        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddOrder(dynamic requestData)
        {
            try
            {
                string query = JsonConvert.SerializeObject(requestData);
                RequestOrderInfo orderInfo = JsonConvert.DeserializeObject<RequestOrderInfo>(query);

                #region 下单判断库存部分
                if (orderInfo.OrderType != 2)
                {
                    foreach (var item in orderInfo.OrderDetaile)
                    {
                        var sql = string.Format("Select Stock from SKU Where SkuId = {0}", item.SkuId);
                        var q = dataContext.ExecuteScalar(CommandType.Text, sql);

                        if ((int)q < item.Count)
                        {
                            return "Stock is not enough";
                        }
                    }
                } 
                #endregion

                //操作订单积分
                string integralSql = string.Format("update RegistMember Set LeaveIntegral = LeaveIntegral - {0} where MemberId = {1}", orderInfo.OrderPrice, orderInfo.MemberId);
                int nums = dataContext.ExecuteNonQuery(CommandType.Text, integralSql);

                if (nums > 0)
                {
                    #region 订单新增部分
                    MemberOrder order = new MemberOrder();
                    order.MemberId = orderInfo.MemberId;
                    order.OrderName = orderInfo.OrderName;
                    order.OrderTelephone = orderInfo.OrderTelephone;
                    order.OrderState = orderInfo.OrderState;
                    order.OrderAddress = orderInfo.OrderAddress;
                    order.OrderPrice = orderInfo.OrderPrice;
                    order.OrderType = orderInfo.OrderType;
                    order.InventedType = orderInfo.InventedType;
                    order.LogisticsNo = "";
                    order.LogisticsType = "";
                    order.OrderFrom = orderInfo.OrderFrom;
                    order.OrderRemark = orderInfo.OrderRemark;
                    order.AddDate = DateTime.Now;

                    db.Order.Add(order);
                    db.SaveChanges();
                    #endregion

                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string remark = "积分商城:" + order.OrderId;
                    //记录积分操作日志
                    string logsql = string.Format("insert into MemberIntegralDetail values({0},{1},'{2}',2,'积分商城','{2}','{3}','','');", order.MemberId, order.OrderPrice, date, remark);
                    dataContext.ExecuteNonQuery(CommandType.Text, logsql);

                    #region 新增订单商品
                    //新增完订单获取到订单ID然后录入订单商品
                    foreach (var item in orderInfo.OrderDetaile)
                    {
                        string sql = string.Format("Insert into OrderDetaile Values({0},{1},'{2}',{3},{4})", order.OrderId, item.SkuId, item.SkuName, item.ProductId, item.Count);

                        var count = dataContext.ExecuteNonQuery(CommandType.Text, sql);

                        string stockSql = string.Format("Update SKU Set Stock = Stock - {0} Where SkuId = {1}", item.Count, item.SkuId);
                        dataContext.ExecuteNonQuery(CommandType.Text, stockSql);
                    }
                    #endregion

                    //虚拟商品订单-欧飞充值
                    if (order.OrderType == 2)
                    {
                        int id = orderInfo.OrderDetaile[0].SkuId;
                        int skuNum = orderInfo.OrderDetaile[0].Count;
                        SKU sku = (from s in db.SKU
                                   where s.SkuId == id
                                   select s).FirstOrDefault();
                        int price = Convert.ToInt32(sku.MarketPrice);

                        if (!string.IsNullOrEmpty(order.OrderTelephone))
                        {
                            for (int i = 0; i < skuNum; i++)
                            {
                                LogHelper.WriteLog("共" + skuNum + "件商品，充值电话：" + order.OrderTelephone + "，充值的面值：" + price);
                                InventedManage(order.InventedType, order.OrderTelephone, i.ToString(), order.OrderId.ToString(), price);
                            }
                        }
                    }
                    return order.OrderId.ToString();
                }
                else
                {
                    return "Integral is not enough";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateOrderState(dynamic requestData)
        {
            try
            {
                int orderId = requestData.OrderId;
                string state = requestData.State;

                if (orderId > 0 && !string.IsNullOrEmpty(state))
                {
                    string sql = string.Format("Update MemberOrder Set OrderState = '{0}' Where OrderId = {1}", state, orderId);
                    var count = dataContext.ExecuteNonQuery(CommandType.Text, sql);

                    return "Excute Success";
                }
                else
                {
                    return "Excute Error";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// 积分抽奖回写订单
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string LuckyOrderSubmit(dynamic requestData)
        {
            try
            {
                int orderId = requestData.OrderId;
                int skuId = requestData.skuId;
                string state = requestData.State;
                string telephone = requestData.Telephone;

                if (orderId > 0 && !string.IsNullOrEmpty(state))
                {
                    SKU sku = (from s in db.SKU
                               where s.SkuId == skuId
                               select s).FirstOrDefault();
                    int price = Convert.ToInt32(sku.MarketPrice);

                    string sql = string.Format("Update MemberOrder Set OrderState = '{0}',OrderTelephone = '{2}'  Where OrderId = {1}", state, orderId, telephone);
                    var count = dataContext.ExecuteNonQuery(CommandType.Text, sql);
                    InventedManage(1, telephone, "0", orderId.ToString(), price);
                    return "Excute Success";
                }
                else
                {
                    return "Excute Error";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 家味修改订单
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public int HomeLuckyOrderSubmit(dynamic requestData)
        {
            int orderId = requestData.OrderId;
            string address = requestData.Address;
            string state = requestData.State;
            string orderName = requestData.OrderName;
            string telephone = requestData.Telephone;

            string sql = string.Format("Update MemberOrder Set OrderState = '{0}',OrderAddress = '{2}', OrderName = '{3}', OrderTelephone = '{4}'  Where OrderId = {1}", state, orderId, address, orderName, telephone);
            var count = dataContext.ExecuteNonQuery(CommandType.Text, sql);

            return count;
        }

        /// <summary>
        /// 取消订单回滚函数
        /// </summary>
        /// <param name="requestData"></param>
        [HttpPost]
        public void CallBack(dynamic requestData)
        {
            int orderId = requestData.OrderId;             int memberId = requestData.MemberId;            int integral = requestData.Integral;

            List<OrderDetaile> orderList = (from o in db.OrderDetaile
                                            where o.OrderId == orderId
                                            select o).ToList<OrderDetaile>();

            string integralSql = string.Format("update RegistMember Set LeaveIntegral = LeaveIntegral + {0} where MemberId = {1}", integral, memberId);
            dataContext.ExecuteNonQuery(CommandType.Text, integralSql);

            foreach (var item in orderList)
            {
                string stockSql = string.Format("Update SKU Set Stock = Stock + {0} Where SkuId = {1}", item.Count, item.SkuId);
                dataContext.ExecuteNonQuery(CommandType.Text, stockSql);
            }
        }

        /// <summary>
        /// 微信端获取订单列表
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <returns></returns>
        [HttpGet]
        public string GetMemberOrderList(int memberId = 0)
        {
            if (memberId > 0)
            {
                //string sql = string.Format("Select * from MemberOrder as mo inner join OrderDetaile as od on od.OrderId = mo.OrderId Where mo.MemberId = {0}", memberId);

                var sql = SqlParamHelper.Builder
                    .Append("Select od.*, mo.*,p.ImgUrl,s.Price from MemberOrder as mo ")
                    .Append("left join OrderDetaile as od on od.OrderId = mo.OrderId")
                    .Append("left join Product as p on p.ProductId = od.ProductId")
                    .Append("left join SKU as s on s.SkuId = od.SkuId")
                    .Append("Where mo.MemberId = " + memberId + "");

                var q = dataContext.ExecuteDataTable(CommandType.Text, sql.SQL);

                return JsonConvert.SerializeObject(q);
            }

            return "Excute Error";
        }


        /// <summary>
        /// 获取订单列表页
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetOrderList(dynamic requestData)
        {
            try
            {
                string startTime = requestData.StartTime;
                string endTime = requestData.EndTime;
                string orderState = requestData.OrderState;
                string orderTelephone = requestData.OrderTelephone;
                string orderName = requestData.OrderName; 
                string orderId = requestData.OrderId;
                int orderType = requestData.OrderType;
                int memberId = requestData.MemberId;

                int beginPage = (requestData.IndexPage - 1) * requestData.PageSize + 1;
                int endPage = requestData.IndexPage * requestData.PageSize;

                var sql = SqlParamHelper.Builder
                    .Append("Select o.*, ROW_NUMBER() over(order by o.OrderId desc) as num from MemberOrder as o");

                if (!string.IsNullOrEmpty(orderId))
                {
                    sql.Where(" o.OrderId = '" + orderId + "'");
                }
                if (orderState != "全部")
                {
                    sql.Where(" o.OrderState = '" + orderState + "'");
                }
                if (!string.IsNullOrEmpty(orderTelephone))
                {
                    sql.Where(" o.OrderTelephone = '" + orderTelephone + "'");
                }
                if (!string.IsNullOrEmpty(orderName))
                {
                    sql.Where(" o.OrderName like '%" + orderName + "%'");
                }
                if (orderType > 0)
                {
                    sql.Where(" o.OrderType = " + orderType + "");
                }
                if (!string.IsNullOrEmpty(startTime))
                {
                    sql.Where(" o.AddDate BETWEEN  '" + startTime + "' And '" + endTime + "'");
                }
                if (memberId > 0)
                {
                    sql.Where(" o.MemberId = "+ memberId +"");
                }
                var pageSql = SqlParamHelper.Builder
                    .Append("select * from (" + sql.SQL + ") as memberOrder")
                    .Append("where memberOrder.num >= " + beginPage + " and memberOrder.num <= " + endPage + "");

                var q = dataContext.ExecuteDataTable(CommandType.Text, pageSql.SQL, sql.Arguments);

                //计算分页
                var countSql = string.Format("select Count(*) from(" + sql.SQL + ")as orderCount");
                var Count = dataContext.ExecuteScalar(CommandType.Text, countSql);

                return "{ \"Count\":\"" + Count + "\",\"data\":" + JsonConvert.SerializeObject(q) + "}";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        /// <summary>
        /// 积分抽奖滚动展示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetIntegrakDrawList()
        {
            string sql = string.Format("Select top 30 m.MemberId, o.SkuName from MemberOrder as m inner join OrderDetaile as o on m.OrderId = o.OrderId where OrderFrom = '积分抽奖' order by m.OrderId desc");
            var result = dataContext.ExecuteDataTable(CommandType.Text, sql);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetOrderInfo(int orderId = 0)
        {
            if (orderId > 0)
            {
                string sql = string.Format("Select o.*, r.MemberName from MemberOrder as o inner join RegistMember as r on r.MemberId = o.MemberId Where o.OrderId = {0}", orderId);
                var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
                return JsonConvert.SerializeObject(q);
            }
            else
            {
                return "Excute Error";
            }
        }

        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public int SendLogistics(dynamic requestData)
        {
            int orderId = requestData.OrderId;
            string logisticsNo = requestData.LogisticsNo;
            string logisticsType = requestData.LogisticsType;

            if (!string.IsNullOrEmpty(logisticsNo) && orderId > 0)
            {
                string sql = string.Format("Update MemberOrder Set LogisticsNo = '{0}', LogisticsType = '{1}', OrderState = '已发货' where OrderId = {2}", logisticsNo, logisticsType, orderId);
                var a = dataContext.ExecuteNonQuery(CommandType.Text, sql);
                return a;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取订单SKU
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetOrderSKU(int orderId = 0)
        {
            if (orderId > 0)
            {
                string sql = string.Format("Select o.*, s.SkuCode from OrderDetaile as o Inner Join SKU as s on o.SkuId = s.SkuId Where o.OrderId = {0}", orderId);
                var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
                return JsonConvert.SerializeObject(q);
            }
            else
            {
                return "Excute Error";
            }

        }

        /// <summary>
        /// 虚拟接口操作方法
        /// </summary>
        /// <param name="invented">接口类型</param>
        /// <param name="telephone">手机号</param>
        /// <param name="orderId">订单ID</param>
        /// <param name="price">价格</param>
        private void InventedManage(int invented, string telephone, string count, string orderId, int price)
        {

            TopupModel topupobj = new TopupModel() 
            {
                OrderId = orderId,
                ExtendInfo = orderId +"-"+ count,
                PaymentType = invented,
                Account = telephone,
                CardTel = telephone,
                CardNum = "1",
                Value = price.ToString()
            };
            //LogHelper.WriteLog(topupobj.CardNum);

            //欧飞充值卡
            if (invented == 1)
            {
                var item = TopupFactory.topupOfpay(topupobj);
                LogHelper.WriteLog(item.retcode + "|" + item.err_msg);
            }
        }

        /// <summary>
        /// 修改订单备注
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateRemark(dynamic requestData)
        {
            int orderId = requestData.OrderId;
            string remark = requestData.Remark;

            if (orderId > 0)
            {
                string sql = string.Format("Update MemberOrder Set OrderRemark = '{0}' Where OrderId = {1}", remark, orderId);
                int q = dataContext.ExecuteNonQuery(CommandType.Text, sql);
                return q;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取订单物流信息
        /// </summary>
        /// <param name="code">物流类型</param>
        /// <param name="postId">物流编号</param>
        /// <returns></returns>
        [HttpGet]
        public string GetLogisticsInfo(string code, string postId)
        {
            var q = kuaidi100.GetInfo(code, postId);
            PostalDeliveryViewModel model = JsonConvert.DeserializeObject<PostalDeliveryViewModel>(q);
            return JsonConvert.SerializeObject(model);

        }

        /// <summary>
        /// 导入物流信息
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string ImprotLogistics(dynamic requestData)
        {
            try
            {
                string q = JsonConvert.SerializeObject(requestData.List);
                List<RequestLogisitics> list = JsonConvert.DeserializeObject<List<RequestLogisitics>>(q);

                string sql = string.Empty;
                foreach (var item in list)
                {
                    sql = string.Format("Update MemberOrder Set LogisticsNo = '{0}', LogisticsType = '{1}',OrderState = '已发货' Where OrderId = {2}", item.LogisiticsNo, item.LogisiticsType, item.OrderId);
                    dataContext.ExecuteNonQuery(CommandType.Text, sql);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Excute Success";
        }

        /// <summary>
        /// 验证会员活动期间够买次数
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string CheckMemberSale(dynamic requestData)
        {
            int memberId = requestData.MemberId;
            int skuId = requestData.SkuId;

            if (skuId <= 0)
            {
                return "-1";
            }

            //if (skuId == 1043)
            //{
            //    string chsql = string.Format("Select COUNT(*) From TempAuthSKU Where MemberId = {0}", memberId);
            //    var q = dataContext.ExecuteScalar(CommandType.Text, chsql);
            //    if ((int)q > 0)
            //    {
            //        return "-1";
            //    }

            //    var scansql = SqlParamHelper.Builder
            //        .Append("Select COUNT(*) from MemberIntegralDetail as mid")
            //        .Append("left join RegistMember as r on r.MemberId = mid.MemberId")
            //        .Append("where IntegralSource like '%扫描%' and mid.Remark like '%黄豆%'and mid.MemberId = "+ memberId +"");

            //    var count = dataContext.ExecuteScalar(CommandType.Text, scansql.SQL);
            //    if ((int)count > 0)
            //    {
            //        return "-1";
            //    }
            //}

            var sql = SqlParamHelper.Builder
                .Append("select SUM(d.[Count]) from MemberOrder as o")
                .Append("left join OrderDetaile as d on o.OrderId = d.OrderId")
                .Append("left join SaleActivity as s on d.SkuId = s.SkuId")
                .Append("where MemberId = "+ memberId +" and (GETDATE() Between s.StartTime and s.EndTime) and s.SkuId = " + skuId + "");

            var a = dataContext.ExecuteScalar(CommandType.Text, sql.SQL);

            return a.ToString();
        }

    }
}
