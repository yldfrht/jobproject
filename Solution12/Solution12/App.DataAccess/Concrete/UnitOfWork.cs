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
        private readonly IDictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public void Dispose() => context.Dispose();
        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();


        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repoInstance = new Repository<T>(context);
                _repositories.Add(typeof(T), repoInstance);
            }
            return (IRepository<T>)_repositories[typeof(T)];
        }


        //public IRepository<Product> Products => new Repository<Product>(context);
        //public IRepository<Category> Categories => new Repository<Category>(context);

    }
}
