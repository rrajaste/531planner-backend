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
    public class TrainingCycleRepository :
        EFBaseRepository<AppDbContext, TrainingCycle, DTO.TrainingCycle>,
        ITrainingCycleRepository
    {
        public TrainingCycleRepository(AppDbContext repoDbContext, IDALMapper<TrainingCycle, DTO.TrainingCycle> mapper)
            : base(repoDbContext, mapper)
        {
        }

        public async Task<IEnumerable<DTO.TrainingCycle>> AllWithRoutineIdForUserWithIdAsync(Guid id, Guid? userId)
        {
            var trainingCycles = RepoDbSet
                .Include(c => c.WorkoutRoutine)
                .Where(c => c.WorkoutRoutineId.Equals(id));
            var authorizedCycles = trainingCycles
                .Where(c => c.WorkoutRoutine!.AppUserId.Equals(userId));
            var cyclesList = await authorizedCycles.ToListAsync();
            return cyclesList.Select(Mapper.MapDomainToDAL);
        }

        public async Task<DTO.TrainingCycle> FindWithRoutineIdForUserWithIdAsync(Guid id, Guid userId)
        {
            var cycle = await RepoDbSet
                .Include(c => c.WorkoutRoutine)
                .FirstOrDefaultAsync(c => c.WorkoutRoutineId == id && c.WorkoutRoutine!.AppUserId == userId);
            var mappedCycle = Mapper.MapDomainToDAL(cycle);
            return mappedCycle;
        }

        public async Task<DTO.TrainingCycle> FindWithBaseRoutineIdAsync(Guid id)
        {
            var cycle = await RepoDbSet
                .Include(c => c.WorkoutRoutine)
                .FirstOrDefaultAsync(c => c.WorkoutRoutineId == id && c.WorkoutRoutine!.AppUserId == null);
            var mappedCycle = Mapper.MapDomainToDAL(cycle);
            return mappedCycle;
        }

        public Task<bool> IsPartOfBaseRoutineAsync(Guid cycleId)
        {
            return RepoDbSet.Include(c => c.WorkoutRoutine)
                .AnyAsync(c => c.Id == cycleId && c.WorkoutRoutine!.AppUserId == null);
        }

        public async Task<DTO.TrainingCycle> GetFullActiveCycleForUserWithIdAsync(Guid userId)
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
                .FirstOrDefaultAsync(cycle => cycle.WorkoutRoutine!.AppUserId == userId &&
                                              cycle.CycleNumber == RepoDbSet.Max(c => c.CycleNumber));
            var mappedCycle = Mapper.MapDomainToDAL(fullTrainingCycle);
            return mappedCycle;
        }
    }
}