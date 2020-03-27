using Contracts.DAL.App;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ExerciseInTrainingDayRepository : EFBaseRepository<ExerciseInTrainingDay, AppDbContext>, IExerciseInTrainingDayRepository
    {
        public ExerciseInTrainingDayRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}