using ABenNet.WebApi.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABenNet.WebApi.App.IDefaultAPIService
{
    public interface ILoginDefaultApiService
    {
        /// <summary>
        /// 验证用户登录状态
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        LoginResponseType VerifyUserLogin(string uid, string pwd);

        LoginResponseType VerifyUserLoginByFromBody(string uid, string pwd);
    }
}
