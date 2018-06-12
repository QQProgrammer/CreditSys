using CreditUserAPI.Common;
using CreditUserAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditUserAPI.Controllers
{
    /// <summary>
    /// 厨师详细信息API
    /// </summary>
    public class MemberProfileController : ApiController
    {
        private CreditContext db = new CreditContext();
        private SqlHelper dataContext = new SqlHelper();

        #region 完善客户信息
        /// <summary>
        /// 完善客户信息
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddMemberProfile(string requestData)
        {
            string query = JsonConvert.SerializeObject(requestData);
            MemberProfile model = JsonConvert.DeserializeObject<MemberProfile>(query);
            db.MemberProfile.Add(model);
            db.SaveChanges();
            return model.MemberId.ToString();
        } 
        #endregion

        #region 查询会员的所有信息
        /// <summary>
        /// 查询会员的所有信息
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetMemberProfile(dynamic requestData)
        {

            string sql = string.Format("select r.*, rs.Name, rp.* from RegistMember as r left join MemberProfile as rp on r.MemberId = rp.MemberId left join RegistSaleMan as rs on r.RecommendId = rs.SalemanId  where r.MemberId = {0}", requestData.MemberId);
            var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
            return JsonConvert.SerializeObject(q);
        } 
        #endregion

        #region 微信端完善资料-基本信息
        /// <summary>
        /// 微信端完善资料-基本信息
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateMemberInfo(dynamic requestData)
        {
            try
            {

                #region 会员信息表字段修改
                var memberSql = SqlParamHelper.Builder
                    .Append("Update RegistMember Set MemberName = '" + requestData.MemberName + "',")
                    .Append(" ImgUrl = '" + requestData.ImgUrl + "',")
                    .Append(" MemberTelePhone = '" + requestData.MemberTelePhone + "',")
                    .Append(" Position = '" + requestData.Position + "',")
                    .Append(" PositionType = '" + requestData.PositionType + "',")
                    .Append(" ProvinceId = " + requestData.HProvinceId + ",")
                    .Append(" ProvinceName = '" + requestData.HProvinceName + "',")
                    .Append(" CityId = " + requestData.HCityId + ",")
                    .Append(" CityName = '" + requestData.HCityName + "',")
                    .Append(" AreaId = " + requestData.HAreaId + ",")
                    .Append(" AreaName = '" + requestData.HAreaName + "',")
                    .Append(" HotelAddress = '" + requestData.HotelAddress + "'")
                    .Append(" Where MemberId = " + requestData.MemberId + "");

                dataContext.ExecuteNonQuery(CommandType.Text, memberSql.SQL);
                #endregion

                #region 会员资料表字段修改
                var profileSql = SqlParamHelper.Builder
                   .Append("Update MemberProfile Set Sex = " + requestData.Sex + ",")
                   .Append(" Nation = '" + requestData.Nation + "',")
                   .Append(" Birthday = '" + Convert.ToDateTime(requestData.Birthday) + "',")
                   .Append(" Nature = '" + requestData.Nature + "',")
                   .Append(" HomeProvinceId = " + requestData.ProvinceId + ",")
                   .Append(" HomeProvinceName = '" + requestData.ProvinceName + "',")
                   .Append(" HomeCityId = " + requestData.CityId + ",")
                   .Append(" HomeCityName = '" + requestData.CityName + "',")
                   .Append(" HomeAreaId = " + requestData.AreaId + ",")
                   .Append(" HomeAreaName = '" + requestData.AreaName + "',")
                   .Append(" HomeAddress = '" + requestData.HomeAddress + "',")
                   .Append(" Hobbys = '" + requestData.Hobbys + "',")
                   .Append(" IsMarry = " + requestData.IsMarry + ",")
                   .Append(" ChineseLv = '" + requestData.ChineseLv + "',")
                   .Append(" IsJob = " + requestData.IsJob + "")
                   .Append(" Where MemberId = " + requestData.MemberId + "");

                dataContext.ExecuteNonQuery(CommandType.Text, profileSql.SQL);
                #endregion

            }
            catch (Exception ex)
            {
                return ex.Message + "|" + ex.Source;
            }
            return "Exc Success";
        } 
        #endregion

        #region 微信端完善资料-从厨理念
        /// <summary>
        /// 微信端完善资料-从厨理念
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateCookIdea(dynamic requestData)
        {
            try
            {
                var profileSql = SqlParamHelper.Builder
                        .Append("Update MemberProfile Set FoodDemand = '" + requestData.FoodDemand + "',")
                        .Append(" JobReason = '" + requestData.JobReason + "',")
                        .Append(" IsShare = " + requestData.IsShare + "")
                        .Append(" Where MemberId = " + requestData.MemberId + "");
                dataContext.ExecuteNonQuery(CommandType.Text, profileSql.SQL);
            }
            catch (Exception ex)
            {
                return ex.Message + "|" + ex.Source;
            }
            return "Exc Success";
        } 
        #endregion

        #region 微信端完善资料-职业技能
        /// <summary>
        /// 微信端完善资料-职业技能
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateJobSkill(dynamic requestData)
        {
            try
            {
                var profileSql = SqlParamHelper.Builder
                .Append("Update MemberProfile Set Educations = '" + requestData.Educations + "',")
                .Append(" Major = '" + requestData.Major + "',")
                .Append(" Purchaser = '" + requestData.Purchaser + "',")
                .Append(" Speciality = '" + requestData.Speciality + "',")
                .Append(" School = '" + requestData.School + "',")
                .Append(" Teacher = '" + requestData.Teacher + "',")
                .Append(" ExpertInCuisine = '" + requestData.ExpertInCuisine + "',")
                .Append(" SuccessReasons = '" + requestData.SuccessReasons + "',")
                .Append(" Represent = '" + requestData.Represent + "',")
                .Append(" Development = '" + requestData.Development + "',")
                .Append(" WishCity = '" + requestData.WishCity + "',")
                .Append(" ChoicePower = '" + requestData.ChoicePower + "',")
                .Append(" IsCtrlTime = '" + requestData.IsCtrlTime + "',")
                .Append(" IsManyExp = " + requestData.IsManyExp + ",")
                .Append(" JoinDate = '" + Convert.ToDateTime(requestData.JoinDate) + "'")
                .Append(" Where MemberId = " + requestData.MemberId + "");

                dataContext.ExecuteNonQuery(CommandType.Text, profileSql.SQL);
            }
            catch (Exception ex)
            {
                return ex.Message + "|" + ex.Source;
            }
            return "Exc Success";
        } 
        #endregion

        #region 微信端完善资料-荣誉资格
        /// <summary>
        /// 微信端完善资料-荣誉资格
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateHonor(dynamic requestData)
        {

            try
            {
                var profileSql = SqlParamHelper.Builder
                       .Append("Update MemberProfile Set MatchName = '" + requestData.MatchName + "',")
                       .Append(" MatchLv = '" + requestData.MatchLv + "',")
                       .Append(" MatchNum = '" + requestData.MatchNum + "',")
                       .Append(" Qualifications = '" + requestData.Qualifications + "',")
                       .Append(" DietitianLv = '" + requestData.DietitianLv + "',")
                       .Append(" ExposureCount = '" + requestData.ExposureCount + "',")
                       .Append(" Honor = '" + requestData.Honor + "'")
                       .Append(" Where MemberId = " + requestData.MemberId + "");

                dataContext.ExecuteNonQuery(CommandType.Text, profileSql.SQL);
            }
            catch (Exception ex)
            {
                return ex.Message + "|" + ex.Source;
            }

            return "Exc Success";
        } 
        #endregion

        #region 微信端完善资料-自我介绍
        /// <summary>
        /// 微信端完善资料-自我介绍
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public string UpdateIntroduction(dynamic requestData)
        {


            var profileSql = SqlParamHelper.Builder
                .Append("Update MemberProfile Set Introduction = '" + requestData.Introduction + "'")
                .Append(" Where MemberId = " + requestData.MemberId + "");

            dataContext.ExecuteNonQuery(CommandType.Text, profileSql.SQL);

            return "Exc Success";
        } 
        #endregion

    }
}
