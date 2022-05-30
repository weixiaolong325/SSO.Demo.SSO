namespace SSO.Demo.SSO.Models
{
    public class GetCoderRequest
    {
        /// <summary>
        /// 应用Id
        /// </summary>
        public string clientId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string passWord { get; set; }
    }
    public class GetCodeBySessionCodeRequest
    {
        /// <summary>
        /// 应用Id
        /// </summary>
        public string clientId { get; set; }
        /// <summary>
        /// 会话code
        /// </summary>
        public string sessionCode { get; set; }
    }
}
