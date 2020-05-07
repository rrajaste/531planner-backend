using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class MuscleGroupMapper : EFBaseMapper, IDALMapper<Domain.App.MuscleGroup, MuscleGroup>
    {
        public MuscleGroupMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public MuscleGroup MapDomainToDAL(Domain.App.MuscleGroup domainObject) =>
            new MuscleGroup()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                Muscles = domainObject.Muscles?.Select(DALMapperContext.MuscleMapper.MapDomainToDAL)
            };

        public Domain.App.MuscleGroup MapDALToDomain(MuscleGroup dalObject) =>
            new Domain.App.MuscleGroup()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
            };
    }
}