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
                .Include(d => d.ExercisesInTrainingDay)
                .ThenInclude(s => s.Exercise)
                .Include(d => d.ExercisesInTrainingDay)
                .ThenInclude(s => s.ExerciseType)
                .Include(d => d.ExercisesInTrainingDay)
                .ThenInclude(s => s.ExerciseSets)
                .Where(d => d.TrainingWeekId.Equals(trainingWeekId)).ToListAsync();
            var dalItemsList = domainItemsList.Select(Mapper.MapDomainToDAL);
            return dalItemsList;
        }

        public async Task<bool> IsPartOfBaseRoutineAsync(Guid trainingDayId) =>
            await RepoDbSet
                .Include(d => d.TrainingWeek)
                .ThenInclude(w => w!.TrainingCycle)
                .ThenInclude(c => c!.WorkoutRoutine)
                .AnyAsync(d => d.Id == trainingDayId && d.TrainingWeek!.TrainingCycle!.WorkoutRoutine!.AppUserId == null
                );

        public async Task<DTO.TrainingDay> FindWithExerciseSetIdAsync(Guid id)
        {
            var exerciseSet = await RepoDbContext.ExerciseSets
                .AsNoTracking()
                .Include(s => s.ExerciseInTrainingDay)
                .ThenInclude(e => e.TrainingDay)
                .FirstOrDefaultAsync(s => s.Id == id);
            var parentTrainingDay = exerciseSet.ExerciseInTrainingDay!.TrainingDay;
            if (parentTrainingDay == null)
            {
                throw new ApplicationException("Cannot find TrainingDay with ExerciseSetId: " + id);
            }
            return Mapper.MapDomainToDAL(parentTrainingDay);
        }

        public async Task<DTO.TrainingDay> FindWithExerciseInTrainingDayIdAsync(Guid id)
        {
            var exerciseInTrainingDay = await RepoDbContext.ExercisesInTrainingDay
                .AsNoTracking()
                .Include(e => e.TrainingDay)
                .FirstOrDefaultAsync(e => e.Id == id);
            var parentTrainingDay = exerciseInTrainingDay.TrainingDay;
            if (parentTrainingDay == null)
            {
                throw new ApplicationException("Cannot find TrainingDay with ExerciseInTrainingDayId: " + id);
            }
            return Mapper.MapDomainToDAL(parentTrainingDay);
        }

        public override async Task<DTO.TrainingDay> FindAsync(Guid id)
        {
            var domainEntity = await RepoDbSet
                .AsNoTracking()
                .Include(d => d.TrainingDayType)
                .Include(d => d.ExercisesInTrainingDay)
                .ThenInclude(e => e.ExerciseSets)
                .ThenInclude(s => s.SetType)
                .Include(d => d.ExercisesInTrainingDay)
                .ThenInclude(e => e.ExerciseType)
                .Include(d => d.ExercisesInTrainingDay)
                .ThenInclude(e => e.Exercise)
                .FirstOrDefaultAsync(d => d.Id == id);
            var dalEntity = Mapper.MapDomainToDAL(domainEntity);
            return dalEntity;
        }
    }
}
