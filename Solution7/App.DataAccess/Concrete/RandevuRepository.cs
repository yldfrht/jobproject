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
    public class RandevuRepository(PostgreContext context) : Repository<Randevu>(context), IRandevuRepository
    {
        public async Task<bool> IsHekimAvailableAsync(int? hastaneId, int hekimId, DateOnly randevuZamani)
        {
            return !await context.Randevus
                .AnyAsync(r => r.Hastaneid == hastaneId && r.Hekimid == hekimId && r.Randevuzamani == randevuZamani);
        }
    }
}
