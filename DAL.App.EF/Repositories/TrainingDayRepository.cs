using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayRepository : EFBaseRepository<AppDbContext, Domain.TrainingDay, DAL.App.DTO.TrainingDay>, ITrainingDayRepository
    {
        public TrainingDayRepository(AppDbContext repoDbContext, IDALMapper<Domain.TrainingDay, DAL.App.DTO.TrainingDay> mapper) 
            : base(repoDbContext, mapper)
        {
        }

        public async Task<IEnumerable<DAL.App.DTO.TrainingDay>> AllWithTrainingWeekIdAsync(Guid id, Guid userId) => (
            await RepoDbSet
                .Where(t => t.Id == id)
                .ToListAsync()
            ).Select(Mapper.MapDomainToDAL);
    }
}