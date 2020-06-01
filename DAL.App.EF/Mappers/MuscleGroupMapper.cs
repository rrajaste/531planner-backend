using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class MuscleGroupMapper : EFBaseMapper, IDALMapper<MuscleGroup, DTO.MuscleGroup>
    {
        public MuscleGroupMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.MuscleGroup MapDomainToDAL(MuscleGroup domainObject)
        {
            return new DTO.MuscleGroup
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                Muscles = domainObject.Muscles?.Select(DALMapperContext.MuscleMapper.MapDomainToDAL)
            };
        }

        public MuscleGroup MapDALToDomain(DTO.MuscleGroup dalObject)
        {
            return new MuscleGroup
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
        }
    }
}