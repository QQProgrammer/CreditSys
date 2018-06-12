using System;
using System.Collections.Generic;
using CommonAPI.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;

namespace CommonAPI.Controllers
{
    /// <summary>
    /// 省市区三级查询部分
    /// </summary>
    public class RegionsController : ApiController
    {
        private SqlHelper dataContext = new SqlHelper();

        /// <summary>
        /// 获取所有省
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetAllProvince()
        {
            var sql = string.Format("select ProvinceId, ProvinceName from Province");
            var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
            return JsonConvert.SerializeObject(q);
        }

        /// <summary>
        /// 根据省ID获取市，如需要查询全部则不需要传参数
        /// </summary>
        /// <param name="provinceId">省ID</param>
        /// <returns></returns>
        [HttpGet]
        public string GetCityList(int provinceId = 0)
        {
            if (provinceId > 0)
            {
                string sql = string.Format("select ProvinceId, CityId, CityName from City where ProvinceId = {0}", provinceId);
                var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
                return JsonConvert.SerializeObject(q);
            }
            else
            {
                string sql = string.Format("select ProvinceId, CityId, CityName from City");
                var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
                return JsonConvert.SerializeObject(q);
            }
        }

        /// <summary>
        /// 根据市ID获取区,如果需查询全部则不需要传参数
        /// </summary>
        /// <param name="cityId">市ID</param>
        /// <returns></returns>
        [HttpGet]
        public string GetAreaList(int cityId = 0)
        {
            if (cityId > 0)
            {
                string sql = string.Format("select CityId, AreaId, AreaName from Area where CityId = {0}", cityId);
                var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
                return JsonConvert.SerializeObject(q);
            }
            else
            {
                string sql = string.Format("select CityId, AreaId, AreaName from Area");
                var q = dataContext.ExecuteDataTable(CommandType.Text, sql);
                return JsonConvert.SerializeObject(q);
            }
        }
    }
}
