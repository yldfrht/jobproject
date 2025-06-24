using App.DataAccess;
using App.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business
{
    public class ProductService(AppDbContext context) : IProductService
    {
        private readonly DbSet<Product> _dbSet = context.Set<Product>();

        public async Task<List<Product>> GetAllsAsync()
        {
            return await _dbSet.Include(x => x.Category).ToListAsync();
        }
    }
}
