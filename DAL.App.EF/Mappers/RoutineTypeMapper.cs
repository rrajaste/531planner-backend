using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class RoutineTypeMapper : EFBaseMapper, IDALMapper<Domain.RoutineType, RoutineType>
    {
        public RoutineTypeMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public RoutineType MapDomainToDAL(Domain.RoutineType domainObject) =>
            new RoutineType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                ParentType = domainObject.ParentType == null 
                    ? null 
                    : MapDomainToDAL(domainObject.ParentType),
                SubTypes = domainObject.SubTypes?.Select(MapDomainToDAL)
            };

        public Domain.RoutineType MapDALToDomain(RoutineType dalObject) =>
            new Domain.RoutineType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                ParentTypeId = dalObject.ParentTypeId
            };
    }
}