using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class ExerciseRepository : EFBaseRepository<AppDbContext, Exercise, DTO.Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext repoDbContext, IDALMapper<Exercise, DTO.Exercise> mapper)
            : base(repoDbContext, mapper)
        {
        }
    }
}