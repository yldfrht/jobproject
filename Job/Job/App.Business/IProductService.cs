using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business
{
    public interface IProductService
    {
        Task<List<Product>> GetAllsAsync();
    }
}
