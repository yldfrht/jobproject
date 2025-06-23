using App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter);
        Task<T?> GetByIdAsync(int id, Expression<Func<T, bool>>? filter);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? filter);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}