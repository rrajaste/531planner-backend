using System.Linq;
using Contracts.DAL.App;
using DAL.App.DTO;
using DAL.Base.EF;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class ExerciseMapper : EFBaseMapper, IDALMapper<Domain.Exercise, Exercise>
    {
        public ExerciseMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public Exercise MapDomainToDAL(Domain.Exercise domainObject) =>
            new Exercise()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                ExerciseTypeId = domainObject.ExerciseTypeId,
                ExerciseType = MapperContext.ExerciseTypeMapper.MapDomainToDAL(domainObject.ExerciseType),
                TargetMuscleGroups = domainObject.TargetMuscleGroups?
                    .Select(t => MapperContext.MuscleGroupMapper.MapDomainToDAL(t.MuscleGroup))
            };

        public Domain.Exercise MapDALToDomain(Exercise dalObject) =>
            new Domain.Exercise()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                ExerciseTypeId = dalObject.ExerciseTypeId,
            };
    }
}