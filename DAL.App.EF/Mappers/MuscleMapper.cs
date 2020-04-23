using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class MuscleMapper : IBaseDALMapper<Domain.Muscle, Muscle>
    {
        public Muscle MapDomainToDAL(Domain.Muscle domainObject) =>
            new Muscle()
            {
                Id = domainObject.Id,
                Description = domainObject.Description,
                Name = domainObject.Name,
                MuscleGroup = _muscleGroupMapper.MapDomainToDAL(domainObject.MuscleGroup)
            };

        public Domain.Muscle MapDALToDomain(Muscle dalObject) => 
            new Domain.Muscle()
            {
                Id = dalObject.Id,
                Description = dalObject.Description,
                Name = dalObject.Name,
            };
    }
}00