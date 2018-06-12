using CreditUserAPI.Common;
using CreditUserAPI.Models;
using CreditUserAPI.WeiXin;
using CreditUserAPI.WeiXin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CreditUserAPI.Controllers
{
    /// <summary>
    /// 厨师部分API
    /// </summary>
    public class MemberController : ApiController
    {
        private CreditContext db = new CreditContext();
        private SqlHelper dataContext = new SqlHelper();

        #region 会员注册部分
        /// <summary>
        /// 会员注册部分
        /// </summary>
        /// <param name="requestData">注册会员字段</param>
        /// <returns>返回新增的会员ID</returns>
        [HttpPost]
        public string CreateMember(dynamic requestData)
        {
            RegistMember member = new RegistMember();
            OpenIdAssociated openbase = new OpenIdAssociated();
            LogHelper.WriteLog("进入方法");
            try
            {
                int code = -1;
                //获取用户填写的注册码

                code = Convert.ToInt32(requestData.RegistCode);

                //判断是否为游客
                if (code > 0)
                {
                    //判定为会员根据注册码查询出队员ID 
                    var salmanSql = string.Format("Select SalemanId from RegistCode Where RegistCodeId = {0}", code);
                    var salemanId = dataContext.ExecuteScalar(CommandType.Text, salmanSql);

                    LogHelper.WriteLog("Code:" + code);
                    LogHelper.WriteLog("SalemanId:" + salemanId);

                    #region 坑爹的会员赋值部分……
                    member.ProvinceId = requestData.ProvinceId;
                    member.ProvinceName = requestData.ProvinceName;
                    member.CityId = requestData.CityId;
                    member.CityName = requestData.CityName;
                    member.AreaId = requestData.AreaId;
                    member.AreaName = requestData.AreaName;
                    member.ImgUrl = "";
                    member.MemberName = requestData.MemberName;
                    member.MemberTelePhone = requestData.TelePhone;
                    member.RecommendId = Convert.ToInt32(salemanId);
                    member.Position = requestData.Position;
                    member.PositionType = requestData.PositionType;
                    member.HotelName = requestData.HotelName;
                    member.MemberState = 1;
                    member.HotelCode = "";
                    member.HotelAddress = "";
                    member.UpdateId = 0;
                    member.RegistDate = DateTime.Now;
                    member.UpdateDate = DateTime.Now;
                    member.TotalIntegral = 0;
                    member.LeaveIntegral = 0;
                    member.MemberCode = "";
                    member.MemberCodeTime = null;
                    member.Remark = requestData.Remark;
                    member.RoleId = null;
                    member.MemberRecId = requestData.MemberRecId;
                    member.IsEnable = 0;
                    #endregion

                    if (string.IsNullOrEmpty(member.AreaName))
                    {
                        return "-1";
                    }
                        
                    db.Member.Add(member);
                    db.SaveChanges();

                    string useCodeSql = string.Format("Update RegistCode Set MemberId = {0}, RegistCodeState = 2, UseDate = '{2}' where RegistCodeId = {1}; Insert into MemberRef Values({0}, {3},'{2}');", member.MemberId, code, DateTime.Now, salemanId);
                    dataContext.ExecuteNonQuery(CommandType.Text, useCodeSql);
                }
                else
                {
                    //判定为游客，直接赋值且RecommendId为0
                    #region 坑爹的会员赋值部分……
                    member.ProvinceId = requestData.ProvinceId;
                    member.ProvinceName = requestData.ProvinceName;
                    member.CityId = requestData.CityId;
                    member.CityName = requestData.CityName;
                    member.AreaId = requestData.AreaId;
                    member.AreaName = requestData.AreaName;
                    member.ImgUrl = "";
                    member.MemberName = requestData.MemberName;
                    member.MemberTelePhone = requestData.TelePhone;
                    member.RecommendId = 0;
                    member.Position = requestData.Position;
                    member.PositionType = requestData.PositionType;
                    member.HotelName = requestData.HotelName;
                    member.MemberState = 1;
                    member.HotelCode = "";
                    member.HotelAddress = "";
                    member.UpdateId = 0;
                    member.RegistDate = DateTime.Now;
                    member.UpdateDate = DateTime.Now;
                    member.TotalIntegral = 0;
                    member.LeaveIntegral = 0;
                    member.MemberCode = "";
                    member.MemberCodeTime = null;
                    member.Remark = requestData.Remark; ;
                    member.RoleId = null;
                    member.MemberRecId = requestData.MemberRecId;
                    member.IsEnable = 0;
                    #endregion

                    db.Member.Add(member);
                    db.SaveChanges();
                }

                #region 存入用户OpenId
                if (requestData.OpenId != null)
                {
                    openbase.OpenId = requestData.OpenId;
                    openbase.UserId = member.MemberId;
                    openbase.UserType = 2;
                    openbase.Nickname = requestData.Nickname;
                    openbase.HeadImgUrl = requestData.HeadImgUrl;
                    openbase.CreateDate = DateTime.Now;

                    db.OpenIdAssociated.Add(openbase);
                    db.SaveChanges();
                } 
                #endregion

                #region 会员资料
                //当新增完会员之后 在会员简历表里同步新增一条数据
                var sql = string.Format("INSERT INTO MemberProfile VALUES ({0},'','','',NULL,NULL,NULL,'',NULL,'',NULL,'',NULL,'','','','','','',NULL,'','','','','','','',NULL,'','','','',NULL,'','','','','','','','','','')", member.MemberId);
                dataContext.ExecuteNonQuery(CommandType.Text, sql);

                #endregion

                //如若有推荐用户注册，则推送模板消息
                if (member.MemberRecId > 0)
                {
                    
                    string openIdsql = string.Format("Select OpenId from OpenIdAssociated where UserId = {0} and UserType = 2", member.MemberRecId);
                    var q = dataContext.ExecuteScalar(CommandType.Text, openIdsql);
                    SendWeChatMsg(member.MemberName, q.ToString());
                }
                
              
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Source + "|" + ex.Message + "|" + ex.TargetSite);
                return ex.Source + ex.Message + ex.TargetSite;
            }
            return member.MemberId.ToString();

        } 
        #endregion

        /// <summary>
        /// 游客注册 04-10
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string CreateVisitor(dynamic requestData)
        {
            string telephone = requestData.Phone;
            string openid = requestData.OpenId;
            if (string.IsNullOrEmpty(telephone) || string.IsNullOrEmpty(openid))
            {
                return "request error";
            }

            try
            {
                RegistMember member = new RegistMember();
                member.MemberTelePhone = telephone;
                member.MemberState = 1;
                member.RegistDate = DateTime.Now;
                member.TotalIntegral = 0;
                member.LeaveIntegral = 0;
                member.IsEnable = 0;

                db.Member.Add(member);
                db.SaveChanges();

                #region 存入用户OpenId
                OpenIdAssociated openbase = new OpenIdAssociated();
                if (requestData.OpenId != null)
                {
                    openbase.OpenId = requestData.OpenId;
                    openbase.UserId = member.MemberId;
                    openbase.UserType = 2;
                    openbase.Nickname = requestData.Nickname;
                    openbase.HeadImgUrl = requestData.HeadImgUrl;
                    openbase.CreateDate = DateTime.Now;

                    db.OpenIdAssociated.Add(openbase);
                    db.SaveChanges();
                }
                #endregion

                #region 会员资料
                //当新增完会员之后 在会员简历表里同步新增一条数据
                var sql = string.Format("INSERT INTO MemberProfile VALUES ({0},'','','',NULL,NULL,NULL,'',NULL,'',NULL,'',NULL,'','','','','','',NULL,'','','','','','','',NULL,'','','','',NULL,'','','','','','','','','','')", member.MemberId);
                dataContext.ExecuteNonQuery(CommandType.Text, sql);

                #endregion

                return member.MemberId.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        #region 验证注册时的注册码是否合法
        /// <summary>
        /// 验证注册时的注册码是否合法
        /// </summary>
        /// <param name="requestData">注册码</param>
        /// <returns></returns>
        [HttpPost]
        public string CheckRegistCode(dynamic requestData)
        {
            var sql = string.Format("Select RegistCodeState from RegistCode Where RegistCodeId = {0}", requestData.RegistCode);
            var q = dataContext.ExecuteScalar(CommandType.Text, sql);
            if (q == null)
            {
                return "-1";
            }
            return q.ToString();
        } 
        #endregion

        #region 验证注册时的手机号是否合法
        /// <summary>
        /// 验证注册时的手机号是否合法
        /// </summary>
        /// <param name="requestData">手机号</param>
        /// <returns></returns>
        [HttpPost]
        public int CheckMemberTelephone(dynamic requestData)
        {
            var sql = string.Format("select COUNT(*) from RegistMember where MemberTelePhone = '{0}'", requestData.TelePhone);
            var q = dataContext.ExecuteScalar(CommandType.Text, sql);
            if (q == null)
            {
                return -1;
            }
            return q;
        } 
        #endregion

        #region 获取厨师简要信息
        /// <summary>
        /// 根据厨师ID获取厨师简要信息
        /// </summary>
        /// <param name="requestData">会员ID</param>
        /// <returns>返回会员信息（json）</returns>
        [HttpPost]
        public string GetMemberById(dynamic requestData)
        {
            //if (string.IsNullOrEmpty(requestData.MemberId))
            //{
            //    return "Request Parameter error";
            //}

            var sql = SqlParamHelper.Builder
                .Append("select r.*, rs.Name, rs.WorkNum, rs.Telephone, rs.RegionName, o.OpenId from RegistMember as r")
                .Append("left join RegistSaleMan as rs on r.RecommendId = rs.SalemanId")
                .Append("left join OpenIdAssociated as o on r.MemberId = o.UserId and o.UserType = 2")
                .Append("where r.MemberId = " + requestData.MemberId + "");

            var q = dataContext.ExecuteDataTable(CommandType.Text, sql.SQL);

            return JsonConvert.SerializeObject(q);
        } 
        #endregion

        #region 分页查询厨师
        /// <summary>
        /// 分页查询厨师
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetPageMember(dynamic requestData)
        {
            string query = JsonConvert.SerializeObject(requestData);
            RequestMemberData model = JsonConvert.DeserializeObject<RequestMemberData>(query);

            int beginPage = (model.IndexPage - 1) * model.PageSize + 1;
            int endPage = model.IndexPage * model.PageSize;

            var nestSql = SqlParamHelper.Builder
                .Append("select rm.*, ISNULL(mid.MemberActiveState,2) AS MemberActiveState, ROW_NUMBER() over(order by rm.MemberId desc) as num from RegistMember as rm")
                .Append("LEFT JOIN (SELECT m.MemberId,CASE WHEN DATEDIFF(DAY,MAX(m.CreatDate),GETDATE()) < 20 THEN 1 ELSE 2 END AS MemberActiveState FROM MemberIntegralDetail AS m GROUP BY m.MemberId) AS mid ON mid.MemberId = rm.MemberId");

            if (model.SalemanId > 0)
            {
                nestSql.Append(" inner join RegistCode as rc on rc.MemberId = rm.MemberId");
                nestSql.Where(" rc.SalemanId = " + model.SalemanId + "");
            }
            if (model.Identity == 1)
            {
                nestSql.Where(" rm.RecommendId = 0");
            }
            else if (model.Identity == 2)
            {
                nestSql.Where(" rm.RecommendId > 0");
            }
            if (model.CodeState == 1)
            {
                nestSql.Where(" rm.MemberCode is not null");
            }
            else if (model.CodeState == 0)
            {
                nestSql.Where(" rm.MemberCode is null or rm.MemberCode = ''");
            }
            if (!string.IsNullOrEmpty(model.SearchInfo))
            {
                nestSql.Where(" rm.HotelName like '%" + model.SearchInfo + "%' or rm.MemberName like '%" + model.SearchInfo + "%' or rm.MemberTelePhone like '%" + model.SearchInfo + "%'");
            }
            if (!string.IsNullOrEmpty(model.RegistBeginTime.ToString()) && !string.IsNullOrEmpty(model.RegistEndTime.ToString()))
            {
                nestSql.Where(" rm.RegistDate >= '" + model.RegistBeginTime + "' and rm.RegistDate <= '" + model.RegistEndTime + "'");
            }
            nestSql.Where(" rm.IsEnable = 0");
            var sql = SqlParamHelper.Builder
                .Append("select * from (" + nestSql.SQL + ") as member")
                .Append("where member.num >= " + beginPage + " and member.num <= " + endPage + "");

            var q = dataContext.ExecuteDataTable(CommandType.Text, sql.SQL, sql.Arguments);

            #region 计算总页数
            var countSql = string.Format("select Count(*) from(" + nestSql.SQL + ")as memberCount");
            var count = dataContext.ExecuteScalar(CommandType.Text, countSql);

            //int row = Convert.ToInt32(count);
            //int pageCount = model.PageSize;
            //int sum = (row - 1) / pageCount + 1;//这样就计算好了页码数量，逢1进1   
            #endregion

            return "{ \"Count\":\"" + count + "\",\"data\":" + JsonConvert.SerializeObject(q) + "}";
        } 
        #endregion

        #region 根据队员ID获取厨师列表（此API暂不用）
        /// <summary>
        /// 根据队员ID获取厨师列表（此API暂不用）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetMemberListBySaleman(dynamic requestData)
        {
            string query = JsonConvert.SerializeObject(requestData);
            RequestMemberData model = JsonConvert.DeserializeObject<RequestMemberData>(query);

            int beginPage = (model.IndexPage - 1) * (model.PageSize + 1);
            int endPage = model.IndexPage * model.PageSize;

            if (model.SalemanId == 0)
            {
                return "request parameter error";
            }
            var nestSql = SqlParamHelper.Builder
                 .Append("select *, ROW_NUMBER() over(order by MemberId desc) as num from RegistMember as rm");

            if (model.Identity == 1)
            {
                nestSql.Where(" rm.MemberId not in (select MemberId from RegistCode)");
            }
            else if (model.Identity == 2)
            {
                nestSql.Where(" rm.MemberId in (select MemberId from RegistCode)");
            }
            if (!string.IsNullOrEmpty(model.SearchInfo))
            {
                nestSql.Where(" rm.HotelName like '%" + model.SearchInfo + "%' or rs.Name like '%" + model.SearchInfo + "%' or rs.Telephone like '%" + model.SearchInfo + "%'");
            }
            if (!string.IsNullOrEmpty(model.RegistBeginTime.ToString()) && !string.IsNullOrEmpty(model.RegistEndTime.ToString()))
            {
                nestSql.Where(" rm.RegistDate >= '" + model.RegistBeginTime + "' and rm.RegistDate <= '" + model.RegistEndTime + "'");
            }
            nestSql.Where(" rm.IsEnable = 0");
            var sql = SqlParamHelper.Builder
                .Append("select * from (" + nestSql.SQL + ") as memeber")
                .Append("where memeber.num >= " + beginPage + " and memeber.num <= " + endPage + "");

            var result = dataContext.ExecuteDataTable(CommandType.Text, sql.SQL);

            return JsonConvert.SerializeObject(result);
        } 
        #endregion

        #region 修改厨师信息
        /// <summary>
        /// 修改厨师信息
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateMember(dynamic requestData)
        {
            string query = JsonConvert.SerializeObject(requestData);
            RegistMember model = JsonConvert.DeserializeObject<RegistMember>(query);

            EntityState statebefore = db.Entry(model).State;
            db.Entry(model).State = EntityState.Modified;

            return db.SaveChanges();
        } 
        #endregion

        #region 批量审核厨师
        /// <summary>
        /// 批量审核厨师
        /// </summary>
        /// <param name="memberList"></param>
        /// <returns></returns>
        [HttpPost]
        public string ReviewMember(string[] memberList)
        {
            try
            {
                string sql = string.Empty;
                for (int i = 0; i < memberList.Length; i++)
                {
                    sql = string.Format("Update RegistMember Set MemberState = 1 Where MemberId = {0}", memberList[i]);
                    dataContext.ExecuteNonQuery(CommandType.Text, sql);
                }
            }
            catch (Exception ex)
            {

                return "Exc error";
            }

            return "Excute Success";
        } 
        #endregion

        #region 查询厨师履历
        /// <summary>
        /// 查询厨师履历
        /// </summary>
        /// <param name="requstData">厨师ID</param>
        /// <returns></returns>
        [HttpPost]
        public string GetMemberResume(dynamic requstData)
        {
            string sql = string.Format("Select * from MemberResume Where MemberId = {0}", requstData.MemberId);
            var result = dataContext.ExecuteDataTable(CommandType.Text, sql);
            return JsonConvert.SerializeObject(result);
        } 
        #endregion

        #region 微信端查询绑定厨师
        /// <summary>
        /// 微信端查询绑定厨师
        /// </summary>
        /// <param name="requestData">
        /// IndexPage,PageSize
        /// SalemanId:队员ID
        /// MemberState: 0-全部 1-未完善 2-已完善
        /// MemberName:会员名称
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public string GetMemberBySaleman(dynamic requestData)
        {
            try
            {
                string query = JsonConvert.SerializeObject(requestData);
                RequestMemberBySaleman model = JsonConvert.DeserializeObject<RequestMemberBySaleman>(query);

                int beginPage = (model.IndexPage - 1) * model.PageSize + 1;
                int endPage = model.IndexPage * model.PageSize;

                var nestSql = SqlParamHelper.Builder
                    .Append("select rm.*, ISNULL(mid.MemberActiveState,2) AS MemberActiveState, ROW_NUMBER() over(order by rm.MemberId desc) as num from RegistMember as rm")
                    .Append(" inner join RegistCode as rc on rc.MemberId = rm.MemberId")
                    .Append(" LEFT JOIN (SELECT m.MemberId,CASE WHEN DATEDIFF(DAY,MAX(m.CreatDate),GETDATE()) < 20 THEN 1 ELSE 2 END AS MemberActiveState ")
                    .Append(" FROM MemberIntegralDetail AS m GROUP BY m.MemberId) AS mid ON mid.MemberId = rm.MemberId");

                if (model.SalemanId > 0)
                {
                    nestSql.Where(" rc.SalemanId = " + model.SalemanId + "");
                }
                if (model.MemberState == 1)
                {
                    nestSql.Where(" rm.MemberCode is null");
                }
                if (model.MemberState == 2)
                {
                    nestSql.Where(" rm.MemberCode is not null");
                }
                if (!string.IsNullOrEmpty(model.MemberName))
                {
                    nestSql.Where(" rm.MemberName like '%" + model.MemberName + "%' or rm.HotelName like '%" + model.MemberName + "%'");
                }

                nestSql.Where(" rm.IsEnable = 0");

                var sql = SqlParamHelper.Builder
                    .Append("select * from (" + nestSql.SQL + ") as member")
                    .Append("where member.num >= " + beginPage + " and member.num <= " + endPage + "");

                if (model.ActiveOB == 1)
                {
                    sql.OrderBy(" MemberActiveState asc");
                }
                else if (model.ActiveOB == 2)
                {
                    sql.OrderBy(" MemberActiveState desc");
                }
                else if (model.IntegralOB == 1)
                {
                    sql.OrderBy(" member.LeaveIntegral asc");
                }
                else if (model.IntegralOB == 2)
                {
                    sql.OrderBy(" member.LeaveIntegral desc");
                }

                var q = dataContext.ExecuteDataTable(CommandType.Text, sql.SQL);

                #region 计算总页数
                var countSql = string.Format("select Count(*) from(" + nestSql.SQL + ")as memberCount");
                var count = dataContext.ExecuteScalar(CommandType.Text, countSql);
                #endregion

                return "{ \"Count\":\"" + count + "\",\"data\":" + JsonConvert.SerializeObject(q) + "}";
                //return sql.SQL + "||" + model.MemberState;
            }
            catch (Exception ex)
            {
                return ex.Message + "|" + ex.Source;
            }

        } 
        #endregion

        #region 操作会员积分
        /// <summary>
        /// 操作会员积分
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public string UpdateMemberIntegral(dynamic requestData)
        {
            string operation = requestData.Operation;
            int integral = requestData.Integral;
            int memberId = requestData.MemberId;
            string integralSource = requestData.IntegralSource;
            string remark = requestData.Remark;

            try
            {
                string sql = string.Empty;
                int count = 0;
                if (operation == "plus")
                {
                    sql = string.Format("update RegistMember Set LeaveIntegral = LeaveIntegral + {0}, TotalIntegral = TotalIntegral + {0} where MemberId = {1}", integral, memberId);
                    count = dataContext.ExecuteNonQuery(CommandType.Text, sql);

                    MemberIntegralDetail model = new MemberIntegralDetail();
                    model.CreatDate = DateTime.Now;
                    model.InvalidDate = DateTime.Now;
                    model.IntegralNum = integral;
                    model.IntegralSource = integralSource;
                    model.IntegralType = 1;
                    model.Remark = remark;
                    model.MemberId = memberId;
                    model.ScanHotelName = "";
                    model.ScanMemberCode = "";

                    db.MemberIntegralDetail.Add(model);
                    db.SaveChangesAsync();

                }
                else if (operation == "minus")
                {
                    sql = string.Format("update RegistMember Set LeaveIntegral = LeaveIntegral - {0} where MemberId = {1}", integral, memberId);
                    count = dataContext.ExecuteNonQuery(CommandType.Text, sql);

                    MemberIntegralDetail model = new MemberIntegralDetail();
                    model.CreatDate = DateTime.Now;
                    model.InvalidDate = DateTime.Now;
                    model.IntegralNum = integral;
                    model.IntegralSource = integralSource;
                    model.IntegralType = 2;
                    model.Remark = remark;
                    model.MemberId = memberId;
                    model.ScanHotelName = "";
                    model.ScanMemberCode = "";

                    db.MemberIntegralDetail.Add(model);
                    db.SaveChangesAsync();
                }

                return "Excute Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } 
        #endregion

        #region Excel批量转移认证厨师
        /// <summary>
        /// Excel批量转移认证厨师
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string TransferMemberList(dynamic requestData)
        {
            try
            {
                string q = JsonConvert.SerializeObject(requestData.List);
                List<TransferModel> model = JsonConvert.DeserializeObject<List<TransferModel>>(q);

                string sql = string.Empty;
                foreach (var item in model)
                {
                    if (item.OldSalemanId == 0)
                    {
                        sql = string.Format("insert into RegistCode Values({0},{1},2,getdate(),getdate());Update RegistMember Set RecommendId = {0} where MemberId = {1};Insert into MemberRef Values({1},{0},getdate());", item.NewSalemanId, item.MemberId);
                        dataContext.ExecuteNonQuery(CommandType.Text, sql);
                    }
                    else
                    {
                        sql = string.Format("Update RegistCode Set SalemanId = {0} Where MemberId = {1};Update RegistMember Set RecommendId = {0} where MemberId = {1};", item.NewSalemanId, item.MemberId);
                        dataContext.ExecuteNonQuery(CommandType.Text, sql);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Excute Success";
        } 
        #endregion

        #region 单个认证厨师
        /// <summary>
        /// 单个认证厨师
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public string AuthMember(dynamic requestData)
        {
            if (requestData.SalemanId <= 0)
            {
                return "exc error";
            }
            else if (requestData.MemberId <= 0)
            {
                return "exc error";
            }

            string sql = string.Format("insert into RegistCode Values({0},{1},2,getdate(),getdate());Update RegistMember Set RecommendId = {0} where MemberId = {1};Insert into MemberRef Values({1},{0},getdate());", requestData.SalemanId, requestData.MemberId);

            dataContext.ExecuteNonQuery(CommandType.Text, sql);
            return "success";
        } 
        #endregion

        /// <summary>
        /// 推荐同行注册获取二维码
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetRecommendPic(int MemberId = 0)
        {
            if (MemberId <= 0)
            {
                return "-1";
            }
            string appid = ConfigurationManager.AppSettings["WeiXinAppid"];
            string secret = ConfigurationManager.AppSettings["WeiXinSecret"];

            string postData = "{\"action_name\": \"QR_LIMIT_STR_SCENE\", \"action_info\": {\"scene\": {\"scene_str\": \"A" + MemberId.ToString() + "\"}}}";
            string ret = PostUrl.PostJson("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=" + BasicApi.GetAccessToken(), postData);
            var result = JsonHelper.JsonToObject<QRcode>(ret);
            return result.ticket;        
        }

        #region 验证推荐同行次数
        /// <summary>
        /// 验证推荐同行次数
        /// </summary>
        /// <param name="MemberId">会员ID</param>
        /// <returns></returns>
        [HttpGet]
        public int GetRecQualifications(int MemberId)
        {
            if (MemberId <= 0)
            {
                return 100;
            }
            string sql = string.Format("select COUNT(*) from RegistMember where MemberRecId = {0}", MemberId);
            var q = dataContext.ExecuteScalar(CommandType.Text, sql);

            return Convert.ToInt32(q);
        } 
        #endregion

        #region 积分红包验证活动资格(已废弃)
        /// <summary>
        /// 积分红包验证活动资格
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <returns></returns>
        [HttpGet]
        public int GetMemberSeniority(int memberId = 0)
        {
            if (memberId == 0)
            {
                return -1;
            }

            var sql = SqlParamHelper.Builder
                    .Append("Select COUNT(*) from MemberIntegralDetail")
                    .Append("where IntegralSource like '%扫描%' and CreatDate Between '2018-01-15 00:00:00' and '2018-02-11 23:59:59'")
                    .Append("and (Remark like '%味达美冰糖老抽%' or Remark like '%黄豆酱%' or Remark like '%6.18KG味达美尚品蚝油%') and MemberId = " + memberId + "")
                    .Append("group by MemberId");

            var q = dataContext.ExecuteScalar(CommandType.Text, sql.SQL);
            if (q == null)
            {
                return -1;
            }
            else if ((int)q > 2)
            {
                return 1;
            }

            return 0;
        } 
        #endregion

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public string SendWeChatMsg(string name, string openId)
        {
            var json = "{\"touser\":\"" + openId + "\"," +
                                "\"template_id\":\"b0-aVm0y5Urmbup-cnCykHlYWHiuaGYy9DabB-ePetU\"," +
                                "\"url\":\"http://jifenweixin.shinho.net.cn/#/component/recommendstart\"," +
                                "\"data\":{" +
                                        "\"first\": {" +
                                            "\"value\":\"您推荐的"+ name +"已注册成功，并成功为您增加20积分，点击我的账户可查看积分明细。\"," +
                                            "\"color\":\"#173177\"" +
                                        "}," +
                                        "\"keyword1\":{" +
                                            "\"value\":\"推荐同行注册\"," +
                                            "\"color\":\"#173177\"" +
                                        "}," +
                                     "\"keyword2\":{" +
                                             "\"value\":\"" + DateTime.Now + "\"," +
                                            "\"color\":\"#173177\"" +
                                        "}," +
                                        "\"remark\":{" +
                                            "\"value\":\"点击详情，分享给同行好友一起来赚积分吧\"," +
                                            "\"color\":\"#173177\"" +
                                        "}" +
                                "}" + 
                            "}";

            PostUrl.PostJson("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + BasicApi.GetAccessToken(), json);

            return "success";
        }



    }
}