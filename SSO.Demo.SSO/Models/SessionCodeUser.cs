using SSO.Demo.SSO.Util;

namespace SSO.Demo.SSO.Models
{
    public class SessionCodeUser
    {
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime expiresTime { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public CurrentUserModel currentUser { get; set; }
    }
}
