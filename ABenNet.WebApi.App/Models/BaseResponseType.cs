using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ABenNet.WebApi.App.Models
{
    [Serializable]
    public class BaseResponseType
    {
        /// <summary>
        /// 返回状态(100为成功,其余均为失败)
        /// </summary>
        [JsonProperty]
        public int RequestStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty]
        public string Msg
        {
            get;
            set;
        }
    }
}
