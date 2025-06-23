using App.Business.Abstract;
using App.Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService service) : GenericController<CategoryRequestDto, CategoryResponseDto>(service)
    {
    }
}
