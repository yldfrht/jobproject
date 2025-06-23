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
    public class HastaRepository(PostgreContext context) : Repository<Hastum>(context), IHastaRepository
    {
        public Task<List<Hastum>> GetHastasWithHekimIdAsync(int hekimId)
        {
            return context.Hasta.Include(x => x.Randevu).Where(x => x.Randevu.Hekimid == hekimId).ToListAsync();
        }
    }
}
