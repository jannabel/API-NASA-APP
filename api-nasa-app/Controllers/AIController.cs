﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DATA_L.AI;
using Newtonsoft.Json;
using System.Web;
using DATA_L.Models.Face;

namespace api_nasa_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {

        [HttpPost]
        [Route("VerifyFace")]
        public async Task<bool> VerifyFace(string imgUrl1, string imgUrl2)
        {
            try
            {
                FaceDetection FaceDataL = new FaceDetection();
                var data = await FaceDataL.VerifyFace(imgUrl1, imgUrl2);

                //string JsonData = JsonConvert.SerializeObject(data);

                //JsonData.Replace(@"\", " ");
                if (data.isIdentical == true)
                    return true;
                else if (data.isIdentical == false)
                    return false;
            }
            catch
            {
                return false;
            }

            return false;

        }


        [HttpPost]
        public async Task<ContentResult> DetectSign(string imgUrl)
        {
            SignsDetection SignsDataL = new SignsDetection();
            var data = await SignsDataL.DetectSign(imgUrl);

            string JsonData = JsonConvert.SerializeObject(data);

            JsonData.Replace(@"\", " ");

            return new ContentResult { Content = JsonData, ContentType = "application/json" };

        }


        [HttpPost]
        [Route("GetFaceId")]
        public async Task<ContentResult> GetFaceId(string imgUrl)
        {
            FaceDetection FaceDataL = new FaceDetection();
            var data = await FaceDataL.GetFaceId(imgUrl);

            string JsonData = JsonConvert.SerializeObject(data);

            JsonData.Replace(@"\", " ");

            return new ContentResult { Content = JsonData, ContentType = "application/json" };

        }

        /*
        [HttpPost]
        [Route("ParseURL")]
        public string ParseURL(string imgUrl)
        {
            // Parses the query string as a NameValueCollection:
            var queryParams = HttpUtility.UrlEncode(imgUrl);

            return queryParams.ToString();
        }
        */
    }
}
