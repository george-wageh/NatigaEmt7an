using Blazorise;
using Blazorise.Charts;
using Microsoft.AspNetCore.Components;
using NatigaEmt7an.Blazor.Services;
using NatigaEmt7an.Contracts.Requests.Student;
using NatigaEmt7an.Contracts.Responses.Governorate;
using NatigaEmt7an.Contracts.Responses.School;
using NatigaEmt7an.Contracts.Responses.SchoolAdministrations;
using NatigaEmt7an.Contracts.Responses.Student;
using NatigaEmt7an.Models.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NatigaEmt7an.Blazor.Pages
{
    public partial class StudentStatistics
    {
    

        [Inject]
        public GovernorateServices GovernorateServices { get; set; }
        [Inject]
        public AdministrationServices AdministrationServices { get; set; }
        [Inject]
        public SchoolServices SchoolServices { get; set; }
        [Inject]
        public StudentServices StudentServices { get; set; }

        public List<GovernorateDropList> Governorates { get; set; } = [];
        public List<SchoolAdministrationsDropList> Administrations { get; set; } = [];
        public List<SchoolDropList> Schools { get; set; } = [];


        private Guid? SelectedGovernorateId { get; set; }
        private Guid? SelectedAdministrationId { get; set; }
        private Guid? SelectedSchoolId { get; set; }

        private readonly string[] Labels1 = new[] { "410-369", "369-349", "349-308", "308-246", "246-205", "205-0" };
        private readonly string[] Labels2 = new[] { "ناجح", "دور تاني", "راسب" };
        Dictionary<StudentCategory?, string> CategoryColorMap = new()
        {
            { StudentCategory.Literary, "rgba(255, 99, 132, 0.6)" },
            { StudentCategory.ScientificMath, "rgba(54, 162, 235, 0.6)" },
            { StudentCategory.ScientificScience, "rgba(75, 192, 192, 0.6)" },
            { StudentCategory.Unspecified, "rgba(75, 122, 122, 0.6)" }
        };

        private List<double> ToData(GradeClassification g) =>
            new() { g.G_410_369, g.G_369_349, g.G_349_308, g.G_308_246, g.G_246_205, g.G_205_0 };

        private double Sum(GradeClassification g) =>
             g.G_410_369+ g.G_369_349+ g.G_349_308+ g.G_308_246+ g.G_246_205+ g.G_205_0;

        private List<double> ToData(StatusCategory g) =>
            new() { g.PassedCount, g.SecondRoundCount, g.FailedCount };

        private double Sum(StatusCategory g) =>
             g.PassedCount+ g.SecondRoundCount+ g.FailedCount ;

        private Chart<double> chart1;
        private Chart<double> chart2;

        public List<StatusCategory>? StatusCategories { get; set; }
        public List<GradeClassification>? GradeClassifications { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Governorates = await GovernorateServices.GetDropList();
        }

        private async Task ChangeGovernorate()
        {
            if (SelectedGovernorateId != null)
                Administrations = await AdministrationServices.GetDropList(SelectedGovernorateId.Value);
            else
                Administrations = [];

            SelectedAdministrationId = null;
            SelectedSchoolId = null;
            Schools = [];
        }

        private async Task ChangeAdministration()
        {
            if (SelectedAdministrationId != null)
                Schools = await SchoolServices.GetDropList(SelectedAdministrationId.Value);
            else
                Schools = [];
            SelectedSchoolId = null;
        }

        private async Task Search()
        {
            var statisticsResponse = await StudentServices.GetStatisticsDetails(new StudentsRequst { 
                Category = null,
                GovernorateId = SelectedGovernorateId,
                SchoolAdministrationId = SelectedAdministrationId,
                SchoolId = SelectedSchoolId
            });

            {

                var gradeClassifications = statisticsResponse.GradeClassifications;
                gradeClassifications = gradeClassifications.OrderByDescending(x => x.Category).ToList();
                List<BarChartDataset<double>> dataset = new List<BarChartDataset<double>>();
                foreach (var category in gradeClassifications)
                {
                    var color = category.Category == null ? "rgba(175, 192, 192, 0.6)" : CategoryColorMap[category.Category];
                    var label = category.Category == null ? "الكل" : TrArEnumService.GetArabicCategory(category.Category.Value);
                    dataset.Add(new BarChartDataset<double>
                    {
                        BackgroundColor = color,
                        Label = label,
                        BorderColor = color,
                        Data = ToData(category)
                    });
                }

                await chart1.Clear();
                await chart1.AddLabelsDatasetsAndUpdate(Labels1,
                   dataset.ToArray()
                );
                GradeClassifications = gradeClassifications;
            }

            { 
                var statusClassifications = statisticsResponse.StatusClassifications;
                statusClassifications = statusClassifications.OrderByDescending(x => x.Category).ToList();
                List<BarChartDataset<double>> dataset = new List<BarChartDataset<double>>();
                foreach (var category in statusClassifications)
                {
                    var color = category.Category == null ? "rgba(175, 192, 192, 0.6)" : CategoryColorMap[category.Category];
                    var label = category.Category == null ? "الكل" : TrArEnumService.GetArabicCategory(category.Category.Value);
                    dataset.Add(new BarChartDataset<double>
                    {
                        BackgroundColor = color,
                        Label = label,
                        BorderColor = color,
                        Data = ToData(category)
                    });
                }

                await chart2.Clear();
                await chart2.AddLabelsDatasetsAndUpdate(Labels2,
                   dataset.ToArray()
                );
                StatusCategories = statusClassifications;
            }

        }
    }
}
