using App.Business.Abstract;
using App.Business.Result;
using App.DataAccess.Abstract;
using App.Domain.Dtos.Brans;
using App.Domain.Dtos.Randevu;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
    public class RandevuService(IRandevuRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IRandevuService
    {
        public async Task<ServiceResult<List<RandevuDto>>> GetAllListAsync()
        {
            var randevus = await repository.GetAllAsync();
            var randevuDtos = mapper.Map<List<RandevuDto>>(randevus);

            return ServiceResult<List<RandevuDto>>.Success(randevuDtos, HttpStatusCode.OK, null);
        }

        public async Task<ServiceResult<RandevuDto>> GetByIdAsync(int id)
        {
            var randevu = await repository.GetByIdAsync(id);
            if (randevu is null)
            {
                return ServiceResult<RandevuDto>.Fail(HttpStatusCode.NotFound, [$"Randevu bulunamadı."]);
            }

            var randevuDto = mapper.Map<RandevuDto>(randevu);

            return ServiceResult<RandevuDto>.Success(randevuDto, HttpStatusCode.OK, [$"{id} nolu randevu dbden başarıyla getirildi."]);
        }

        public async Task<ServiceResult<int>> CreateAsync(RandevuCreateDto createDto)
        {
            var available = await repository.IsHekimAvailableAsync(createDto.Hastaneid, createDto.Hekimid, createDto.RandevuZamani);
            if (available!)
            {
                return ServiceResult<int>.Fail(HttpStatusCode.BadRequest, [$"Randevunuz oluşturulamadı.", $"Lütfen tekrar deneyiniz."]);
            }

            var randevu = mapper.Map<Randevu>(createDto);
            await repository.AddAsync(randevu);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.Success(randevu.Id, HttpStatusCode.Created, [$"Randevunuz oluşturuldu."]);
        }

        public async Task<ServiceResult> UpdateAsync(int id, RandevuUpdateDto updateDto)
        {
            var randevu = await repository.GetByIdAsync(id);

            var randevu2 = mapper.Map<Randevu>(updateDto);
            repository.Update(randevu2);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.OK, [$"Başarıyla güncellendi."]);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var randevu = await repository.GetByIdAsync(id);

            if (randevu is null)
            {
                return ServiceResult.Fail(HttpStatusCode.NotFound, [$"{id} nolu randevu bulunamadı."]);
            }

            repository.Delete(randevu);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.OK, [$"Başarıyla silindi."]);
        }
    }
}
