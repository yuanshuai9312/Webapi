using ABenNet.WebApi.EasyFramework.Fillters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;

namespace ABenNet.WebApi.EasyFramework
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region [=>1、WebApi 返回JSON，不推荐做法性能不高]
            /*
            config.Formatters.Clear();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new UnderlineSplitContractResolver(), //小写命名法。
                DateFormatString = "yyyy-MM-dd HH:mm:ss",//解决json时间带T的问题
                Formatting = Newtonsoft.Json.Formatting.Indented,//解决json格式化缩进问题
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;//解决json序列化时的循环引用问题
                DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                NullValueHandling = NullValueHandling.Ignore;
            };
            */
            #endregion

            // Web API 配置和服务
            #region [=>2、WebApi 返回JSON，推荐做法性能最高]
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(new JsonMediaTypeFormatter()));
            #endregion

            //=>使webapi支持POST多简单参数传值
            GlobalConfiguration.Configuration.ParameterBindingRules.Insert(0, SimplePostVariableParameterBinding.HookupParameterBinding);

            //=>统一捕获异常格式化输出
            config.Filters.Add(new EasyFrameworkExceptionAttribute());
            config.MessageHandlers.Add(new EasyFrameworkErrorMessageHandler());

            //=>支持启用跨域访问
            // 1、配置方法一：如果果您希望提供全局 CORS 策略，即所有来源请求都可以访问
            // 2、配置方法二、如果你只想对某一些api做跨域，可以直接在API的类上面使用特性标注即可。
           //                            比如：[EnableCors(origins: "http://localhost:8081/", headers: "*", methods: "GET,POST,PUT,DELETE")]
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            //为了安全，一般是配置指定实际中你的来源前端域名地址。
           // config.EnableCors(new EnableCorsAttribute("http://localhost:8081/", "*", "*"));

            // Web API 特性路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    /// <summary>
    ///  在全局设置中，使用自定义的只返回Json Result。只让api接口中替换xml，返回json。这种方法的性能是最高的！
    /// </summary>
    public class JsonContentNegotiator : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter _jsonFormatter;
        public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
        {
            _jsonFormatter = formatter;
        }
        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            // 对 JSON 数据使用混合大小写。驼峰式,但是是javascript 首字母小写形式.小驼峰命名法。
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new  CamelCasePropertyNamesContractResolver();
            // 对 JSON 数据使用混合大小写。跟属性名同样的大小.输出
            _jsonFormatter.SerializerSettings.ContractResolver = new UnderlineSplitContractResolver(); //小写命名法。
            _jsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//解决json时间带T的问题
            _jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;//解决json格式化缩进问题
            _jsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;//解决json序列化时的循环引用问题
            //_jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            _jsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            var result = new ContentNegotiationResult(_jsonFormatter, new MediaTypeHeaderValue("application/json"));
            return result;
        }
    }

    /// <summary>
    /// Json.NET 利用ContractResolver解决命名不一致问题
    /// https://www.cnblogs.com/hao-dotnet/p/4229825.html
    /// 解决问题：通过无论是序列化还是反序列化都达到了效果，即：ProjectName -> project_name 和 project_name -> ProjectName
    /// </summary>
    public class UnderlineSplitContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            //return CamelCaseToUnderlineSplit(propertyName);//下划线分割命名法
            //return propertyName.ToLower();//小写命名法
            return propertyName;//保持命名不变。
        }

        private string CamelCaseToUnderlineSplit(string name)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                var ch = name[i];
                if (char.IsUpper(ch) && i > 0)
                {
                    var prev = name[i - 1];
                    if (prev != '_')
                    {
                        if (char.IsUpper(prev))
                        {
                            if (i < name.Length - 1)
                            {
                                var next = name[i + 1];
                                if (char.IsLower(next))
                                {
                                    builder.Append('_');
                                }
                            }
                        }
                        else
                        {
                            builder.Append('_');
                        }
                    }
                }

                builder.Append(char.ToLower(ch));
            }

            return builder.ToString();
        }
    }
}
