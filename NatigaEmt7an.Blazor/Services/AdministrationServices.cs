using NatigaEmt7an.Contracts.Responses.Governorate;
using NatigaEmt7an.Contracts.Responses.SchoolAdministrations;
using NewsBlazorAppAdmin.Services;

namespace NatigaEmt7an.Blazor.Services
{
    public class AdministrationServices
    {
        private readonly ApiServices _apiServices;

        public AdministrationServices(ApiServices apiServices)
        {
            _apiServices = apiServices;
        }
        public async Task<List<SchoolAdministrationsDropList>> GetDropList(Guid governorateId)
        {
            return await _apiServices.GetJsonAsync<List<SchoolAdministrationsDropList>>($"Administrations/drop-list/{governorateId}");
        }
    }
}
