using App.Business.Abstract;
using App.Business.Caching;
using App.Business.Result;
using App.DataAccess.Abstract;
using App.Domain.Dtos.Brans;
using App.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
    public class BransService(IBransRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService) : IBransService
    {
        private const string cacheKey = "branches";

        public async Task<ServiceResult<List<BransDto>>> GetAllListAsync()
        {
            //1. Rediste var mı?
            var cached = await cacheService.GetAsync<List<BransDto>>(cacheKey);
            if (cached is not null)
            {
                return ServiceResult<List<BransDto>>.Success(cached, HttpStatusCode.OK, [$"Branşlar Redisten başarıyla alındı."]);
            }

            //2. Rediste yoksa veritabanından al ve 1 saat süreyle Redise yaz.
            var branches = repository.GetAllAsync();
            var branchesDto = mapper.Map<List<BransDto>>(branches);
            await cacheService.SetAsync(cacheKey, branches, TimeSpan.FromHours(1));

            return ServiceResult<List<BransDto>>.Success(branchesDto, HttpStatusCode.OK, [$"Branşlar veritabanından Redise kaydedildi ve Redisten başarıyla alındı."]);
        }

        public async Task<ServiceResult<BransDto>> GetByIdAsync(int id)
        {
            var cached = await cacheService.GetAsync<BransDto>(cacheKey);
            if (cached is not null)
            {
                return ServiceResult<BransDto>.Success(cached, HttpStatusCode.OK, [$"Branş Redisten başarıyla alındı."]);
            }

            var branch = repository.GetByIdAsync(id);
            var branchDto = mapper.Map<BransDto>(branch);

            //3. Redise yaz (1 saatlik süreyle).
            await cacheService.SetAsync(cacheKey, branch, TimeSpan.FromHours(1));

            return ServiceResult<BransDto>.Success(branchDto, HttpStatusCode.OK, [$"Branş veritabanından Redise kaydedildi ve Redisten başarıyla alındı."]);
        }

        public async Task<ServiceResult<int>> CreateAsync(BransCreateDto createDto)
        {
            try
            {
                var branch = mapper.Map<Bran>(createDto);
                await repository.AddAsync(branch);
                await unitOfWork.SaveChangesAsync();

                return ServiceResult<int>.Success(branch.Id, HttpStatusCode.Created, ["Branş başarıyla eklendi."]);
            }
            catch (Exception ex)
            {
                return ServiceResult<int>.Fail(HttpStatusCode.BadRequest, [$"Branş eklenemedi: {ex.Message}"]);
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, BransUpdateDto updateDto)
        {
            var branch = await repository.GetByIdAsync(id);
            if (branch is null)
            {
                return ServiceResult.Fail(HttpStatusCode.NotFound, [$"Branş bulunamadı."]);
            }

            var branch2 = mapper.Map<Bran>(updateDto);
            repository.Update(branch2);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.OK, ["Branş başarıyla güncellendi."]);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var branch = await repository.GetByIdAsync(id);
            if (branch is null)
            {
                return ServiceResult.Fail(HttpStatusCode.NotFound, [$"Branş bulunamadı."]);
            }

            repository.Delete(branch);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.OK, ["Branş başarıyla silindi."]);
        }
    }
}
