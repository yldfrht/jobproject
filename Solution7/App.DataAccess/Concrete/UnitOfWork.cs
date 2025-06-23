using App.DataAccess.Abstract;
using App.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Concrete
{
    public class UnitOfWork(PostgreContext context) : IUnitOfWork
    {
        public void Dispose() => context.Dispose();

        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
    }
}
