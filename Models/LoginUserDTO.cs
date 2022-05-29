namespace SSO.Demo.SSO.Models
{
    public class LoginUserDTO
    {
        public string clientId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        public string sign { get; set; }
    }
}
