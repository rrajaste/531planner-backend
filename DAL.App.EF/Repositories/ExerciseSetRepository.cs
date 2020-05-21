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
    public class ExerciseSetRepository : EFBaseRepository<AppDbContext, ExerciseSet, DAL.App.DTO.ExerciseSet>, 
        IExerciseSetRepository
    {
        public ExerciseSetRepository(AppDbContext dbContext, IDALMapper<ExerciseSet, DAL.App.DTO.ExerciseSet> mapper) 
            : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<DAL.App.DTO.ExerciseSet>> AllWithExerciseInTrainingDayIdAsync(Guid exerciseInTrainingDayId)
        {
            var domainObjects = await RepoDbSet
                .Include(s => s.SetType)
                .Include(s => s.UnitType)
                .Where(s => s.ExerciseInTrainingDay.Id == exerciseInTrainingDayId)
                .ToListAsync();
            var dalObjects = domainObjects.Select(Mapper.MapDomainToDAL);
            return dalObjects;
        }

        public async Task<bool> IsPartOfBaseRoutineAsync(Guid exerciseSetId) =>
            await RepoDbSet
                .Include(s => s.ExerciseInTrainingDay)
                .ThenInclude(e => e.TrainingDay)
                .ThenInclude(d => d!.TrainingWeek)
                .ThenInclude(w => w!.TrainingCycle)
                .ThenInclude(c => c!.WorkoutRoutine)
                .AnyAsync(s =>
                    s.Id == exerciseSetId &&
                    s.ExerciseInTrainingDay.TrainingDay!.TrainingWeek!.TrainingCycle!.WorkoutRoutine!.AppUserId == null
                );

        public async Task<Guid> GetRoutineIdForExerciseSetAsync(DTO.ExerciseSet entity)
        {
            var exerciseInTrainingDayWithIncludes =
                await RepoDbContext
                    .ExercisesInTrainingDay
                    .Include(d => d.TrainingDay)
                    .ThenInclude(d => d!.TrainingWeek)
                    .ThenInclude(w => w!.TrainingCycle)
                    .FirstOrDefaultAsync(e => e.Id == entity.ExerciseInTrainingDayId);
            return exerciseInTrainingDayWithIncludes!.TrainingDay!.TrainingWeek!.TrainingCycle!.WorkoutRoutineId;
        }
    }
}