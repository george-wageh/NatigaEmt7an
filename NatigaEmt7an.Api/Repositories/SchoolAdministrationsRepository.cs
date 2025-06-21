using Microsoft.EntityFrameworkCore;
using NatigaEmt7an.Api.Data;
using NatigaEmt7an.Api.Interfaces.IRepositories;
using NatigaEmt7an.Contracts.Responses.Governorate;
using NatigaEmt7an.Contracts.Responses.SchoolAdministrations;

namespace NatigaEmt7an.Api.Repositories
{
    public class SchoolAdministrationsRepository: ISchoolAdministrationsRepository
    {
        private readonly AppDbContext _dbContext;

        public SchoolAdministrationsRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<List<SchoolAdministrationsDropList>> GetDropListAsync(Guid governorateId)
        {
            return await _dbContext.SchoolAdministrations.Where(x=>x.GovernorateId == governorateId).Select(x => new SchoolAdministrationsDropList
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
