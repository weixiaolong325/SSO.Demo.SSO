using Microsoft.AspNetCore.Mvc;
using SSO.Demo.SSO.Models;
using SSO.Demo.SSO.Util;

namespace SSO.Demo.SSO.Controllers
{
    /// <summary>
    /// 授权信息获取
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IJWTService _jwtService;
        public AccountController(IJWTService jwtService)
        {
            _jwtService = jwtService;
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

    }
}
