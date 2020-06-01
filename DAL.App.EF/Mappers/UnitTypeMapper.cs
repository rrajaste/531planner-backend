using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class UnitTypeMapper : IDALMapper<UnitType, DTO.UnitType>
    {
        private readonly IAppDALMapperContext _context;

        public UnitTypeMapper(IAppDALMapperContext context)
        {
            _context = context;
        }

        public DTO.UnitType MapDomainToDAL(UnitType domainObject)
        {
            return new DTO.UnitType
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description
            };
        }

        public UnitType MapDALToDomain(DTO.UnitType dalObject)
        {
            return new UnitType
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
        }
    }
}