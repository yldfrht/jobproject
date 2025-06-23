using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Result
{
    public interface IServiceResult
    {
        string Message { get; set; }
        HttpStatusCode StatusCode { get; set; }
        bool IsSuccess { get; set; }
    }

    public interface IServiceResult<T> : IServiceResult
    {
        T? Data { get; set; }
    }
}
