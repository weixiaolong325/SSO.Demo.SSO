using Microsoft.AspNetCore.Mvc;
using SSO.Demo.SSO.Models;
using SSO.Demo.SSO.Util;
using System.Text;

namespace SSO.Demo.SSO.Controllers
{
    /// <summary>
    /// 登录页面
    /// </summary>
    public class SSOController : Controller
    {
        private readonly IJWTService _jwtService;
        IHttpClientFactory _httpClientFactory;
        Cachelper _cachelper;
        public SSOController(IJWTService jwtService, IHttpClientFactory httpClientFactory, Cachelper cachelper)
        {
            _jwtService = jwtService;
            _httpClientFactory = httpClientFactory;
            _cachelper = cachelper;
        }
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 获取授权码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseModel<string> GetCode([FromBody] GetCoderRequest request)
        {
            var result = _jwtService.GetCode(request.clientId, request.userName, request.passWord);

            return result;
        }
        /// <summary>
        /// 根据授权码,获取Token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="appHSSetting"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseModel<GetTokenDTO> GetToken([FromBody] GetTokenRequestDTO request)
        {
            var result = _jwtService.GetTokenWithRefresh(request.authCode);
            return result;
        }
        /// <summary>
        /// 根据会话code获取授权码
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="sessionCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseModel<string> GetCodeBySessionCode([FromBody] GetCodeBySessionCodeRequest request)
        {
            var result = _jwtService.GetCodeBySessionCode(request.clientId, request.sessionCode);
            return result;
        }

        /// <summary>
        /// 退出登录页面
        /// </summary>
        /// <returns></returns>
        public IActionResult LogOut()
        {
            return View();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseModel> LogOutApp([FromBody] LogOutRequest request)
        {
            //删除全局会话
            string sessionKey = $"SessionCode:{request.sessionCode}";
            _cachelper.DeleteKey(sessionKey);
            var client = _httpClientFactory.CreateClient();
            var param = new { sessionCode = request.sessionCode };
            string jsonData = System.Text.Json.JsonSerializer.Serialize(param);
            StringContent paramContent = new StringContent(jsonData);

            //这里实战中是用数据库或缓存取
            List<string> urls = new List<string>()
            {
                "https://localhost:7001/Account/LogOut",
                "https://localhost:7002/Account/LogOut"
            };
            //这里可以异步mq处理，不阻塞返回
            foreach (var url in urls)
            {
                //web1退出登录
                var logOutResponse = await client.PostAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"));
                string resultStr = await logOutResponse.Content.ReadAsStringAsync();
                ResponseModel response = System.Text.Json.JsonSerializer.Deserialize<ResponseModel>(resultStr);
                if (response.code == 0) //成功
                {
                    Console.WriteLine($"url:{url},会话Id:{request.sessionCode},退出登录成功");
                }
                else
                {
                    Console.WriteLine($"url:{url},会话Id:{request.sessionCode},退出登录失败");
                }
            };
            return new ResponseModel().SetSuccess();

        }
    }
}
