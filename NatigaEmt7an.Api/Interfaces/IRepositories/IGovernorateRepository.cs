using NatigaEmt7an.Contracts.Responses.Governorate;

namespace NatigaEmt7an.Api.Interfaces.IRepositories
{
    public interface IGovernorateRepository
    {
        Task<List<GovernorateDropList>> GetDropListAsync();
    }
}
