using Microsoft.EntityFrameworkCore;
using NatigaEmt7an.Api.Data;
using NatigaEmt7an.Api.Interfaces.IRepositories;
using NatigaEmt7an.Contracts.Responses.School;
using NatigaEmt7an.Contracts.Responses.SchoolAdministrations;

namespace NatigaEmt7an.Api.Repositories
{
    public class SchoolRepository: ISchoolRepository
    {
        private readonly AppDbContext _dbContext;

        public SchoolRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<List<SchoolDropList>> GetDropListAsync(Guid schoolAdministrationId)
        {
            return await _dbContext.Schools.Where(x => x.SchoolAdministrationId == schoolAdministrationId).Select(x => new SchoolDropList
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
