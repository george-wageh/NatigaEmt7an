using NatigaEmt7an.Contracts.Responses.School;
using NewsBlazorAppAdmin.Services;

namespace NatigaEmt7an.Blazor.Services
{
    public class SchoolServices
    {
        private readonly ApiServices _apiServices;

        public SchoolServices(ApiServices apiServices)
        {
            _apiServices = apiServices;
        }
        public async Task<List<SchoolDropList>> GetDropList(Guid administrationId) {
            return await _apiServices.GetJsonAsync<List<SchoolDropList>>($"Schools/drop-list/{administrationId}");
        }
    }
}
