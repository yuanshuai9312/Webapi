using ABenNet.WebApi.EasyFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace ABenNet.WebApi.EasyFramework.Fillters
{
    /// <summary>
    /// API自定义错误过滤器属性
    /// </summary>
    public class EasyFrameworkExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 统一对调用异常信息进行处理，返回自定义的异常信息
        /// </summary>
        /// <param name="context">HTTP上下文对象</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            //自定义异常的处理
            Exception ex = context.Exception;
            if (ex != null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    //封装处理异常信息，返回指定JSON对象
#if DEBUG
                    Content = new StringContent(ResponseResult.Exception(ex.Message).ToJson()),
#else
                    Content = new StringContent(ResponseResult.Exception("接口出现了错误，请重试或者联系管理员").ToJson(), Encoding.UTF8, "application/json"),
#endif
                    ReasonPhrase = "exception"
                });
            }
        }
    }

    /// <summary>
    /// API自定义错误消息处理委托类。
    /// 用于处理访问不到对应API地址的情况，对错误进行自定义操作。
    /// </summary>
    public class EasyFrameworkErrorMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>((responseToCompleteTask) =>
            {
                HttpResponseMessage response = responseToCompleteTask.Result;
                HttpError error = null;
                if (response.TryGetContentValue<HttpError>(out error))
                {
                    if (error != null)
                    {
                        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                        {
                            //封装处理异常信息，返回指定JSON对象
#if DEBUG
                            Content = new StringContent(ResponseResult.Exception(error.Message).ToJson()),
#else       
                            Content = new StringContent(ResponseResult.Exception("接口出现了错误，请重试或者联系管理员").ToJson(), Encoding.UTF8, "application/json"),
#endif
                            ReasonPhrase = "error"
                        });
                    }
                }
                return response;
            });
        }
    }
}
