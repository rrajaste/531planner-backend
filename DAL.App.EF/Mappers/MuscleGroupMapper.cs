using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class MuscleGroupMapper : EFBaseMapper, IDALMapper<Domain.MuscleGroup, MuscleGroup>
    {
        public MuscleGroupMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public MuscleGroup MapDomainToDAL(Domain.MuscleGroup domainObject) =>
            new MuscleGroup()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                Muscles = domainObject.Muscles?.Select(MapperContext.MuscleMapper.MapDomainToDAL)
            };

        public Domain.MuscleGroup MapDALToDomain(MuscleGroup dalObject) =>
            new Domain.MuscleGroup()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
            };
    }
}