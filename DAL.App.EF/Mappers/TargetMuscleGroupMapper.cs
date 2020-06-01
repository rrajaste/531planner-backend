using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class TargetMuscleGroupMapper : EFBaseMapper, IDALMapper<TargetMuscleGroup, DTO.TargetMuscleGroup>
    {
        public TargetMuscleGroupMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.TargetMuscleGroup MapDomainToDAL(TargetMuscleGroup domainObject)
        {
            return new DTO.TargetMuscleGroup
            {
                Id = domainObject.Id,
                ExerciseId = domainObject.ExerciseId,
                MuscleGroupId = domainObject.MuscleGroupId,
                Intensity = domainObject.Intensity
            };
        }

        public TargetMuscleGroup MapDALToDomain(DTO.TargetMuscleGroup dalObject)
        {
            return new TargetMuscleGroup
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                MuscleGroupId = dalObject.MuscleGroupId,
                Intensity = dalObject.Intensity
            };
        }
    }
}