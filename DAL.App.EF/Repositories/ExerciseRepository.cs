using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class ExerciseRepository : EFBaseRepository<AppDbContext, Domain.Exercise, DAL.App.DTO.Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext repoDbContext) : base(repoDbContext, new BaseDALMapper<Exercise, DTO.Exercise>())
        {
        }
    }
}