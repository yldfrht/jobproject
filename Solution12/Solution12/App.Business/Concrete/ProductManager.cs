using App.Business.Abstract;
using App.Entity.Dtos;
using App.Core.Result;
using App.DataAccess.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using App.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using App.Entity.Entities;

namespace App.Business.Concrete
{
    public class ProductManager(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        public async Task<ServiceResult<List<ProductResponseDto>>> GetAllAsync(Expression<Func<ProductRequestDto, bool>>? filter)
        {
            var entityFilter = mapper.Map<Expression<Func<Product, bool>>>(filter);
            var entity = await unitOfWork.Repository<Product>().GetAllAsync(entityFilter);
            if (entity is null)
            {
                return ServiceResult<List<ProductResponseDto>>.Fail(HttpStatusCode.OK, "Data bulunamadı.");
            }

            var response = mapper.Map<List<ProductResponseDto>>(entity);

            return ServiceResult<List<ProductResponseDto>>.Success(response, HttpStatusCode.OK, "Data başarıyla getirildi.");
        }

        public async Task<ServiceResult<ProductResponseDto>> GetByIdAsync(int id, Expression<Func<ProductRequestDto, bool>>? filter)
        {
            var entityFilter = mapper.Map<Expression<Func<Product, bool>>>(filter);
            var entity = await unitOfWork.Repository<Product>().GetByIdAsync(id, entityFilter);
            if (entity is null)
            {
                return ServiceResult<ProductResponseDto>.Fail(HttpStatusCode.OK, "Data bulunamadı.");
            }

            var response = mapper.Map<ProductResponseDto>(entity);

            return ServiceResult<ProductResponseDto>.Success(response, HttpStatusCode.OK, "Data başarıyla getirildi.");
        }

        public async Task<ServiceResult<bool>> AnyAsync(Expression<Func<ProductRequestDto, bool>>? filter)
        {
            var entityFilter = mapper.Map<Expression<Func<Product, bool>>>(filter);
            var exist = await unitOfWork.Repository<Product>().AnyAsync(entityFilter);

            return ServiceResult<bool>.Success(exist, HttpStatusCode.OK, "");
        }


        public async Task<ServiceResult<ProductResponseDto>> AddAsync(ProductRequestDto request)
        {
            var exist = await AnyAsync(x => x.CategoryId == request.CategoryId && x.Name == request.Name);
            if (exist.Data)
            {
                return ServiceResult<ProductResponseDto>.Fail(HttpStatusCode.BadRequest, "Data zaten kayıtlı.");
            }

            var entity = mapper.Map<Product>(request);
            await unitOfWork.Repository<Product>().AddAsync(entity);
            await unitOfWork.SaveChangesAsync();

            var category = await unitOfWork.Repository<Category>().GetByIdAsync(request.CategoryId, null);
            if (category is null)
            {
                return ServiceResult<ProductResponseDto>.Fail(HttpStatusCode.NotFound, "Kategori bulunamadı.");
            }

            var response = new ProductResponseDto(entity.Id, entity.Name, category.Name);

            return ServiceResult<ProductResponseDto>.Success(response, HttpStatusCode.BadRequest, "Data başarıyla eklendi.");
        }

        public async Task<ServiceResult> UpdateAsync(ProductRequestDto request)
        {
            var exist = await AnyAsync(x => x.CategoryId == request.CategoryId && x.Name == request.Name);
            if (!exist.IsSuccess)
            {
                return ServiceResult.Fail(HttpStatusCode.NotFound, "Data bulunamadı.");
            }

            var entity = mapper.Map<Product>(request);
            unitOfWork.Repository<Product>().Update(entity);
            await unitOfWork.SaveChangesAsync();
            var response = mapper.Map<ProductResponseDto>(request);

            return ServiceResult.Success(HttpStatusCode.OK, "Data başarıyla güncellendi.");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var responseDto = await GetByIdAsync(id, null);
            if (!responseDto.IsSuccess)
            {
                return ServiceResult.Fail(HttpStatusCode.NotFound, "Data bulunamadı.");
            }

            var entity = mapper.Map<Product>(responseDto);
            unitOfWork.Repository<Product>().Delete(entity);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.OK, "Başarıyla silindi.");
        }
    }
}
