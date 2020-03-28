using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class ExerciseInTrainingDayRepository : EFBaseRepository<ExerciseInTrainingDay, AppDbContext>,
        IExerciseInTrainingDayRepository
    {
        public ExerciseInTrainingDayRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}