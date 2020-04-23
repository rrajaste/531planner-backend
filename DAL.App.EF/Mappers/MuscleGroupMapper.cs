using System.Linq;
using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class MuscleGroupMapper : IBaseDALMapper<Domain.MuscleGroup, MuscleGroup>
    {
        public MuscleGroup MapDomainToDAL(Domain.MuscleGroup domainObject) =>
            new MuscleGroup()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                Muscles = domainObject.Muscles?.Select(_muscleMapper.MapDomainToDAL)
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