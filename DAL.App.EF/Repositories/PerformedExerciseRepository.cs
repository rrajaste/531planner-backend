using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class PerformedExerciseRepository : EFBaseRepository<PerformedExercise, AppDbContext>,
        IPerformedExerciseRepository
    {
        public PerformedExerciseRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}