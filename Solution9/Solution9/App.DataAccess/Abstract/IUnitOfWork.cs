using App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();

        IRepository<Product>? Products { get; }
        IRepository<Category>? Categories { get; }
    }
}
