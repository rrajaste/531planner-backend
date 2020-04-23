using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;

namespace DAL.App.EF.Repositories
{
    public class TargetMuscleGroupRepository : EFBaseRepository<AppDbContext, Domain.TargetMuscleGroup, DAL.App.DTO.TargetMuscleGroup>,
        ITargetMuscleGroupRepository
    {
        public TargetMuscleGroupRepository(AppDbContext repoDbContext, IDALMapper<Domain.TargetMuscleGroup, DAL.App.DTO.TargetMuscleGroup> mapper) 
            : base(repoDbContext, mapper)
        {
        }
    }
}