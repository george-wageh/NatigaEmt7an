
using Microsoft.AspNetCore.Components;
using NatigaEmt7an.Blazor.Services;
using NatigaEmt7an.Contracts.Responses.Student;

namespace NatigaEmt7an.Blazor.Pages
{
    public partial class StudentDetails
    {
        [Parameter]
        public Guid? Id { get; set; }

        [Inject]
        public StudentServices StudentServices { get; set; }

        public StudentDetailsResponse? User { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            if (Id != null) { 
                User = await StudentServices.GetStudentDetails(Id.Value);
            }
        }
    }
}
