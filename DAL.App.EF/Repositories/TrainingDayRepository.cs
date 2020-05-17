using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayRepository : EFBaseRepository<AppDbContext, TrainingDay, DAL.App.DTO.TrainingDay>,
        ITrainingDayRepository
    {
        public TrainingDayRepository(AppDbContext repoDbContext,
            IDALMapper<TrainingDay, DAL.App.DTO.TrainingDay> mapper)
            : base(repoDbContext, mapper)
        {
        }

        public async Task<IEnumerable<DTO.TrainingDay>> AllWithTrainingWeekIdAsync(Guid trainingWeekId)
        {
            var domainItemsList = await RepoDbSet
                .Include(d => d.TrainingDayType)
                .Include(d => d.TrainingWeek)
                .Include(d => d.ExerciseSets)
                .ThenInclude(s => s.Exercise)
                .Where(d => d.TrainingWeekId.Equals(trainingWeekId)).ToListAsync();
            var dalItemsList = domainItemsList.Select(Mapper.MapDomainToDAL);
            return dalItemsList;
        }

        public async Task<bool> IsPartOfBaseRoutineAsync(Guid trainingDayId) =>
            await RepoDbSet
                .Include(d => d.TrainingWeek)
                .ThenInclude(w => w!.TrainingCycle)
                .ThenInclude(c => c!.WorkoutRoutine)
                .AnyAsync(d => d.TrainingWeek!.TrainingCycle!.WorkoutRoutine!.AppUserId == null
                );

        public override async Task<DTO.TrainingDay> FindAsync(Guid id)
        {
            var domainEntity = await RepoDbSet
                .AsNoTracking()
                .Include(d => d.TrainingWeek)
                .Include(d => d.TrainingDayType)
                .FirstOrDefaultAsync(d => d.Id == id);
            var dalEntity = Mapper.MapDomainToDAL(domainEntity);
            return dalEntity;
        }
    }
}
