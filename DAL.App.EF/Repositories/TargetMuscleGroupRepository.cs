using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class TargetMuscleGroupRepository : EFBaseRepository<AppDbContext, Domain.TargetMuscleGroup, DAL.App.DTO.TargetMuscleGroup>,
        ITargetMuscleGroupRepository
    {
        public TargetMuscleGroupRepository(AppDbContext repoDbContext) : base(repoDbContext, new BaseDALMapper<TargetMuscleGroup, DTO.TargetMuscleGroup>())
        {
        }
    }
}