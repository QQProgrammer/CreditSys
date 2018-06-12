using CommonAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebGrease;

namespace CommonAPI.Controllers
{
    public class ImageController : ApiController
    {
        #region 后台图片上传
        /// <summary>
        /// 图片上传API
        /// </summary>
        /// <param name="img_type">
        /// 图片类型：
        /// img_type = "Member"   用户类
        /// img_type = "Product"  商城类
        /// img_type = "Cook"     菜品类
        /// img_type = "Activity" 活动类
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> ImgUpload(string img_type)
        {
            string ROOT_PATH = string.Empty;

            switch (img_type)
            {
                case "Member":
                    ROOT_PATH = HttpContext.Current.Server.MapPath("~/UploadFiles/Member");
                    break;
                case "Product":
                    ROOT_PATH = HttpContext.Current.Server.MapPath("~/UploadFiles/Product");
                    break;
                case "Cook":
                    ROOT_PATH = HttpContext.Current.Server.MapPath("~/UploadFiles/Cook");
                    break;
                case "Activity":
                    ROOT_PATH = HttpContext.Current.Server.MapPath("~/UploadFiles/Activity");
                    break;
                case "Tools":
                    ROOT_PATH = HttpContext.Current.Server.MapPath("~/UploadFiles/Tools");
                    break;
                default:
                    return "Request Error";
            }

            //ROOT_PATH = HttpContext.Current.Server.MapPath("~/UploadFiles/");

            List<Resource> resources = new List<Resource>();
            // 采用MultipartMemoryStreamProvider
            var provider = new MultipartMemoryStreamProvider();

            //读取文件数据
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var item in provider.Contents)
            {
                // 判断是否是文件
                if (item.Headers.ContentDisposition.FileName != null)
                {
                    //获取到流
                    var ms = item.ReadAsStreamAsync().Result;
                    //进行流操作
                    using (var br = new BinaryReader(ms))
                    {
                        if (ms.Length <= 0)
                            break;
                        //读取文件内容到内存中
                        var data = br.ReadBytes((int)ms.Length);
                        //Create
                        //当前时间作为ID
                        Resource resource = new Resource() { Id = DateTime.Now.ToString("yyyyMMddHHmmssffff", DateTimeFormatInfo.InvariantInfo) };

                        //Info
                        FileInfo info = new FileInfo(item.Headers.ContentDisposition.FileName.Replace("\"", ""));
                        //文件类型
                        resource.Type = info.Extension.Substring(1).ToLower();
                        //Write
                        try
                        {
                            //文件存储地址
                            string dirPath = Path.Combine(ROOT_PATH);
                            if (!Directory.Exists(dirPath))
                            {
                                Directory.CreateDirectory(dirPath);
                            }

                            File.WriteAllBytes(Path.Combine(dirPath, resource.Id + "." + resource.Type), data);
                            resources.Add(resource);
                        }
                        catch { }
                    }
                }
            }

            if (resources.Count == 0)
                return "request error";
            else if (resources.Count == 1)
                return JsonConvert.SerializeObject(resources.FirstOrDefault());
            else
                return JsonConvert.SerializeObject(resources);
        }

        #endregion
    } 
}


