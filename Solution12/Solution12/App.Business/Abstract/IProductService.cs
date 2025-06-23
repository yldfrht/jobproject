using App.Core.Result;
using App.Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Abstract
{
    public interface IProductService : IService<ProductRequestDto, ProductResponseDto>
    {
    }
}
