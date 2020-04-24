using Contracts.DAL.App;
using DAL.App.DTO;
using DAL.Base.EF;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class MuscleMapper : EFBaseMapper, IDALMapper<Domain.Muscle, Muscle>
    {
        public MuscleMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public Muscle MapDomainToDAL(Domain.Muscle domainObject) =>
            new Muscle()
            {
                Id = domainObject.Id,
                Description = domainObject.Description,
                Name = domainObject.Name,
                MuscleGroup = MapperContext.MuscleGroupMapper.MapDomainToDAL(domainObject.MuscleGroup)
            };

        public Domain.Muscle MapDALToDomain(Muscle dalObject) => 
            new Domain.Muscle()
            {
                Id = dalObject.Id,
                Description = dalObject.Description,
                Name = dalObject.Name,
            };
    }
}
