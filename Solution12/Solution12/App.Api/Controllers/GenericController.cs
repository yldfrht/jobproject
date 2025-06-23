using App.Business.Abstract;
using App.Core.Result;
using App.Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TRequest, TResponse>(IService<TRequest, TResponse> service) : ControllerBase where TRequest : class where TResponse : class
    {
        [HttpGet("GetAllFilter")]
        public async Task<IActionResult> GetAllAsync([FromQuery] Expression<Func<TRequest, bool>>? filter)
        {
            var result = await service.GetAllAsync(filter);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, [FromQuery] Expression<Func<TRequest, bool>>? filter)
        {
            var result = await service.GetByIdAsync(id, filter);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TRequest request)
        {
            var result = await service.AddAsync(request);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(TRequest request)
        {
            var result = await service.UpdateAsync(request);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await service.DeleteAsync(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
