using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatigaEmt7an.Api.Interfaces.IRepositories;

namespace NatigaEmt7an.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolRepository schoolRepository;

        public SchoolsController(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }
        [HttpGet("drop-list/{schoolAdministrationId:guid}")]
        public async Task<IActionResult> GetDropList([FromRoute] Guid schoolAdministrationId) {
            var schools = await schoolRepository.GetDropListAsync(schoolAdministrationId);
            return Ok(schools);
        }
    }
}
