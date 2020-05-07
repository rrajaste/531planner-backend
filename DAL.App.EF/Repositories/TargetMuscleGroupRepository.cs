using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class TargetMuscleGroupRepository : EFBaseRepository<AppDbContext, TargetMuscleGroup, DAL.App.DTO.TargetMuscleGroup>,
        ITargetMuscleGroupRepository
    {
        public TargetMuscleGroupRepository(AppDbContext repoDbContext, IDALMapper<TargetMuscleGroup, DAL.App.DTO.TargetMuscleGroup> mapper) 
            : base(repoDbContext, mapper)
        {
        }
    }
}