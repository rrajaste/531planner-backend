using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class ExerciseTypeRepository : EFBaseRepository<ExerciseType, AppDbContext>, IExerciseTypeRepository
    {
        public ExerciseTypeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}