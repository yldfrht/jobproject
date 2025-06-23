using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Business.Result
{
    public class ServiceResult<T> : IServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? Message { get; set; }
        [JsonIgnore] public HttpStatusCode Status { get; set; }
        [JsonIgnore] public bool IsSuccess { get; set; }

        public static ServiceResult<T> Success(T data, HttpStatusCode status, List<string>? message = null, bool isSuccess = true)
        {
            return new ServiceResult<T>
            {
                Data = data,
                IsSuccess = isSuccess,
                Message = message,
                Status = status
            };
        }
        public static ServiceResult<T> Fail(HttpStatusCode status, List<string>? message = null, bool isSuccess = false)
        {
            return new ServiceResult<T>
            {
                IsSuccess = isSuccess,
                Message = message,
                Status = status
            };
        }
    }

    public class ServiceResult : IServiceResult
    {
        public List<string>? Message { get; set; }
        [JsonIgnore] public HttpStatusCode Status { get; set; }
        [JsonIgnore] public bool IsSuccess { get; set; }

        public static ServiceResult Success(HttpStatusCode status, List<string>? message = null, bool isSuccess = true)
        {
            return new ServiceResult
            {
                IsSuccess = isSuccess,
                Message = message,
                Status = status
            };
        }
        public static ServiceResult Fail(HttpStatusCode status, List<string>? message = null, bool isSuccess = false)
        {
            return new ServiceResult
            {
                IsSuccess = isSuccess,
                Message = message,
                Status = status
            };
        }
    }
}
