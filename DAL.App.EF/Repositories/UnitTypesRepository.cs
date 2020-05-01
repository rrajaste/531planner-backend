using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Contracts.DAL.App.Mappers;

namespace DAL.App.EF.Repositories
{
    public class UnitTypesRepository : EFBaseRepository<AppDbContext, Domain.UnitType, DAL.App.DTO.UnitType>, IUnitTypesRepository
    {
        public UnitTypesRepository(AppDbContext repoDbContext, IDALMapper<Domain.UnitType, DAL.App.DTO.UnitType> mapper) 
            : base(repoDbContext, mapper)
        {
        }
    }
}