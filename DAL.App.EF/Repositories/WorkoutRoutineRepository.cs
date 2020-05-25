using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Contracts.DAL.App.Mappers;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkoutRoutineRepository : EFBaseRepository<AppDbContext, WorkoutRoutine, DAL.App.DTO.WorkoutRoutine>,
        IWorkoutRoutineRepository
    {
        public WorkoutRoutineRepository(AppDbContext repoDbContext, IDALMapper<WorkoutRoutine, DTO.WorkoutRoutine> mapper) 
            : base(repoDbContext, mapper)
        {
        }

        public async Task<DTO.WorkoutRoutine> ActiveRoutineForUserWithIdAsync(Guid userId) =>
            Mapper.MapDomainToDAL(
                await RepoDbSet
                    .AsNoTracking()
                    .SingleOrDefaultAsync(
                    w => w.AppUserId.Equals(userId) 
                         && w.CreatedAt <= DateTime.Now 
                         && w.ClosedAt > DateTime.Now)
                );

        public async Task<bool> ActiveRoutineWithIdExistsForUserAsync(Guid routineId, Guid userId) =>
            await RepoDbSet.AnyAsync(routine => routine.Id == routineId && routine.AppUserId == userId);

        public async Task<IEnumerable<DTO.WorkoutRoutine>> AllInactiveRoutinesForUserWithIdAsync(Guid userId) => (
            await RepoDbSet.Where(
                w => w.AppUserId == userId
                     && w.CreatedAt <= DateTime.Now
                     && w.ClosedAt < DateTime.Now
                    ).ToListAsync()
                ).Select(Mapper.MapDomainToDAL);

        public async Task<IEnumerable<DTO.WorkoutRoutine>> AllActiveBaseRoutinesAsync() => (
            await RepoDbSet.Where(
                w => w.AppUserId == null
                     && w.ClosedAt > DateTime.Now
            ).ToListAsync()
                ).Select(Mapper.MapDomainToDAL);

        
        public async Task<IEnumerable<DTO.WorkoutRoutine>> AllPublishedBaseRoutinesAsync() => (
            await RepoDbSet
                .Where(w => 
                    w.AppUserId == null && 
                    w.ClosedAt > DateTime.Now &&
                    w.CreatedAt <= DateTime.Now
                ).ToListAsync()
            ).Select(Mapper.MapDomainToDAL);

        
        public async Task<IEnumerable<DTO.WorkoutRoutine>> AllInactiveBaseRoutinesAsync() => (
            await RepoDbSet.Where(
                w => w.AppUserId == null
                     && w.ClosedAt <= DateTime.Now
            ).ToListAsync()
            ).Select(Mapper.MapDomainToDAL);

        public async Task<IEnumerable<DTO.WorkoutRoutine>> AllUnPublishedBaseRoutinesAsync() => (
            await RepoDbSet.Where(
                w => w.AppUserId == null
                     && w.ClosedAt >= DateTime.Now
                     && w.CreatedAt >= DateTime.MaxValue
                ).ToListAsync()
            ).Select(Mapper.MapDomainToDAL);

        public async Task<DTO.WorkoutRoutine> FindBaseRoutineAsync(Guid id) =>
            Mapper.MapDomainToDAL(
                await RepoDbSet.Where(
                    w => w.AppUserId == null
                         && w.Id == id
                ).SingleOrDefaultAsync()
            );

        public async Task<bool> BaseRoutineWithIdExistsAsync(Guid id) =>
            await RepoDbSet.AnyAsync(w => w.AppUserId == null && w.Id.Equals(id));

        public async Task<DTO.WorkoutRoutine> AddWithBaseCycleAsync(DTO.WorkoutRoutine dto)
        {
            var domainEntity = Mapper.MapDALToDomain(dto);
            domainEntity.CreatedAt = DateTime.MaxValue;
            domainEntity.ClosedAt = DateTime.MaxValue;
            var baseCycle = new TrainingCycle()
            {
                Id = new Guid(),
                CycleNumber = 1,
                StartingDate = DateTime.Now,
            };
            domainEntity.TrainingCycles = new List<TrainingCycle> {baseCycle};
            await RepoDbContext.WorkoutRoutines.AddAsync(domainEntity);
            return Mapper.MapDomainToDAL(domainEntity);
        }

        public async Task<DTO.WorkoutRoutine> ChangeRoutinePublishStatus(Guid routineId, bool isPublished)
        {
            var routineToPublish = await RepoDbSet.FindAsync(routineId);
            routineToPublish.CreatedAt = isPublished ? DateTime.Now : DateTime.MaxValue;
            RepoDbSet.Update(routineToPublish);
            return Mapper.MapDomainToDAL(routineToPublish);
        }

        public async Task<DTO.WorkoutRoutine> FindWithWeekIdAsync(Guid weekId)
        {
            var trainingWeek = await RepoDbContext.TrainingWeeks
                .Include(w => w.TrainingCycle)
                .ThenInclude(c => c!.WorkoutRoutine)
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Id == weekId);
            var parentRoutine = trainingWeek.TrainingCycle!.WorkoutRoutine;
            return Mapper.MapDomainToDAL(parentRoutine!);
        }

        public async Task<DTO.WorkoutRoutine> FindWithTrainingDayIdAsync(Guid trainingDayId)
        {
            var trainingDay = await RepoDbContext.TrainingDays
                .Include(d => d.TrainingWeek)
                .ThenInclude(w => w!.TrainingCycle)
                .ThenInclude(c => c!.WorkoutRoutine)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == trainingDayId);
            var parentRoutine = trainingDay.TrainingWeek!.TrainingCycle!.WorkoutRoutine;
            return Mapper.MapDomainToDAL(parentRoutine!);
        }

        public async Task<DTO.WorkoutRoutine> FindFullRoutineWithIdAsync(Guid routineId)
        {
            var workoutRoutine = await RepoDbSet.Include(routine => routine.TrainingCycles)
                .ThenInclude(cycle => cycle.TrainingWeeks)
                .ThenInclude(week => week.TrainingDays)
                .ThenInclude(day => day.TrainingDayType)
                .Include(routine => routine.TrainingCycles)
                .ThenInclude(cycle => cycle.TrainingWeeks)
                .ThenInclude(trainingWeek => trainingWeek.TrainingDays)
                .ThenInclude(exercise => exercise.ExercisesInTrainingDay)
                .ThenInclude(exercise => exercise.ExerciseType)
                .Include(routine => routine.TrainingCycles)
                .ThenInclude(cycle => cycle.TrainingWeeks)
                .ThenInclude(week => week.TrainingDays)
                .ThenInclude(day => day.ExercisesInTrainingDay)
                .ThenInclude(exercise => exercise.Exercise)
                .Include(routine => routine.TrainingCycles)
                .ThenInclude(cycle => cycle.TrainingWeeks)
                .ThenInclude(week => week.TrainingDays)
                .ThenInclude(day => day.ExercisesInTrainingDay)
                .ThenInclude(exercise => exercise.ExerciseSets)
                .ThenInclude(set => set.SetType)
                .FirstOrDefaultAsync(routine => routine.Id == routineId);
            var mappedRoutine = Mapper.MapDomainToDAL(workoutRoutine);
            return mappedRoutine;
        }

        public async Task<bool> UserWithIdHasActiveRoutineAsync(Guid userId)
        {
            var doesUserHaveActiveRoutine = await RepoDbSet.AnyAsync(routine => routine.AppUserId.Equals(userId));
            return doesUserHaveActiveRoutine;
        }
    }
}