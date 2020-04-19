using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class MuscleGroupRepository : EFBaseRepository<AppDbContext, Domain.MuscleGroup, DAL.App.DTO.MuscleGroup>,
        IMuscleGroupRepository
    {
        public MuscleGroupRepository(AppDbContext repoDbContext) : base(repoDbContext, new BaseDALMapper<MuscleGroup, DTO.MuscleGroup>())
        {
        }
    }
}