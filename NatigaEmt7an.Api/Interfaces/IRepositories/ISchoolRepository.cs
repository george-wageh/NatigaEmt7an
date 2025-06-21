using NatigaEmt7an.Contracts.Responses.School;

namespace NatigaEmt7an.Api.Interfaces.IRepositories
{
    public interface ISchoolRepository
    {
        Task<List<SchoolDropList>> GetDropListAsync(Guid schoolAdministrationId);

    }
}
