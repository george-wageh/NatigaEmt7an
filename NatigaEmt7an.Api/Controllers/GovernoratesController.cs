using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatigaEmt7an.Api.Interfaces.IRepositories;
using NatigaEmt7an.Api.Repositories;

namespace NatigaEmt7an.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernoratesController : ControllerBase
    {
        private readonly IGovernorateRepository governorateRepository;

        public GovernoratesController(IGovernorateRepository governorateRepository)
        {
            this.governorateRepository = governorateRepository;
        }

        [HttpGet("drop-list")]
        public async Task<IActionResult> GetDropList()
        {
            var governorates = await governorateRepository.GetDropListAsync();
            return Ok(governorates);
        }
    }
}
