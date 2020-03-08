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
    public class LoginResponseType : BaseResponseType
    {
        [JsonProperty("Data")]
        public LoginResponseTypeItem Data
        {
            get;
            set;
        }
    }

    [Serializable]
    public class LoginResponseTypeItem
    {
        [JsonProperty]
        public string Token { get; set; }
    }
}
