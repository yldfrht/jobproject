using App.Business.Abstract;
using App.Core.Caching;
using App.Core.Result;
using App.DataAccess.Abstract;
using App.Entity.Dtos;
using App.Entity.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
    public class CategoryManager(IUnitOfWork unitOfWork, IMapper mapper, ICacheService redis) : ICategoryService
    {
        private readonly string cacheKey = "categories";

        public async Task<ServiceResult<List<CategoryResponseDto>>> GetAllAsync(Expression<Func<CategoryRequestDto, bool>>? filter)
        {
            var cachedList = await redis.GetAsync<List<CategoryResponseDto>>(cacheKey);
            if (cachedList is not null)
            {
                return ServiceResult<List<CategoryResponseDto>>.Success(cachedList, HttpStatusCode.OK, "Data redisten başarıyla getirildi.");
            }

            var entityFilter = mapper.Map<Expression<Func<Category, bool>>>(filter);
            var entity = await unitOfWork.Repository<Category>().GetAllAsync(entityFilter);

            var response = mapper.Map<List<CategoryResponseDto>>(entity);
            await redis.SetAsync(cacheKey, response, TimeSpan.FromDays(1));

            return ServiceResult<List<CategoryResponseDto>>.Success(response, HttpStatusCode.OK, "Data dbden redise kaydedilip başarıyla getirildi.");
        }

        public async Task<ServiceResult<CategoryResponseDto>> GetByIdAsync(int id, Expression<Func<CategoryRequestDto, bool>>? filter)
        {
            var cachedList = await redis.GetAsync<List<CategoryResponseDto>>(cacheKey);
            var cached = cachedList.FirstOrDefault(x => x.Id == id);
            if (cached is not null)
            {
                return ServiceResult<CategoryResponseDto>.Success(cached, HttpStatusCode.OK, "Data redisten başarıyla getirildi.");
            }

            var entityFilter = mapper.Map<Expression<Func<Category, bool>>>(filter);
            var entity = await unitOfWork.Repository<Category>().GetByIdAsync(id, entityFilter);
            if (entity is not null)
            {
                var response = mapper.Map<CategoryResponseDto>(entity);
                return ServiceResult<CategoryResponseDto>.Success(response, HttpStatusCode.OK, "Data dbden başarıyla getirildi.");
            }

            return ServiceResult<CategoryResponseDto>.Fail(HttpStatusCode.NotFound, "Data bulunamadı.");
        }

        public async Task<ServiceResult<bool>> AnyAsync(Expression<Func<CategoryRequestDto, bool>>? filter)
        {
            bool exist = false;
            var cachedList = await redis.GetAsync<List<CategoryRequestDto>>(cacheKey);
            if (cachedList is not null)
            {
                exist = cachedList.Any(filter.Compile());
            }
            else
            {
                var entityFilter = mapper.Map<Expression<Func<Category, bool>>>(filter);
                exist = await unitOfWork.Repository<Category>().AnyAsync(entityFilter);
            }

            return ServiceResult<bool>.Success(exist, HttpStatusCode.OK, "");
        }

        public async Task<ServiceResult<CategoryResponseDto>> AddAsync(CategoryRequestDto request)
        {
            var exist = await unitOfWork.Repository<Category>().AnyAsync(x => x.Name == request.Name);
            if (exist)
            {
                return ServiceResult<CategoryResponseDto>.Fail(HttpStatusCode.BadRequest, "Data dbde zaten mevcut.");
            }

            var entity = mapper.Map<Category>(request);
            await unitOfWork.Repository<Category>().AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            var response = mapper.Map<CategoryResponseDto>(entity);

            return ServiceResult<CategoryResponseDto>.Success(response, HttpStatusCode.OK, "Data başarıyla eklendi.");
        }

        public async Task<ServiceResult> UpdateAsync(CategoryRequestDto request)
        {
            var exist = await AnyAsync(x => x.Id == request.Id && x.Name == request.Name);
            if (!exist.Data)
            {
                return ServiceResult.Fail(HttpStatusCode.NotFound, "Data bulunamadı.");
            }

            var entity = mapper.Map<Category>(request);
            unitOfWork.Repository<Category>().Update(entity);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.OK, "Başarıyla güncellendi.");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var responseDto = await GetByIdAsync(id, null);
            if (!responseDto.IsSuccess)
            {
                return ServiceResult.Fail(HttpStatusCode.NotFound, "Data bulunamadı.");
            }

            var entity = mapper.Map<Category>(responseDto);
            unitOfWork.Repository<Category>().Delete(entity);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.OK, "Başarıyla silindi.");
        }
    }
}
