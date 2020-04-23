using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;

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