using NatigaEmt7an.Contracts.Responses.SchoolAdministrations;

namespace NatigaEmt7an.Api.Interfaces.IRepositories
{
    public interface ISchoolAdministrationsRepository
    {
        Task<List<SchoolAdministrationsDropList>> GetDropListAsync(Guid governorateId);
    }
}
