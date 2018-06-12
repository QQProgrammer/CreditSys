using CreditUserAPI.Common;
using CreditUserAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditUserAPI.Controllers
{
    /// <summary>
    /// 注册码部分API
    /// </summary>
    public class RegistCodeController : ApiController
    {
        private CreditContext db = new CreditContext();
        private SqlHelper dataContext = new SqlHelper();

        #region 队员生成注册码（一次十条）
        /// <summary>
        /// 队员生成注册码（一次十条）
        /// </summary>
        /// <param name="salemanId">队员ID</param>
        /// <returns>返回是否新增成功</returns>
        [HttpGet]
        public string AddRegistCode(string salemanId)
        {
            try
            {
                int Id = Convert.ToInt32(salemanId);
                if (Id <= 0)
                {
                    return "Request Parameter Error";
                }

                for (int i = 0; i < 10; i++)
                {
                    RegistCode code = new RegistCode();
                    code.SalemanId = Id;
                    code.MemberId = 0;
                    code.RegistCodeState = 1;
                    code.GenerDate = DateTime.Now;
                    //code.UseDate = DateTime.MinValue;

                    db.RegistCode.Add(code);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return ("程序出错，信息为:" + ex.InnerException);
            }

            return "Succss";
        } 
        #endregion

        #region 获取队员注册码列表
        /// <summary>
        /// 获取队员注册码列表
        /// </summary>
        /// <param name="salemanId">队员Id</param>
        /// <returns></returns>
        [HttpPost]
        public string RegistCodeList(dynamic requestData)
        {
            int salemanId = requestData.SalemanId;
            int codeState = requestData.CodeState;

            if (salemanId > 0)
            {
                if (codeState == 1)
                {
                    string sql = string.Format("select * from RegistCode where SalemanId  = {0} and RegistCodeState = 1", salemanId);
                    var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
                    return JsonConvert.SerializeObject(q);
                }
                else
                {
                    string sql = string.Format("select rc.*, rm.MemberName, rm.HotelName from RegistCode as rc inner join RegistMember as rm on rm.MemberId = rc.MemberId where SalemanId  = {0} and RegistCodeState = 2", salemanId);
                    var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
                    return JsonConvert.SerializeObject(q);
                }
                
            }
            else
            {
                return "Request Parameter Error";
            }
        } 
        #endregion

        #region 判断注册码是否合法
        /// <summary>
        /// 判断注册码是否合法
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public string CheckRegistCode(int code = 0)
        {
            if (code > 0)
            {
                string sql = string.Format("select * from RegistCode where RegistCodeId = {0} and RegistCodeState = 1", code);
                var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
                return q.Rows.Count.ToString();
            }
            else
            {
                return "Request Parameter Error";
            }
        } 
        #endregion
    }
}
