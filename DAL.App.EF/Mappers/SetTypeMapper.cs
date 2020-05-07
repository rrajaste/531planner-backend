using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class SetTypeMapper : IDALMapper<Domain.App.SetType, SetType>
    {
        private readonly IAppDALMapperContext _context;
        public SetTypeMapper(IAppDALMapperContext context)
        {
            _context = context;
        }
        
        public SetType MapDomainToDAL(Domain.App.SetType domainObject) =>
            new SetType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description
            };

        public Domain.App.SetType MapDALToDomain(SetType dalObject) =>
            new Domain.App.SetType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
    }
}