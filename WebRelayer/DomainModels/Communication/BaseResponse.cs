using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebRelayer.DomainModels.Communication
{
    public class BaseResponse
    {
        public bool Success { get; }
        public string Message { get; }
        public HttpStatusCode Status { get; }

        protected BaseResponse(bool success, string message, HttpStatusCode status)
        {
            Success = success;
            Message = message;
            Status = status;
        }

        public static BaseResponse Ok(HttpStatusCode status = HttpStatusCode.OK) 
            => new BaseResponse(true, string.Empty, status);

        public static BaseResponse Fail(string message, HttpStatusCode status)
            => new BaseResponse(false, message, status);

        public static implicit operator bool(BaseResponse response) => response.Success;

        public static explicit operator int(BaseResponse response) => (int)response.Status;
    }
}
