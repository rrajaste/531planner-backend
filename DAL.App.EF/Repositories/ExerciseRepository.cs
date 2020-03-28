using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class ExerciseRepository : EFBaseRepository<Exercise, AppDbContext>, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}