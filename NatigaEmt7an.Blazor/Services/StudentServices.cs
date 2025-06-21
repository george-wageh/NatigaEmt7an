using Microsoft.AspNetCore.WebUtilities;
using NatigaEmt7an.Contracts.Requests.Student;
using NatigaEmt7an.Contracts.Responses;
using NatigaEmt7an.Contracts.Responses.Student;
using NewsBlazorAppAdmin.Services;

namespace NatigaEmt7an.Blazor.Services
{
    public class StudentServices
    {
        private readonly ApiServices _apiServices;

        public StudentServices(ApiServices apiServices)
        {
            _apiServices = apiServices;
        }

        public async Task<PageList<StudentListResponse>> GetStudents(StudentListRequst studentList) 
        {
           return await _apiServices.GetJsonAsync<PageList<StudentListResponse>>("Students", studentList);
        }
        public async Task<List<StudentListResponse>> GetTopStudents(StudentsRequst studentsRequst)
        {
            return await _apiServices.GetJsonAsync<List<StudentListResponse>>("Students/Top", studentsRequst);
        }
        public async Task<StudentDetailsResponse> GetStudentDetails(Guid id)
        {
            return await _apiServices.GetJsonAsync<StudentDetailsResponse>($"Students/{id}");
        }
        public async Task<StudentStatisticsResponse> GetStatisticsDetails(StudentsRequst studentsRequst)
        {
            return await _apiServices.GetJsonAsync<StudentStatisticsResponse>($"Students/Statistics" , studentsRequst);
        }
    }
}
