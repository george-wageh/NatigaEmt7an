using NatigaEmt7an.Contracts.Responses.Student;
using NatigaEmt7an.Contracts.Responses;
using Microsoft.AspNetCore.Components;
using NatigaEmt7an.Blazor.Services;
using NatigaEmt7an.Contracts.Requests.Student;
using NatigaEmt7an.Contracts.Responses.Governorate;
using NatigaEmt7an.Contracts.Responses.School;
using NatigaEmt7an.Contracts.Responses.SchoolAdministrations;
using NatigaEmt7an.Models.Enums;

namespace NatigaEmt7an.Blazor.Pages
{
    public partial class TopStudents
    {
        public List<StudentListResponse>? Students { get; set; }

        public List<GovernorateDropList> Governorates { get; set; } = [];
        public List<SchoolAdministrationsDropList> Administrations { get; set; } = [];
        public List<SchoolDropList> Schools { get; set; } = [];
        public StudentListRequst? StudentListRequst { get; set; } = null;
        [Inject]
        public GovernorateServices GovernorateServices { get; set; }
        [Inject]
        public AdministrationServices AdministrationServices { get; set; }
        [Inject]
        public SchoolServices SchoolServices { get; set; }
        [Inject]
        public StudentServices StudentServices { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private Guid? SelectedGovernorateId { get; set; }
        private Guid? SelectedAdministrationId { get; set; }
        private Guid? SelectedSchoolId { get; set; }
        private StudentCategory? SelectedCategory{ get; set; }

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
            Students = await StudentServices.GetTopStudents(new StudentsRequst
            {
                Category = SelectedCategory,
                GovernorateId = SelectedGovernorateId,
                SchoolAdministrationId = SelectedAdministrationId,
                SchoolId = SelectedSchoolId
            });
        }
        private void ShowDetails(Guid id)
        {
            Navigation.NavigateTo($"students/{id}");
        }

    }
}
