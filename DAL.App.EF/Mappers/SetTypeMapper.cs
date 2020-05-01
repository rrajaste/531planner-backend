using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class SetTypeMapper : IDALMapper<Domain.SetType, SetType>
    {
        private readonly IAppMapperContext _context;
        public SetTypeMapper(IAppMapperContext context)
        {
            _context = context;
        }
        
        public SetType MapDomainToDAL(Domain.SetType domainObject) =>
            new SetType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description
            };

        public Domain.SetType MapDALToDomain(SetType dalObject) =>
            new Domain.SetType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
    }
}