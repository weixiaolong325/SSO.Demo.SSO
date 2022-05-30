namespace SSO.Demo.Web2.Utils
{
    /// <summary>
    /// 获取token响应结果
    /// </summary>
    public class GetTokenDTO
    {
        /// <summary>
        /// token
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 刷新token
        /// </summary>
        public string refreshToken { get; set; }
        /// <summary>
        /// 过期时间,多少s后
        /// </summary>
        public int expires { get; set; }
        /// <summary>
        /// 资源域
        /// </summary>
        public string scope { get; set; }
    }

}
