using App.DataAccess.Abstract;
using App.DataAccess.Context;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Concrete
{
    public class BransRepository(PostgreContext context) : Repository<Bran>(context), IBransRepository
    {
        public Task<Bran?> GetBransByHastaneIdAsync(int hastaneId)
        {
            return context.Brans.Include(x => x.Hastaneid).FirstOrDefaultAsync(x => x.Id == hastaneId);
        }
    }
}
