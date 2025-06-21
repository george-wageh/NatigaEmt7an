using NatigaEmt7an.LoadData.ExtractModels;
using NatigaEmt7an.LoadData.Models;
using NatigaEmt7an.Models.Enums;
using NatigaEmt7an.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NatigaEmt7an.LoadData.ExtractData
{
    public static class Extract
    {
        public static List<StudentRoot>? LoadJsonFile(string filePath = "H:\\thanawy3ma.thanawyusers.json") {
            var json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var students = JsonSerializer.Deserialize<List<StudentRoot>>(json, options);
            if (students is null)
                throw new Exception("Students is null");
            return students;
        }

        public static List<GovernorateExtractModel> GetStudentsGrouped(List<StudentRoot>? students) {
            var governorates = students.GroupBy(x => x.StudentInfo.Mohafza).Select(
                x => new GovernorateExtractModel { Name = x.Key, Administrations = x.GroupBy(s => s.StudentInfo.EduAdmin).Select(s => new SchoolAdministrationExtractModel { Name = s.Key, Schools = s.GroupBy(m => m.StudentInfo.School).Select(m => new SchoolExtractModel { Name = m.Key, Students = m.ToList() }).ToList() }).ToList() }).ToList();
            return governorates;
        }

      
        //public static List<GovernorateSchoolAdministrations> GetGovernorateAdministrations(List<StudentRoot>? students) {
        //    return students.GroupBy(x => x.StudentInfo.Mohafza).Select(x => 
        //    new GovernorateSchoolAdministrations{ Name = x.Key, SchoolAdministrations = x.Select(f => f.StudentInfo.EduAdmin).Distinct().ToList() }).ToList();
        //}

        //public static List<SchoolAdministrationsSchools> GetAdministrationsSchools(List<StudentRoot>? students)
        //{
        //    return students.GroupBy(x => x.StudentInfo.EduAdmin).Select(x =>
        //    new SchoolAdministrationsSchools { Name = x.Key, Schools = x.Select(f => f.StudentInfo.School).Distinct().ToList() }).ToList();
        //}


    }
}
