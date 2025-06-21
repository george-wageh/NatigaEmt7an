using Microsoft.EntityFrameworkCore;
using NatigaEmt7an.Api.Data;
using NatigaEmt7an.Api.Interfaces.IRepositories;
using NatigaEmt7an.Contracts.Responses.Governorate;

namespace NatigaEmt7an.Api.Repositories
{
    public class GovernorateRepository:IGovernorateRepository
    {
        private readonly AppDbContext _dbContext;

        public GovernorateRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<List<GovernorateDropList>> GetDropListAsync() {
            return await _dbContext.Governorates.Select(x => new GovernorateDropList
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
