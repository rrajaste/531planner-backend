using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class ExerciseSetRepository : EFBaseRepository<AppDbContext, Domain.ExerciseSet, DAL.App.DTO.ExerciseSet>, 
        IExerciseSetRepository
    {
        public ExerciseSetRepository(AppDbContext dbContext, IDALMapper<ExerciseSet, DAL.App.DTO.ExerciseSet> mapper) 
            : base(dbContext, mapper)
        {
        }
    }
}