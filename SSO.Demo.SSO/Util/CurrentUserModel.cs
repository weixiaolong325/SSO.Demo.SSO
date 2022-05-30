namespace SSO.Demo.SSO.Util
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    public class CurrentUserModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public string account { get; set; }
        public string mobile { get; set; }
        public string role { get; set; }
    }
}
