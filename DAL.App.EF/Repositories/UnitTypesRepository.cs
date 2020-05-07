using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Contracts.DAL.App.Mappers;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class UnitTypesRepository : EFBaseRepository<AppDbContext, UnitType, DAL.App.DTO.UnitType>, IUnitTypesRepository
    {
        public UnitTypesRepository(AppDbContext repoDbContext, IDALMapper<UnitType, DAL.App.DTO.UnitType> mapper) 
            : base(repoDbContext, mapper)
        {
        }
    }
}