namespace SSO.Demo.Web1.Models
{
    public class AppOptions
    {
        /// <summary>
        /// sso设置
        /// </summary>
        public SSOSetting SSOSetting { get; set; }
    }
    public class SSOSetting
    {
        /// <summary>
        /// jwt颁发者
        /// </summary>
        public string issuer { get; set; }
        /// <summary>
        /// jwt接收者
        /// </summary>
        public string audience { get; set; }
        /// <summary>
        /// 应用client id 和sso中保持一致
        /// </summary>
        public string clientId { get; set; }
        /// <summary>
        /// 应用client secret 和sso保持一致
        /// </summary>
        public string clientSecret { get; set; }
    }
}
