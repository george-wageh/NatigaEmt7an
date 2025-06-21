using NatigaEmt7an.Api.Data;
using NatigaEmt7an.LoadData.ExtractData;
using NatigaEmt7an.LoadData.ExtractModels;
using NatigaEmt7an.LoadData.Models;
using NatigaEmt7an.Models.Enums;
using NatigaEmt7an.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.LoadData
{
    public static class SaveData
    {
        public static async Task SaveDataAsync(List<GovernorateExtractModel> governorates) {
            using (var context = new AppDbContext())
            {
                var m_studentsCount = 0;
                context.Database.EnsureCreated();
                foreach (var governorate in governorates)
                {
                    var m_governorate = new Governorate
                    {
                        Name = governorate.Name,
                    };
                    await context.AddAsync(m_governorate);
                    await context.SaveChangesAsync();

                    foreach (var admin in governorate.Administrations)
                    {
                        var m_admin = new SchoolAdministration
                        {
                            GovernorateId = m_governorate.Id,
                            Name = admin.Name
                        };
                        await context.AddAsync(m_admin);
                        await context.SaveChangesAsync();

                        foreach (var school in admin.Schools)
                        {
                            var m_school = new School
                            {
                                Name = school.Name,
                                SchoolAdministrationId = m_admin.Id,
                                GovernorateId = m_governorate.Id
                            };
                            await context.AddAsync(m_school);
                            await context.SaveChangesAsync();
                            List<Student> m_students = [];
                            foreach (var student in school.Students)
                            {
                                var m_student = MapStudent(student, m_governorate.Id, m_admin.Id, m_school.Id);
                                m_students.Add(m_student);
                            }
                            await context.AddRangeAsync(m_students);
                            await context.SaveChangesAsync();
                            m_studentsCount += m_students.Count();
                            Console.WriteLine(m_studentsCount);
                        }
                    }
                }

            }
        }

        private static Student MapStudent(StudentRoot student , Guid m_governorateId , Guid m_adminId , Guid m_schoolId) {
            return new Student
            {
                GovernorateId = m_governorateId,
                SchoolAdministrationId = m_adminId,
                SchoolId = m_schoolId,

                Name = student.StudentInfo.Name,
                SeatNumber = student.StudentInfo.SeatNum,
                TotalGrades = student.StudentInfo.TotalGrades,
                Category = student.StudentInfo.Category switch
                {
                    "ادبي" => StudentCategory.Literary,
                    "علمى رياضه" => StudentCategory.ScientificMath,
                    "علمى علوم" => StudentCategory.ScientificScience,
                    _ => StudentCategory.Unspecified
                },
                Status = student.StudentInfo.Status switch
                {
                    "ناجح" => StudentStatus.Passed,
                    "دور ثاني" => StudentStatus.SecondRound,
                    _ => StudentStatus.Failed
                },
                StudentGrade = new StudentGrade
                {
                    Ar = student.Courses.Ar,
                    Biology = student.Courses.Biology,
                    Chemistry = student.Courses.Chemistry,
                    Foreign1 = student.Courses.Foreign1,
                    Foreign2 = student.Courses.Foreign2,
                    Geography = student.Courses.Geography,
                    Geology = student.Courses.Geology,
                    History = student.Courses.History,
                    Math1 = student.Courses.Math1,
                    Math2 = student.Courses.Math2,
                    Philosophy = student.Courses.Philosophy,
                    Physics = student.Courses.Physics,
                    Psychology = student.Courses.Psychology,
                    OutCourses = new NatigaEmt7an.Models.Models.OutCourses
                    {
                        EconomicsStatistics = student.OutCourses.EconomicsStatistics,
                        NationalEdu = student.OutCourses.NationalEdu,
                        ReligionEdu = student.OutCourses.ReligionEdu
                    },
                }
            };
        }
    }
}
