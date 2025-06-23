using App.DataAccess.Abstract;
using App.DataAccess.Context;
using App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Concrete
{
    public class UnitOfWork(PostgreContext context) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
        public void Dispose() => context.Dispose();


        public IRepository<Product>? Products => new Repository<Product>(context);
        public IRepository<Category>? Categories => new Repository<Category>(context);
    }
}
