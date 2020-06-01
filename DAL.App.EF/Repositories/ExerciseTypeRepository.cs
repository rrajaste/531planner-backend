using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class ExerciseTypeRepository : EFBaseRepository<AppDbContext, ExerciseType, DTO.ExerciseType>,
        IExerciseTypeRepository
    {
        public ExerciseTypeRepository(AppDbContext repoDbContext, IDALMapper<ExerciseType, DTO.ExerciseType> mapper)
            : base(repoDbContext, mapper)
        {
        }
    }
}