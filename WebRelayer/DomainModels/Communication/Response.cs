using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebRelayer.DomainModels.Communication
{
    public class Response<T> : BaseResponse
    {
        protected Response(bool success, string message, HttpStatusCode status, T data)
            :base(success, message, status)
        {
            Data = data;
        }

        public T Data { get; set; }

        public static Response<T> Ok<T>(T data, HttpStatusCode status = HttpStatusCode.OK)
            => new Response<T>(true, string.Empty, status, data);

        public static Response<T> Fail<T>(string message, HttpStatusCode status)
            => new Response<T>(false, message, status, default(T));

        public static implicit operator bool(Response<T> response) => response.Success;

        public static explicit operator int(Response<T> response) => (int)response.Status;
    }
}
