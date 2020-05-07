using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class UnitTypeMapper : IDALMapper<Domain.App.UnitType, UnitType>
    {
        private readonly IAppDALMapperContext _context;
        public UnitTypeMapper(IAppDALMapperContext context)
        {
            _context = context;
        }
        
        public UnitType MapDomainToDAL(Domain.App.UnitType domainObject) =>
            new UnitType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description
            };

        public Domain.App.UnitType MapDALToDomain(UnitType dalObject) =>
            new Domain.App.UnitType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
    }
}