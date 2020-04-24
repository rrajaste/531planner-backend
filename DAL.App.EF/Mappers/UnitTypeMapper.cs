using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class UnitTypeMapper : IDALMapper<Domain.UnitType, UnitType>
    {
        private readonly IAppMapperContext _context;
        public UnitTypeMapper(IAppMapperContext context)
        {
            _context = context;
        }
        
        public UnitType MapDomainToDAL(Domain.UnitType domainObject) =>
            new UnitType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description
            };

        public Domain.UnitType MapDALToDomain(UnitType dalObject) =>
            new Domain.UnitType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
    }
}