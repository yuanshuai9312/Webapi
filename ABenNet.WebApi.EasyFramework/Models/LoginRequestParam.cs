using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABenNet.WebApi.EasyFramework.Models
{
    public class LoginRequestParam
    {
        /// <summary>
        /// 请求参数：用户编号
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 请求参数：用户密码
        /// </summary>
        public string user_password { get; set; }

    }
}