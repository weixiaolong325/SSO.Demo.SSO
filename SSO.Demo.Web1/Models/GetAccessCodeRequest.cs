namespace SSO.Demo.Web1.Models
{
    public class GetAccessCodeRequest
    {
        /// <summary>
        /// 授权码
        /// </summary>
        public string authCode { get; set; }
        /// <summary>
        /// 会话Code
        /// </summary>
        public string sessionCode { get; set; }
    }
}
