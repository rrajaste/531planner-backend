using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class UnitTypesRepository : EFBaseRepository<AppDbContext, UnitType, DTO.UnitType>, IUnitTypesRepository
    {
        public UnitTypesRepository(AppDbContext repoDbContext, IDALMapper<UnitType, DTO.UnitType> mapper)
            : base(repoDbContext, mapper)
        {
        }
    }
}