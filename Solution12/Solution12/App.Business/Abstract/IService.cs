using App.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Abstract
{
    public interface IService<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        Task<ServiceResult<List<TResponse>>> GetAllAsync(Expression<Func<TRequest, bool>>? filter);
        Task<ServiceResult<TResponse>> GetByIdAsync(int id, Expression<Func<TRequest, bool>>? filter);

        Task<ServiceResult<bool>> AnyAsync(Expression<Func<TRequest, bool>>? filter);

        Task<ServiceResult<TResponse>> AddAsync(TRequest request);
        Task<ServiceResult> UpdateAsync(TRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
