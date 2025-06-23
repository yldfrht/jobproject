using App.Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Abstract
{
    public interface ICategoryService : IService<CategoryRequestDto, CategoryResponseDto>
    {
    }
}
