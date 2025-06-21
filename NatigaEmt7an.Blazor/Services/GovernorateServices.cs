using NatigaEmt7an.Contracts.Responses.Governorate;
using NatigaEmt7an.Contracts.Responses.School;
using NewsBlazorAppAdmin.Services;

namespace NatigaEmt7an.Blazor.Services
{
    public class GovernorateServices
    {
        private readonly ApiServices _apiServices;

        public GovernorateServices(ApiServices apiServices)
        {
            _apiServices = apiServices;
        }
        public async Task<List<GovernorateDropList>> GetDropList()
        {
            return await _apiServices.GetJsonAsync<List<GovernorateDropList>>("Governorates/drop-list");
        }
    }
}
