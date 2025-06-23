using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Abstract
{
    public interface IBransRepository : IRepository<Bran>
    {
        Task<Bran?> GetBransByHastaneIdAsync(int hastaneId);
    }
}
