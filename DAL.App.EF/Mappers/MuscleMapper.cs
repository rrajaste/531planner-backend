using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class MuscleMapper : EFBaseMapper, IDALMapper<Muscle, DTO.Muscle>
    {
        public MuscleMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.Muscle MapDomainToDAL(Muscle domainObject)
        {
            return new DTO.Muscle
            {
                Id = domainObject.Id,
                MuscleGroupId = domainObject.MuscleGroupId,
                Description = domainObject.Description,
                Name = domainObject.Name,
                MuscleGroup = domainObject.MuscleGroup == null
                    ? null
                    : DALMapperContext.MuscleGroupMapper.MapDomainToDAL(domainObject.MuscleGroup)
            };
        }

        public Muscle MapDALToDomain(DTO.Muscle dalObject)
        {
            return new Muscle
            {
                Id = dalObject.Id,
                Description = dalObject.Description,
                Name = dalObject.Name,
                MuscleGroupId = dalObject.MuscleGroupId
            };
        }
    }
}