using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class RoutineTypeMapper : EFBaseMapper, IDALMapper<Domain.App.RoutineType, RoutineType>
    {
        public RoutineTypeMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public RoutineType MapDomainToDAL(Domain.App.RoutineType domainObject)
        {
            return new RoutineType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                ParentTypeId = domainObject.ParentTypeId,
                SubTypes = domainObject.SubTypes?.Select(MapDomainToDAL)
            };
        }

        public Domain.App.RoutineType MapDALToDomain(RoutineType dalObject) =>
            new Domain.App.RoutineType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                ParentTypeId = dalObject.ParentTypeId
            };
    }
}