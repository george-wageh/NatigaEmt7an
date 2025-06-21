using Microsoft.EntityFrameworkCore;
using NatigaEmt7an.Api.Data;
using NatigaEmt7an.Api.Helper;
using NatigaEmt7an.Api.Interfaces.IRepositories;
using NatigaEmt7an.Contracts.Requests;
using NatigaEmt7an.Contracts.Requests.Student;
using NatigaEmt7an.Contracts.Responses;
using NatigaEmt7an.Contracts.Responses.Student;
using NatigaEmt7an.Models.Enums;
using NatigaEmt7an.Models.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NatigaEmt7an.Api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IQueryable<Student> AddFilters(IQueryable<Student> studentsQuery, StudentListRequst studentListRequst) {
            if (studentListRequst.GovernorateId != null)
            {
                studentsQuery = studentsQuery.Where(x => x.GovernorateId == studentListRequst.GovernorateId);
            }
            if (studentListRequst.SchoolAdministrationId != null)
            {
                studentsQuery = studentsQuery.Where(x => x.SchoolAdministrationId == studentListRequst.SchoolAdministrationId);
            }
            if (studentListRequst.SchoolId != null)
            {
                studentsQuery = studentsQuery.Where(x => x.SchoolId == studentListRequst.SchoolId);
            }
            if (studentListRequst.SeatNum != null)
            {
                studentsQuery = studentsQuery.Where(x => x.SeatNumber == studentListRequst.SeatNum);
            }
            if (studentListRequst.StudentName != null)
            {
                studentsQuery = studentsQuery.Where(x => x.Name.Contains(studentListRequst.StudentName));
            }
            return studentsQuery;
        }
        private IQueryable<Student> AddFilters(IQueryable<Student> studentsQuery, StudentsRequst studentsRequst)
        {
            if (studentsRequst.GovernorateId != null)
            {
                studentsQuery = studentsQuery.Where(x => x.GovernorateId == studentsRequst.GovernorateId);
            }
            if (studentsRequst.SchoolAdministrationId != null)
            {
                studentsQuery = studentsQuery.Where(x => x.SchoolAdministrationId == studentsRequst.SchoolAdministrationId);
            }
            if (studentsRequst.SchoolId != null)
            {
                studentsQuery = studentsQuery.Where(x => x.SchoolId == studentsRequst.SchoolId);
            }
            if (studentsRequst.Category != null)
            {
                studentsQuery = studentsQuery.Where(x => x.Category == studentsRequst.Category);
            }
            return studentsQuery;
        }
        public async Task<PageList<StudentListResponse>> GetStudentsAsync(StudentListRequst studentListRequst) {
            var studentsQuery = _dbContext.Students.AsQueryable();
            studentsQuery = AddFilters(studentsQuery , studentListRequst);
            var studentsMapped = studentsQuery.Select(x => new StudentListResponse
            {
                Id = x.Id,
                Category = x.Category,
                Name = x.Name,
                SeatNumber = x.SeatNumber,
                Status = x.Status,
                TotalGrades = x.TotalGrades
            }).OrderBy(x => x.SeatNumber);
            return await studentsMapped.MapPageList(studentListRequst.PageNumber, studentListRequst.PageSize);
        }

        public async Task<StudentDetailsResponse?> GetStudentDetailAsync(Guid id)
        {
            var student = await _dbContext.Students.Select(x => new StudentDetailsResponse
            {
                Id = x.Id,
                Category = x.Category,
                Name = x.Name,
                AdministrationName = x.SchoolAdministration.Name,
                SchoolName = x.School.Name,
                Status = x.Status,
                SeatNumber = x.SeatNumber,
                TotalGrades = x.TotalGrades,
                Grades = new GradesResponse
                {
                    Ar = x.StudentGrade.Ar,
                    Foreign1 = x.StudentGrade.Foreign1,
                    Foreign2 = x.StudentGrade.Foreign2,
                    Math1 = x.StudentGrade.Math1,
                    Math2 = x.StudentGrade.Math2,
                    History = x.StudentGrade.History,
                    Geography = x.StudentGrade.Geography,
                    Philosophy = x.StudentGrade.Philosophy,
                    Psychology = x.StudentGrade.Psychology,
                    Chemistry = x.StudentGrade.Chemistry,
                    Biology = x.StudentGrade.Biology,
                    Geology = x.StudentGrade.Geology,
                    Physics = x.StudentGrade.Physics
                },
                OutGrades = new Contracts.Responses.Student.OutCourses
                {
                    EconomicsStatistics = x.StudentGrade.OutCourses.EconomicsStatistics,
                    NationalEdu = x.StudentGrade.OutCourses.NationalEdu,
                    ReligionEdu = x.StudentGrade.OutCourses.ReligionEdu
                }
            }).FirstOrDefaultAsync(x=>x.Id == id);
            return student;
        }

        public async Task<List<StudentListResponse>> GetTopStudentsAsync(StudentsRequst studentsRequst)
        {
            var studentsQuery = _dbContext.Students.AsQueryable();
            studentsQuery = AddFilters(studentsQuery, studentsRequst);
            var studentsMapped = await studentsQuery.Select(x => new StudentListResponse
            {
                Id = x.Id,
                Category = x.Category,
                Name = x.Name,
                SeatNumber = x.SeatNumber,
                Status = x.Status,
                TotalGrades = x.TotalGrades
            }).OrderByDescending(x => x.TotalGrades)
            .Skip(0)
            .Take(50)
            .ToListAsync();
            return studentsMapped;
        }

        public async Task<StudentStatisticsResponse> GetStatisticsAsync(StudentsRequst studentsRequst)
        {
            var studentsQuery = _dbContext.Students.AsQueryable().AsSplitQuery().AsNoTracking();
            studentsQuery = AddFilters(studentsQuery, studentsRequst);

            var students = await studentsQuery.Select(x=> new { x.TotalGrades , x.Status, x.Category }).ToListAsync();
            var gradeClassifications = students
                .GroupBy(s => s.Category)
                .Select(g => new GradeClassification
                {
                    Category = g.Key,
                    G_410_369 = g.Count(x => x.TotalGrades > 369 && x.TotalGrades <= 410),
                    G_369_349 = g.Count(x => x.TotalGrades > 349 && x.TotalGrades <= 369),
                    G_349_308 = g.Count(x => x.TotalGrades > 308 && x.TotalGrades <= 349),
                    G_308_246 = g.Count(x => x.TotalGrades > 246 && x.TotalGrades <= 308),
                    G_246_205 = g.Count(x => x.TotalGrades > 205 && x.TotalGrades <= 246),
                    G_205_0 = g.Count(x => x.TotalGrades <= 205)
                }).ToList();

            gradeClassifications.Add(new GradeClassification
            {
                Category = null,
                G_410_369 = gradeClassifications.Sum(x => x.G_410_369),
                G_369_349 = gradeClassifications.Sum(x => x.G_369_349),
                G_349_308 = gradeClassifications.Sum(x => x.G_349_308),
                G_308_246 = gradeClassifications.Sum(x => x.G_308_246),
                G_246_205 = gradeClassifications.Sum(x => x.G_246_205),
                G_205_0 = gradeClassifications.Sum(x => x.G_205_0),

            });

            var statusClassifications = students
                .GroupBy(x => x.Category)
                .Select(x => new StatusCategory
                {
                    Category = x.Key,
                    PassedCount = x.Where(x => x.Status == StudentStatus.Passed).Count(),
                    FailedCount = x.Where(x => x.Status == StudentStatus.Failed).Count(),
                    SecondRoundCount = x.Where(x => x.Status == StudentStatus.SecondRound).Count()
                }).ToList();

            statusClassifications.Add(new StatusCategory
            {
                Category = null,
                FailedCount = statusClassifications.Sum(x => x.FailedCount),
                PassedCount = statusClassifications.Sum(x => x.PassedCount),
                SecondRoundCount = statusClassifications.Sum(x => x.SecondRoundCount)
            });
            students = null;
            return new StudentStatisticsResponse { 
                GradeClassifications = gradeClassifications,
                StatusClassifications = statusClassifications
            };
        }
    }
}
