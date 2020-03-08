using ABenNet.WebApi.App.IDefaultAPIService;
using ABenNet.WebApi.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ABenNet.WebApi.App.Core;

namespace ABenNet.WebApi.App.DefaultAPIServiceImpl
{
    public class LoginDefaultApiService : ILoginDefaultApiService
    {
        public LoginResponseType VerifyUserLogin(string uid, string pwd)
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("user_id", uid);
                dict.Add("user_password", pwd);
                var result = HttpWebRequestHelper.HttpRequest(getOrPost: "GET",
                                                                                          url: "http://localhost:5678/api/LoginService/Login",
                                                                                          headers: null,
                                                                                          parameters: dict,
                                                                                         dataEncoding: Encoding.UTF8,
                                                                                         contentType: "application/x-www-form-urlencoded");
                return JsonConvert.DeserializeObject<LoginResponseType>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoginResponseType VerifyUserLoginByFromBody(string uid, string pwd)
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("user_id", uid);
                dict.Add("user_password", pwd);
                var result = HttpWebRequestHelper.HttpRequest(getOrPost: "POST",
                                                                                          url: "http://localhost:5678/api/LoginService/LoginByFromBody?uid=123456",
                                                                                          headers: null,
                                                                                          parameters: dict,
                                                                                          dataEncoding: Encoding.UTF8,
                                                                                         contentType: "application/json");
                return JsonConvert.DeserializeObject<LoginResponseType>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
