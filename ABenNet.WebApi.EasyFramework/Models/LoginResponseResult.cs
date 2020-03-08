using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ABenNet.WebApi.EasyFramework.Models
{
    public class LoginResponseResult
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }

        [JsonProperty("session_token")]
        public string SessionToken { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
