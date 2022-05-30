namespace SSO.Demo.Web1.Models
{
    /// <summary>
    /// 响应结果
    /// </summary>
    public class ResponseModel
    {
        //响应状态码
        public ResponseCode code { get; set; }
        /// <summary>
        /// 响应消息
        /// </summary>
        public string message { get; set; }
    }
    /// <summary>
    /// 有对象的响应结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseModel<T> : ResponseModel
    {
        public T data { get; set; }
    }

    public enum ResponseCode
    {
        Success = 0,
        Fail = 1
    }

    public static class ResponseExtend
    {
        public static ResponseModel SetSuccess(this ResponseModel response, string message = "")
        {
            ResponseModel result = new ResponseModel();
            result.code = ResponseCode.Success;
            result.message = message == string.Empty ? "操作成功" : message;
            return result;
        }
        public static ResponseModel<T> SetSuccess<T>(this ResponseModel<T> response, T data = default(T), string message = "")
        {
            response.code = ResponseCode.Success;
            response.message = message == string.Empty ? "操作成功" : message;
            response.data = data;
            return response;
        }
        public static ResponseModel SetFail(this ResponseModel response, string message = "")
        {
            response.code = ResponseCode.Fail;
            response.message = message == string.Empty ? "操作失败" : message;
            return response;
        }
        public static ResponseModel<T> SetFail<T>(this ResponseModel<T> response, string message = "", T data = default(T))
        {
            response.code = ResponseCode.Fail;
            response.message = message == string.Empty ? "操作成功" : message;
            response.data = data;
            return response;
        }

    }
}
