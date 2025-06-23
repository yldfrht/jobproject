using App.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController(IBransService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBranches() => Ok(await service.GetAllListAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBranch(int id) => Ok(await service.GetByIdAsync(id));
    }
}
