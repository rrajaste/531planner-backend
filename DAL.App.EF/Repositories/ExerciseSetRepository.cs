using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class ExerciseSetRepository : EFBaseRepository<ExerciseSet, AppDbContext>, IExerciseSetRepository
    {
        public ExerciseSetRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}