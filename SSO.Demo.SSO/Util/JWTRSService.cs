using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SSO.Demo.SSO.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SSO.Demo.SSO.Util
{
    /// <summary>
    /// JWT非对称加密
    /// </summary>
    public class JWTRSService : JWTBaseService
    {
  
        public JWTRSService(IOptions<AppSettingOptions> options, Cachelper cachelper):base(options, cachelper)
        {
 
        }
        /// <summary>
        /// 生成非对称加密签名凭证
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        protected override SigningCredentials GetCreds(string clientId)
        {
            var appRSSetting = getAppInfoByAppKey(clientId);
            var rsa = RSA.Create();
            byte[] privateKey = Convert.FromBase64String(appRSSetting.privateKey);//这里只需要私钥，不要begin,不要end
            rsa.ImportPkcs8PrivateKey(privateKey, out _);
            var key = new RsaSecurityKey(rsa);
            var creds = new SigningCredentials(key, SecurityAlgorithms.RsaSha256);
            return creds;
        }
        /// <summary>
        /// 根据appKey获取应用信息
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        private AppRSSetting getAppInfoByAppKey(string clientId)
        {
            AppRSSetting appRSSetting = _appSettingOptions.Value.appRSSettings.Where(s => s.clientId == clientId).FirstOrDefault();
            return appRSSetting;
        }

    }
}
