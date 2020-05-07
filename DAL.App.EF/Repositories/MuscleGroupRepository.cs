using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class MuscleGroupRepository : EFBaseRepository<AppDbContext, MuscleGroup, DAL.App.DTO.MuscleGroup>,
        IMuscleGroupRepository
    {
        public MuscleGroupRepository(AppDbContext repoDbContext, IDALMapper<MuscleGroup, DTO.MuscleGroup> mapper) 
            : base(repoDbContext, mapper)
        {
        }
    }
}