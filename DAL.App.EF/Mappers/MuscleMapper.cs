using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class MuscleMapper : EFBaseMapper, IDALMapper<Domain.Muscle, Muscle>
    {
        public MuscleMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public Muscle MapDomainToDAL(Domain.Muscle domainObject) =>
            new Muscle()
            {
                Id = domainObject.Id,
                MuscleGroupId = domainObject.MuscleGroupId,
                Description = domainObject.Description,
                Name = domainObject.Name,
                MuscleGroup = domainObject.MuscleGroup == null 
                    ? null 
                    : DALMapperContext.MuscleGroupMapper.MapDomainToDAL(domainObject.MuscleGroup)
            };

        public Domain.Muscle MapDALToDomain(Muscle dalObject) => 
            new Domain.Muscle()
            {
                Id = dalObject.Id,
                Description = dalObject.Description,
                Name = dalObject.Name,
                MuscleGroupId = dalObject.MuscleGroupId
            };
    }
}
