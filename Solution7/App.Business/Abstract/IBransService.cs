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
    public interface IBransService
    {
        Task<ServiceResult<List<BransDto>>> GetAllListAsync();
        Task<ServiceResult<BransDto>> GetByIdAsync(int id);

        Task<ServiceResult<int>> CreateAsync(BransCreateDto createDto);
        Task<ServiceResult> UpdateAsync(int id, BransUpdateDto updateDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
