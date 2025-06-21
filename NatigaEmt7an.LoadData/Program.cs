using NatigaEmt7an.LoadData.ExtractData;
using NatigaEmt7an.LoadData.Models;
using System.Text.Json;
using NatigaEmt7an.Models.Models;
using System.Threading.Tasks;
using NatigaEmt7an.Models.Enums;
using NatigaEmt7an.Api.Data;
namespace NatigaEmt7an.LoadData
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var students = Extract.LoadJsonFile();
            //var governorates = Extract.GetStudentsGrouped(students);
            //await SaveData.SaveDataAsync(governorates);

            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
