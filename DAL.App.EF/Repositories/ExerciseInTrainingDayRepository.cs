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
    public class ExerciseInTrainingDayRepository : EFBaseRepository<AppDbContext, ExerciseInTrainingDay, DTO.ExerciseInTrainingDay>,
        IExerciseInTrainingDayRepository
    {
        public ExerciseInTrainingDayRepository(AppDbContext dbContext, IDALMapper<ExerciseInTrainingDay, DTO.ExerciseInTrainingDay> mapper) 
            : base(dbContext, mapper)
        {
            
        }

        public async Task<IEnumerable<DTO.ExerciseInTrainingDay>> AllWithBaseTrainingDayIdAsync(Guid trainingDayId)
        {
            var exercisesInTrainingDay = await RepoDbSet.Include(exercise => exercise.ExerciseSets)
                .ThenInclude(set => set.SetType)
                .Include(exercise => exercise.Exercise)
                .Include(exercise => exercise.ExerciseType)
                .Where(exercise => exercise.TrainingDayId == trainingDayId)
                .ToListAsync();
            var mappedExercisesInTrainingDay = exercisesInTrainingDay.Select(Mapper.MapDomainToDAL);
            return mappedExercisesInTrainingDay;
        }

        public async Task<bool> IsPartOfBaseRoutineAsync(Guid id)
        {
            var query = RepoDbSet
                .Include(e => e.TrainingDay)
                .ThenInclude(d => d.TrainingWeek)
                .ThenInclude(w => w.TrainingCycle)
                .ThenInclude(c => c.WorkoutRoutine);
            var isPartOfBaseRoutine = await 
                query.AnyAsync(e => e.TrainingDay.TrainingWeek.TrainingCycle.WorkoutRoutine.AppUserId == null);
            return isPartOfBaseRoutine;
        }
    }
}