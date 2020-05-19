using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class ExerciseInTrainingDayRepository : EFBaseRepository<AppDbContext, ExerciseInTrainingDay, DTO.ExerciseInTrainingDay>,
        IExerciseInTrainingDayRepository
    {
        public ExerciseInTrainingDayRepository(AppDbContext dbContext, IDALMapper<ExerciseInTrainingDay, DTO.ExerciseInTrainingDay> mapper) 
            : base(dbContext, mapper)
        {
            
        }
    }
}