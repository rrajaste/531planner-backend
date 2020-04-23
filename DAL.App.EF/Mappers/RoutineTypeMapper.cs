using Contracts.DAL.App;
using DAL.App.DTO;
using DAL.Base.EF;
using DAL.Base.Mappers;

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
                Description = domainObject.Description
            };

        public Domain.RoutineType MapDALToDomain(RoutineType dalObject) =>
            new Domain.RoutineType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
    }
}