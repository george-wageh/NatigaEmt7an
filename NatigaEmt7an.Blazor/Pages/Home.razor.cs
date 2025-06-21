
using Microsoft.AspNetCore.Components;
using NatigaEmt7an.Blazor.Services;
using NatigaEmt7an.Contracts.Requests.Student;
using NatigaEmt7an.Contracts.Responses;
using NatigaEmt7an.Contracts.Responses.Governorate;
using NatigaEmt7an.Contracts.Responses.School;
using NatigaEmt7an.Contracts.Responses.SchoolAdministrations;
using NatigaEmt7an.Contracts.Responses.Student;
using NatigaEmt7an.Models.Enums;
using System.Threading.Tasks;

namespace NatigaEmt7an.Blazor.Pages
{
    public partial class Home
    {
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

        public PageList<StudentListResponse>? PageStudentList { get; set; }

        private string? SearchText { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            Governorates = await GovernorateServices.GetDropList();
        }

        private async Task ChangeGovernorate() {
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
        private async Task LoadStudentsPage(int page) {
            StudentListRequst studentListRequst = new StudentListRequst
            {
                GovernorateId = SelectedGovernorateId,
                SchoolAdministrationId = SelectedAdministrationId,
                SchoolId = SelectedSchoolId,
                PageNumber = page
            };
            if (int.TryParse(SearchText, out int seatNumber))
            {
                studentListRequst.SeatNum = seatNumber;
            }
            else
            {
                studentListRequst.StudentName = SearchText;
            }
            PageStudentList = await StudentServices.GetStudents(studentListRequst);
        }

        private async Task Search()
        {
            await LoadStudentsPage(1);
        }
        private async Task ChangePage(int page)
        {
            if (PageStudentList != null) {
                if (page >= 1 && page <= PageStudentList.TotalPages)
                {
                    await LoadStudentsPage(page);
                }
            }
        }
        private void ShowDetails(Guid id) 
        {
            Navigation.NavigateTo($"students/{id}");
        }



        private IEnumerable<int> GetDisplayedPages()
        {
            if (PageStudentList == null) yield break;

            int start = Math.Max(1, PageStudentList.CurrentPage - 2);
            int end = Math.Min(PageStudentList.TotalPages, start + 4);

            for (int i = start; i <= end; i++)
                yield return i;
        }
    }
}
