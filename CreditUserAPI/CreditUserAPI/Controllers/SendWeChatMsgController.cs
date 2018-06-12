using CreditUserAPI.Common;
using CreditUserAPI.Models;
using CreditUserAPI.WeiXin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CreditUserAPI.Controllers
{
    public class SendWeChatMsgController : ApiController
    {
        private CreditContext db = new CreditContext();
        private SqlHelper dataContext = new SqlHelper();


        [HttpGet]
        public string SendMsg(int flag)
        { 
           //var salemanlist = _registSaleManService.GetAll("", 0);
           //var memberlist = _registMemberService.GetMsgMember();
            //var sql = string.Format("SELECT o.OpenId FROM RegistSaleMan AS rsm JOIN OpenIdAssociated o ON rsm.SalemanId=o.UserId where  RegistState = 2 and o.UserType = 1");
            var sql = string.Format(@"SELECT o.OpenId FROM RegistMember as r JOIN OpenIdAssociated as o ON r.MemberId=o.UserId
                                    WHERE MemberState=1 AND o.UserType = 2 and r.MemberId in (
                                    27488,
                                    22864,
                                    27488,
                                    34006,
                                    10948,
                                    27127,
                                    14022,
                                    10948,
                                    12461,
                                    14022,
                                    35121,
                                    31067,
                                    33405,
                                    10264,
                                    33441,
                                    15432,
                                    18085,
                                    12219,
                                    31003,
                                    17221,
                                    19582
                                    )");

            var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
            string result = JsonConvert.SerializeObject(q);
            List<SendMember> openIdList = new List<SendMember>();
            openIdList = JsonConvert.DeserializeObject<List<SendMember>>(result);

            var json = "";
            if (openIdList != null)
            {
                foreach (var a in openIdList)
                {
                    if (!string.IsNullOrEmpty(a.OpenId))
                    {
                        json = "{\"touser\":\"" + a.OpenId + "\"," +
                                "\"template_id\":\"b0-aVm0y5Urmbup-cnCykHlYWHiuaGYy9DabB-ePetU\"," +
                                "\"url\":\"http://mp.weixin.qq.com/s/tGECUZ_DPASXACoKIx7kgA\"," +
                                "\"data\":{" +
                                        "\"first\": {" +
                                            "\"value\":\"您在欣和味达美餐饮服务微信平台的积分已经添加成功，可进入微信平台打开“我的、我的账号”\"," +
                                            "\"color\":\"#173177\"" +
                                        "}," +
                                        "\"keyword1\":{" +
                                            "\"value\":\"2018春节MUST WIN激励\"," +
                                            "\"color\":\"#173177\"" +
                                        "}," +
                                     "\"keyword2\":{" +
                                             "\"value\":\"" + DateTime.Now + "\"," +
                                            "\"color\":\"#173177\"" +
                                        "}," +
                                        "\"remark\":{" +
                                            "\"value\":\"积分可用于积分商城兑换部分商品哦\"," +
                                            "\"color\":\"#173177\"" +
                                        "}" +
                                "}" +
                            "}";
                      //  json = "{\"touser\":\"" + a.OpenId + "\"," +
                      //    "\"template_id\":\"b0-aVm0y5Urmbup-cnCykHlYWHiuaGYy9DabB-ePetU\"," +
                      //    "\"url\":\"http://mp.weixin.qq.com/s/5H6_rnk86ai2fOs-ChI2Gg\"," +
                      //    "\"data\":{" +
                      //            "\"first\": {" +
                      //                "\"value\":\"恭喜您，在欣春迎家味摇一摇中中奖啦，现在去【我的账户-我的订单-未提交】中提交吧，填写您的收货地址，大礼包马上到！\"," +
                      //                "\"color\":\"#173177\"" +
                      //            "}," +
                      //            "\"keyword1\":{" +
                      //                "\"value\":\"欣春迎家味—领奖啦\"," +
                      //                "\"color\":\"#173177\"" +
                      //            "}," +
                      //           "\"keyword2\":{" +
                      //                "\"value\":\"" + DateTime.Now + "\"," +
                      //                "\"color\":\"#173177\"" +
                      //            "}," +
                      //            "\"remark\":{" +
                      //                "\"value\":\"务必快快的哦，再晚快递就停运啦！\"," +
                      //                "\"color\":\"#173177\"" +
                      //            "}" +
                      //    "}" +
                      //"}";
                      //  json = "{\"touser\":\"" + a.OpenId + "\"," +
                      //    "\"template_id\":\"b0-aVm0y5Urmbup-cnCykHlYWHiuaGYy9DabB-ePetU\"," +
                      //    "\"url\":\"http://jifenweixin.shinho.net.cn/#/component/pageshare\"," +
                      //    "\"data\":{" +
                      //            "\"first\": {" +
                      //                "\"value\":\"岁月会变，爱与温情不变，厨师平台给您送福利啦！\"," +
                      //                "\"color\":\"#173177\"" + 
                      //            "}," +
                      //            "\"keyword1\":{" +
                      //                "\"value\":\"转发厨师家味故事赚积分！\"," +
                      //                "\"color\":\"#173177\"" +
                      //            "}," +
                      //           "\"keyword2\":{" +
                      //                "\"value\":\"" + DateTime.Now + "\"," +
                      //                "\"color\":\"#173177\"" +
                      //            "}," +
                      //            "\"remark\":{" +
                      //                "\"value\":\"点击详情，积分赚起来！\"," +
                      //                "\"color\":\"#173177\"" +
                      //            "}" +
                      //    "}" +
                      //"}";
                      SendMuBanMsg(json);
                    }
                }
            }

            return "Excute Success";
        }

        /// <summary>
        /// 1注册成功给1发模板消息
        /// </summary>
        /// <param name="Response"></param>
        /// <param name="msg"></param>
        public void SendMuBanMsg(string json)
        {
            PostJson("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + BasicApi.GetAccessToken(), json);
        }

        /// <summary>
        /// post提交json
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        private string PostJson(string url, string json)
        {
            string ret = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                byte[] data = System.Text.Encoding.UTF8.GetBytes(json);
                request.Method = "POST";
                request.ContentType = "application/json"; //设置内容类型
                request.ContentLength = data.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                System.IO.Stream stream = response.GetResponseStream();
                System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.UTF8);
                ret = streamReader.ReadToEnd();

                streamReader.Close();
                stream.Close();
                response.Close();

                return ret;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(string.Format("{0}\n{1}\n{2}\n", ex.Message, ex.Source, ex.StackTrace));
                return ret;
            }

        }
    }
}
