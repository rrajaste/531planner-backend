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

        public async Task<IEnumerable<DAL.App.DTO.ExerciseSet>> AllWithTrainingDayIdAsync(Guid trainingDayId)
        {
            var domainObjects = await RepoDbSet
                .Include(s => s.TrainingDay)
                .Include(s => s.SetType)
                .Include(s => s.UnitType).Include(s => s.Exercise)
                .Where(s => s.TrainingDayId == trainingDayId)
                .ToListAsync();
            var dalObjects = domainObjects.Select(Mapper.MapDomainToDAL);
            return dalObjects;
        }

        public async Task<bool> IsPartOfBaseRoutineAsync(Guid exerciseSetId) =>
            await RepoDbSet
                .Include(s => s.TrainingDay)
                .ThenInclude(d => d!.TrainingWeek)
                .ThenInclude(w => w!.TrainingCycle)
                .ThenInclude(c => c!.WorkoutRoutine)
                .AnyAsync(s =>
                    s.Id == exerciseSetId &&
                    s.TrainingDay!.TrainingWeek!.TrainingCycle!.WorkoutRoutine!.AppUserId == null
                );

        public async Task<DTO.ExerciseSet> AddBaseSetAsync(DTO.ExerciseSet dto)
        {
            var domainEntity = Mapper.MapDALToDomain(dto);
            var unitType = await RepoDbContext
                .UnitTypes
                .FirstOrDefaultAsync(t => t.Name == Domain.App.Enums.UnitTypes.Metric);
            var trainingDay = await RepoDbContext.TrainingDays
                .Include(d => d!.TrainingWeek)
                .ThenInclude(w => w!.TrainingCycle)
                .FirstOrDefaultAsync(d => d.Id == dto.TrainingDayId);
            var workoutRoutineId = trainingDay.TrainingWeek!.TrainingCycle!.WorkoutRoutineId;
            domainEntity.UnitTypeId = unitType.Id;
            domainEntity.WorkoutRoutineId = workoutRoutineId;
            await RepoDbSet.AddAsync(domainEntity);
            return Mapper.MapDomainToDAL(domainEntity);
        }
    }
}