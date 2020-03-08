using ABenNet.WebApi.EasyFramework.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ABenNet.WebApi.EasyFramework.Controllers
{
   /// <summary>
   /// Login服务控制器
   /// </summary>
    public class LoginServiceController : ApiController
    {
        /// <summary>
        /// Login方法
        /// </summary>
        /// <param name="user_id">用户编号</param>
        /// <param name="user_password">用户密码</param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public ResponseResult<LoginResponseResult> Login(string user_id, string user_password)
        {
            var result = ResponseResult<LoginResponseResult>.Default();
            try
            {
                if (string.IsNullOrEmpty(user_id))
                {
                    return ResponseResult<LoginResponseResult>.Faild("user_id不能为空!");
                }

                if (string.IsNullOrEmpty(user_password))
                {
                    return ResponseResult<LoginResponseResult>.Faild("user_password不能为空!");
                }

                //=>[模拟从数据库中验证user_id和user_password]
                if (user_id.Equals("abennet") && user_password.Equals("abennet"))
                {
                    LoginResponseResult entity = new LoginResponseResult
                    {
                        UserId = user_id,
                        UserPassword = user_password,
                        LoginTime = DateTime.Now,
                        SessionToken = Guid.NewGuid().ToString("N"),
                    };
                    result = ResponseResult<LoginResponseResult>.Success(entity, "登录成功!");
                }
                else
                {
                    result = ResponseResult<LoginResponseResult>.Faild("登录失败!");
                }
            }
            catch (System.Exception ex)
            {
                result = ResponseResult<LoginResponseResult>.Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 复杂参数传递By:LoginByJObject方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<LoginResponseResult> LoginByJObject([FromBody] JObject data)
        {
            var obj = new
            {
                user_id = data["user_id"].ToObject<string>(),
                user_password = data["user_password"].ToObject<string>(),
            };
            var result = ResponseResult<LoginResponseResult>.Default();
            try
            {
                if (string.IsNullOrEmpty(obj.user_id))
                {
                    return ResponseResult<LoginResponseResult>.Faild("user_id不能为空!");
                }

                if (string.IsNullOrEmpty(obj.user_password))
                {
                    return ResponseResult<LoginResponseResult>.Faild("user_password不能为空!");
                }

                //=>[模拟从数据库中验证user_id和user_password]
                if (obj.user_id.Equals("abennet") && obj.user_password.Equals("abennet"))
                {
                    LoginResponseResult entity = new LoginResponseResult
                    {
                        UserId = obj.user_id,
                        UserPassword = obj.user_password,
                        LoginTime = DateTime.Now,
                        SessionToken = Guid.NewGuid().ToString("N"),
                    };
                    result = ResponseResult<LoginResponseResult>.Success(entity, "登录成功!");
                }
                else
                {
                    result = ResponseResult<LoginResponseResult>.Faild("登录失败!");
                }
            }
            catch (System.Exception ex)
            {
                result = ResponseResult<LoginResponseResult>.Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 复杂参数传递By:LoginByDynamic
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<LoginResponseResult> LoginByDynamic([FromBody] dynamic data)
        {
            var obj = new
            {
                user_id = data.user_id.ToString(),
                user_password = data.user_password.ToString(),
            };
            var result = ResponseResult<LoginResponseResult>.Default();
            try
            {
                if (string.IsNullOrEmpty(obj.user_id))
                {
                    return ResponseResult<LoginResponseResult>.Faild("user_id不能为空!");
                }

                if (string.IsNullOrEmpty(obj.user_password))
                {
                    return ResponseResult<LoginResponseResult>.Faild("user_password不能为空!");
                }

                //=>[模拟从数据库中验证user_id和user_password]
                if (obj.user_id.Equals("abennet") && obj.user_password.Equals("abennet"))
                {
                    LoginResponseResult entity = new LoginResponseResult
                    {
                        UserId = obj.user_id,
                        UserPassword = obj.user_password,
                        LoginTime = DateTime.Now,
                        SessionToken = Guid.NewGuid().ToString("N"),
                    };
                    result = ResponseResult<LoginResponseResult>.Success(entity, "登录成功!");
                }
                else
                {
                    result = ResponseResult<LoginResponseResult>.Faild("登录失败!");
                }
            }
            catch (System.Exception ex)
            {
                result = ResponseResult<LoginResponseResult>.Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 复杂参数传递By:LoginByFromBody方法
        /// </summary>
        /// <param name="uid">uid编号</param>
        /// <param name="loginRequestParam"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<LoginResponseResult> LoginByFromBody([FromUri] int uid,
                                                                   [FromBody] LoginRequestParam loginRequestParam)
        {
            var result = ResponseResult<LoginResponseResult>.Default();
            try
            {
                if (string.IsNullOrEmpty(loginRequestParam.user_id))
                {
                    return ResponseResult<LoginResponseResult>.Faild("user_id不能为空!");
                }

                if (string.IsNullOrEmpty(loginRequestParam.user_password))
                {
                    return ResponseResult<LoginResponseResult>.Faild("user_password不能为空!");
                }

                //=>[模拟从数据库中验证user_id和user_password]
                if (loginRequestParam.user_id.Equals("abennet") && loginRequestParam.user_password.Equals("abennet"))
                {
                    LoginResponseResult entity = new LoginResponseResult
                    {
                        UserId = loginRequestParam.user_id,
                        UserPassword = loginRequestParam.user_password,
                        LoginTime = DateTime.Now,
                        SessionToken = Guid.NewGuid().ToString("N"),
                    };
                    result = ResponseResult<LoginResponseResult>.Success(entity, "登录成功!");
                }
                else
                {
                    result = ResponseResult<LoginResponseResult>.Faild("登录失败!");
                }
            }
            catch (System.Exception ex)
            {
                result = ResponseResult<LoginResponseResult>.Exception(ex.Message);
            }
            return result;
        }
    }
}
