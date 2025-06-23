using App.DataAccess.Abstract;
using App.DataAccess.Context;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Concrete
{
    public class HastaneRepository(PostgreContext context) : Repository<Hastane>(context), IHastaneRepository
    {
    }
}
