using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatigaEmt7an.Api.Interfaces.IRepositories;
using NatigaEmt7an.Api.Repositories;

namespace NatigaEmt7an.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationsController : ControllerBase
    {
        private readonly ISchoolAdministrationsRepository schoolAdministrationsRepository;

        public AdministrationsController(ISchoolAdministrationsRepository schoolAdministrationsRepository)
        {
            this.schoolAdministrationsRepository = schoolAdministrationsRepository;
        }
        [HttpGet("drop-list/{governorateId:guid}")]
        public async Task<IActionResult> GetDropList([FromRoute] Guid governorateId)
        {
            var administrations = await schoolAdministrationsRepository.GetDropListAsync(governorateId);
            return Ok(administrations);
        }
    }
}
