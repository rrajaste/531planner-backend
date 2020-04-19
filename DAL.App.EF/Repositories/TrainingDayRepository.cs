using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using TrainingDay = DAL.App.DTO.TrainingDay;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayRepository : EFBaseRepository<AppDbContext, Domain.TrainingDay, DAL.App.DTO.TrainingDay>, ITrainingDayRepository
    {
        public TrainingDayRepository(AppDbContext repoDbContext) : base(repoDbContext, new BaseDALMapper<Domain.TrainingDay, TrainingDay>())
        {
        }

        public async Task<IEnumerable<DAL.App.DTO.TrainingDay>> AllWithTrainingWeekIdAsync(Guid id, Guid userId) => (
            await RepoDbSet
                .Where(t => t.Id == id)
                .ToListAsync()
            ).Select(Mapper.Map);
    }
}