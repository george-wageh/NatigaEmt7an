using Microsoft.AspNetCore.Mvc;
using NatigaEmt7an.Api.Interfaces.IRepositories;
using NatigaEmt7an.Contracts.Requests.Student;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NatigaEmt7an.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
           _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]StudentListRequst studentListRequst)
        {
            var students =  await _studentRepository.GetStudentsAsync(studentListRequst);
            return Ok(students);
        }
        [HttpGet("Top")]
        public async Task<IActionResult> GetTopStudents([FromQuery]StudentsRequst studentsRequst) 
        {
            var students = await _studentRepository.GetTopStudentsAsync(studentsRequst);
            return Ok(students);
        }
        [HttpGet("Statistics")]
        public async Task<IActionResult> GetStatistics([FromQuery] StudentsRequst studentsRequst)
        {
            var students = await _studentRepository.GetStatisticsAsync(studentsRequst);
            return Ok(students);
        }
        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetDetails([FromRoute] Guid Id)
        {
            var student = await _studentRepository.GetStudentDetailAsync(Id);
            if (student != null)
                return Ok(student);
            else
                return NotFound();
        }

    }
}
