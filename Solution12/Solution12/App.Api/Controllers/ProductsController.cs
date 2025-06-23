using App.Business.Abstract;
using App.Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService service) : GenericController<ProductRequestDto, ProductResponseDto>(service)
    {
    }
}
