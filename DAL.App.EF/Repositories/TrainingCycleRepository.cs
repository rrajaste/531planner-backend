using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class TrainingCycleRepository :
        EFBaseRepository<AppDbContext, Domain.App.TrainingCycle, DAL.App.DTO.TrainingCycle>,
        ITrainingCycleRepository
    {
        public TrainingCycleRepository(AppDbContext repoDbContext, IDALMapper<Domain.App.TrainingCycle, DAL.App.DTO.TrainingCycle> mapper) 
            : base(repoDbContext, mapper)
        {
        }

        public async Task<IEnumerable<TrainingCycle>> AllWithRoutineIdForUserWithIdAsync(Guid id, Guid? userId)
        {
            var trainingCycles = RepoDbSet
                .Include(c => c.WorkoutRoutine)
                .Where(c => c.WorkoutRoutineId.Equals(id));
            var authorizedCycles = trainingCycles
                .Where(c => c.WorkoutRoutine!.AppUserId.Equals(userId));
            var cyclesList = await authorizedCycles.ToListAsync();
            return cyclesList.Select(Mapper.MapDomainToDAL);
        }

        public async Task<TrainingCycle> FindWithRoutineIdForUserWithIdAsync(Guid id, Guid userId)
        {
            var cycle = await RepoDbSet
                .Include(c => c.WorkoutRoutine)
                .FirstOrDefaultAsync(c => c.WorkoutRoutineId == id && c.WorkoutRoutine!.AppUserId == userId);
            var mappedCycle = Mapper.MapDomainToDAL(cycle);
            return mappedCycle;
        }

        public async Task<TrainingCycle> FindWithBaseRoutineIdAsync(Guid id)
        {
            var cycle = await RepoDbSet
                .Include(c => c.WorkoutRoutine)
                .FirstOrDefaultAsync(c => c.WorkoutRoutineId == id && c.WorkoutRoutine!.AppUserId == null);
            var mappedCycle = Mapper.MapDomainToDAL(cycle);
            return mappedCycle;
        }

        public Task<bool> IsPartOfBaseRoutineAsync(Guid cycleId) =>
            RepoDbSet.Include(c => c.WorkoutRoutine)
                .AnyAsync(c => c.Id == cycleId && c.WorkoutRoutine!.AppUserId == null);
        
        public async Task<TrainingCycle> GetFullActiveCycleForUserWithIdAsync(Guid userId)
        {
            var fullTrainingCycle = await RepoDbSet
                    .Include(cycle => cycle.WorkoutRoutine)
                    .Include(cycle => cycle.TrainingWeeks)
                    .ThenInclude(week => week.TrainingDays)
                    .ThenInclude(day => day.TrainingDayType)
                    .Include(cycle => cycle.TrainingWeeks)
                    .ThenInclude(week => week.TrainingDays)
                    .ThenInclude(day => day.ExercisesInTrainingDay)
                    .ThenInclude(exerciseInTrainingDay => exerciseInTrainingDay.ExerciseType)
                    .Include(cycle => cycle.TrainingWeeks)
                    .ThenInclude(week => week.TrainingDays)
                    .ThenInclude(day => day.ExercisesInTrainingDay)
                    .ThenInclude(exerciseInTrainingDay => exerciseInTrainingDay.Exercise)
                    .Include(cycle => cycle.TrainingWeeks)
                    .ThenInclude(week => week.TrainingDays).ThenInclude(day => day.ExercisesInTrainingDay)
                    .ThenInclude(exerciseInTrainingDay => exerciseInTrainingDay.ExerciseSets)
                    .ThenInclude(set => set.SetType)
                    .OrderBy(cycle => cycle.StartingDate)
                    .FirstOrDefaultAsync(cycle => cycle.WorkoutRoutine!.AppUserId == userId);
            var mappedCycle = Mapper.MapDomainToDAL(fullTrainingCycle);
            return mappedCycle;
        }
    }
}