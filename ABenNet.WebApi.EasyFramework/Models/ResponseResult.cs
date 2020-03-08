using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace ABenNet.WebApi.EasyFramework.Models
{
    public class ResponseResult
    {
        public ResponseResult()
        {
        }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty(Order = 0)]
        public int RequestStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty(Order = 1)]
        public string Msg
        {
            get;
            set;
        }

        public static ResponseResult Default()
        {
            var result = new ResponseResult();
            result.RequestStatus = (int)ResponseResultStatus.Default;
            result.Msg = "";
            return result;
        }

        public static ResponseResult Success(string message = "")
        {
            var result = new ResponseResult();
            result.RequestStatus = (int)ResponseResultStatus.Succeed;
            result.Msg = message;
            return result;
        }

        public static ResponseResult Exception(string message)
        {
            var result = new ResponseResult();
            result.RequestStatus = (int)ResponseResultStatus.Exception;
            result.Msg = message;
            return result;
        }

        public static ResponseResult Faild(string message)
        {
            var result = new ResponseResult();
            result.RequestStatus = (int)ResponseResultStatus.Faild;
            result.Msg = message;
            return result;
        }

        public static ResponseResult Repeat(string message)
        {
            var result = new ResponseResult();
            result.RequestStatus = (int)ResponseResultStatus.Repeated;
            result.Msg = message;
            return result;
        }

        public static ResponseResult NotAuthorization(string message)
        {
            var result = new ResponseResult();
            result.RequestStatus = (int)ResponseResultStatus.NotAuthorization;
            result.Msg = message;
            return result;
        }

        public  string ToJson()
        {
           return JsonConvert.SerializeObject(this);
        }

    }
    public class ResponseResult<T> : ResponseResult
        where T : class, new()
    {
        public ResponseResult()
        {
            this.Data = new T();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Order = 2)]
        public T Data
        {
            get;
            set;
        }

        public static ResponseResult<T> Default()
        {
            var result = new ResponseResult<T>();
            result.Data = default(T);
            result.RequestStatus = (int)ResponseResultStatus.Default;
            result.Msg = "";
            return result;
        }

        public static ResponseResult<T> Success(T t, string message = "")
        {
            var result = new ResponseResult<T>();
            result.Data = t;
            result.RequestStatus = (int)ResponseResultStatus.Succeed;
            result.Msg = message;
            return result;
        }

        public static ResponseResult<T> Repeat(T t, string message = "")
        {
            var result = new ResponseResult<T>();
            result.Data = t;
            result.RequestStatus = (int)ResponseResultStatus.Repeated;
            result.Msg = message;
            return result;
        }

        public static ResponseResult<T> Exception(string message)
        {
            var result = new ResponseResult<T>();
            result.Data = default(T);
            result.RequestStatus = (int)ResponseResultStatus.Exception;
            result.Msg = message;
            return result;
        }

        public static ResponseResult<T> Faild(string message)
        {
            var result = new ResponseResult<T>();
            result.Data = default(T);
            result.RequestStatus = (int)ResponseResultStatus.Faild;
            result.Msg = message;
            return result;
        }

        public static ResponseResult<T> NotAuthorization(string message)
        {
            var result = new ResponseResult<T>();
            result.Data = default(T);
            result.RequestStatus = (int)ResponseResultStatus.NotAuthorization;
            result.Msg = message;
            return result;
        }
    }
    public enum ResponseResultStatus
    {
        Default = 0,
        Succeed = 100,
        Faild = 101,
        Exception = 102,
        NotAuthorization = 403,
        Repeated = 111,
    }
}