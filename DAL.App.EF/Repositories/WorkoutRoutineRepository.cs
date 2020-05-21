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
                await RepoDbSet.SingleOrDefaultAsync(
                    w => w.AppUserId == userId 
                         && w.CreatedAt <= DateTime.Now 
                         && w.ClosedAt > DateTime.Now)
                );

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
    }
}