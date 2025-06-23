using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Result
{
    public class ServiceResult : IServiceResult
    {
        public string Message { get; set; } = null!;
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }


        public static ServiceResult Success(HttpStatusCode statusCode = HttpStatusCode.OK, string message = "", bool isSuccess = true)
        {
            return new ServiceResult { StatusCode = statusCode, Message = message, IsSuccess = isSuccess };
        }
        public static ServiceResult Fail(HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "", bool isSuccess = false)
        {
            return new ServiceResult { StatusCode = statusCode, Message = message, IsSuccess = isSuccess };
        }
    }

    public class ServiceResult<T> : IServiceResult<T>
    {
        public string Message { get; set; } = null!;
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }

        public static ServiceResult<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string message = "", bool isSuccess = true)
        {
            return new ServiceResult<T> { Data = data, StatusCode = statusCode, Message = message, IsSuccess = isSuccess };
        }
        public static ServiceResult<T> Fail(HttpStatusCode statusCode = HttpStatusCode.OK, string message = "", bool isSuccess = false)
        {
            return new ServiceResult<T> { StatusCode = statusCode, Message = message, IsSuccess = isSuccess };
        }
    }
}
