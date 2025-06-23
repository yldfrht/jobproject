using App.Business.Abstract;
using App.Business.Result;
using App.DataAccess.Concrete;
using App.Domain.Dtos.Randevu;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandevuController(IRandevuService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllListAsync() => Ok(await service.GetAllListAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RandevuCreateDto createDto) => Ok(await service.CreateAsync(createDto));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, RandevuUpdateDto updateDto) => Ok(await service.UpdateAsync(id, updateDto));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id) => Ok(await service.DeleteAsync(id));
    }
}
