using App.Business.Result;
using App.Domain.Dtos;
using App.Domain.Dtos.Brans;
using App.Domain.Dtos.Randevu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Abstract
{
    public interface IRandevuService
    {
        Task<ServiceResult<List<RandevuDto>>> GetAllListAsync();
        Task<ServiceResult<RandevuDto>> GetByIdAsync(int id);

        Task<ServiceResult<int>> CreateAsync(RandevuCreateDto createDto);
        Task<ServiceResult> UpdateAsync(int id, RandevuUpdateDto updateDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
