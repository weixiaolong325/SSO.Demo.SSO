using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSO.Demo.Web1.Models;
using SSO.Demo.Web1.Utils;
using System.Net.Http.Headers;
using System.Text;

namespace SSO.Demo.Web1.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>

    public class AccountController : Controller
    {
        private IHttpClientFactory _httpClientFactory;
        private readonly Cachelper _cachelper;
        public AccountController(IHttpClientFactory httpClientFactory, Cachelper cachelper)
        {
            _httpClientFactory = httpClientFactory;
            _cachelper = cachelper;
        }

        /// <summary>
        /// 获取用户信息，接口需要进行权限校验
        /// </summary>
        /// <returns></returns>
        [MyAuthorize]
        [HttpPost]
        public ResponseModel<UserDTO> GetUserInfo()
        {
            ResponseModel<UserDTO> user = new ResponseModel<UserDTO>();
            return user;
        }
        /// <summary>
        /// 登录成功回调
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginRedirect()
        {
            return View();
        }
        //根据authCode获取token
        [HttpPost]
        public async Task<ResponseModel<GetTokenDTO>> GetAccessCode([FromBody] GetAccessCodeRequest request)
        {
            ResponseModel<GetTokenDTO> result = new ResponseModel<GetTokenDTO>();
            //请求SSO获取 token
            var client = _httpClientFactory.CreateClient();
            var param = new { authCode = request.authCode };
            string jsonData = System.Text.Json.JsonSerializer.Serialize(param);
            StringContent paramContent = new StringContent(jsonData);

            //请求sso获取token
            var response = await client.PostAsync("https://localhost:7000/SSO/GetToken", new StringContent(jsonData, Encoding.UTF8, "application/json"));
            string resultStr = await response.Content.ReadAsStringAsync();
            result = System.Text.Json.JsonSerializer.Deserialize<ResponseModel<GetTokenDTO>>(resultStr);
            if (result.code == 0) //成功
            {
                //成功,缓存token到局部会话
                string token = result.data.token;
                string key = $"SessionCode:{request.sessionCode}";
                string tokenKey = $"token:{token}";
                _cachelper.StringSet<string>(key, token, TimeSpan.FromSeconds(result.data.expires));
                _cachelper.StringSet<bool>(tokenKey, true, TimeSpan.FromSeconds(result.data.expires));
                Console.WriteLine($"获取token成功，局部会话code:{request.sessionCode},{Environment.NewLine}token:{token}");
            }

            return result;
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public  ResponseModel LogOut([FromBody] LogOutRequest request)
        {
            string key = $"SessionCode:{request.SessionCode}";
            //根据会话取出token
            string token = _cachelper.StringGet<string>(key);
            if (!string.IsNullOrEmpty(token))
            {
                //清除token
                string tokenKey = $"token:{token}";
                _cachelper.DeleteKey(tokenKey);
            }
            Console.WriteLine($"会话Code:{request.SessionCode}退出登录");
            return new ResponseModel().SetSuccess();
        }
    }
}
