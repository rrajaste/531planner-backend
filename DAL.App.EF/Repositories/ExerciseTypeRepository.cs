using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class ExerciseTypeRepository : EFBaseRepository<AppDbContext, Domain.ExerciseType, DAL.App.DTO.ExerciseType>, 
        IExerciseTypeRepository
    {
        public ExerciseTypeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}