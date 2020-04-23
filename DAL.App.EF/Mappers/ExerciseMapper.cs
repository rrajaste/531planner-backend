using System.Linq;
using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class ExerciseMapper : IBaseDALMapper<Domain.Exercise, Exercise>
    {
        private readonly ExerciseTypeMapper _exerciseTypeMapper = new ExerciseTypeMapper();
        private readonly MuscleGroupMapper _muscleGroupMapper = new MuscleGroupMapper();
        
        public Exercise MapDomainToDAL(Domain.Exercise domainObject) =>
            new Exercise()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                ExerciseTypeId = domainObject.ExerciseTypeId,
                ExerciseType = _exerciseTypeMapper.MapDomainToDAL(domainObject.ExerciseType),
                TargetMuscleGroups = domainObject.TargetMuscleGroups?
                    .Select(t => _muscleGroupMapper.mapDomainToDAl(t.MuscleGroup))
            };

        public Domain.Exercise MapDALToDomain(Exercise dalObject) =>
            new Domain.Exercise()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                ExerciseTypeId = dalObject.ExerciseTypeId,
                ExerciseType = _exerciseTypeMapper.MapDomainToDAL(dalObject.ExerciseType),
            };
    }
}