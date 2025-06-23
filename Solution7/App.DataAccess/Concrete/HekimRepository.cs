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
    public class HekimRepository(PostgreContext context) : Repository<Hekim>(context), IHekimRepository
    {
        public Task<List<Hekim?>> GetHekimsWithBransesAsync()
        {
            return context.Hekims.Include(x => x.Bransid).ToListAsync();
        }
    }
}
