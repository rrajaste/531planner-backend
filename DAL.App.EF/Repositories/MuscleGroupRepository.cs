using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class MuscleGroupRepository : EFBaseRepository<AppDbContext, MuscleGroup, DTO.MuscleGroup>,
        IMuscleGroupRepository
    {
        public MuscleGroupRepository(AppDbContext repoDbContext, IDALMapper<MuscleGroup, DTO.MuscleGroup> mapper)
            : base(repoDbContext, mapper)
        {
        }
    }
}