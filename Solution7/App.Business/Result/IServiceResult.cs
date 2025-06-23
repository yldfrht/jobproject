using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Result
{
    public interface IServiceResult<T> : IServiceResult
    {
        T? Data { get; set; }
    }

    public interface IServiceResult
    {
        List<string>? Message { get; set; }
        HttpStatusCode Status { get; set; }
        bool IsSuccess { get; set; }
    }
}
