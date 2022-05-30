using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SSO.Demo.Web1.Utils
{
    /// <summary>
    /// 拦截认证过滤器
    /// </summary>
    public class MyAuthorize : Attribute, IAuthorizationFilter
    {
        private static Cachelper _cachelper = ServiceLocator.Instance.GetService<Cachelper>();


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string id = context.HttpContext.User.FindFirst("id")?.Value;
            if(string.IsNullOrEmpty(id))
            {
                //token检验失败
                context.Result = new StatusCodeResult(401); //返回鉴权失败
                return;
            }

            Console.WriteLine("我是Authorization过滤器");
            //请求的地址
            var url = context.HttpContext.Request.Path.Value;
            //获取打印头部信息
            var heads = context.HttpContext.Request.Headers;

            //取到token "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoi5byg5LiJIiwiQWNjb3VudCI6ImFkbWluIiwiSWQiOiIxMDEiLCJNb2JpbGUiOiIxMzgwMDEzODAwMCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlN1cGVyQWRtaW4iLCJleHAiOjE2NTMwNjA0MDIsImlzcyI6IlNTT0NlbnRlciIsImF1ZCI6IndlYjIifQ.aAi5a0zr_nLQQaSxSBqEhHZQ6ALFD_rWn2tnLt38DeA"
            string token = heads["Authorization"];
            token = token.Replace("Bearer", "").TrimStart();//去掉 "Bearer "才是真正的token
            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("校验不通过");
                return;
            }
            //redis校验这个token的有效性，确定来源是sso和确定会话没过期
            string tokenKey = $"token:{token}";
            bool isVaid = _cachelper.StringGet<bool>(tokenKey);
            //token无效
            if (isVaid == false)
            {
                Console.WriteLine($"token无效,token:{token}");
                context.Result = new StatusCodeResult(401); //返回鉴权失败
            }


        }
    }
}
