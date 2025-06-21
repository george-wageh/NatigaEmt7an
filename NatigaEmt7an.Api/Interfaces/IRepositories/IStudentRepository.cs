using NatigaEmt7an.Contracts.Requests.Student;
using NatigaEmt7an.Contracts.Responses.Student;
using NatigaEmt7an.Contracts.Responses;

namespace NatigaEmt7an.Api.Interfaces.IRepositories
{
    public interface IStudentRepository
    {
        Task<PageList<StudentListResponse>> GetStudentsAsync(StudentListRequst studentListRequst);
        Task<List<StudentListResponse>> GetTopStudentsAsync(StudentsRequst studentsRequst);
        Task<StudentDetailsResponse?> GetStudentDetailAsync(Guid id);
        Task<StudentStatisticsResponse> GetStatisticsAsync(StudentsRequst studentsRequst);
    }
}
