using Contracts.DAL.App;
using DAL.App.DTO;
using DAL.Base.EF;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class TargetMuscleGroupMapper : EFBaseMapper, IDALMapper<Domain.TargetMuscleGroup, TargetMuscleGroup>
    {
        public TargetMuscleGroupMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public TargetMuscleGroup MapDomainToDAL(Domain.TargetMuscleGroup domainObject) =>
            new TargetMuscleGroup()
            {
                Id = domainObject.Id,
                ExerciseId = domainObject.ExerciseId,
                MuscleGroupId = domainObject.MuscleGroupId
            };

        public Domain.TargetMuscleGroup MapDALToDomain(TargetMuscleGroup dalObject) =>
            new Domain.TargetMuscleGroup()
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                MuscleGroupId = dalObject.MuscleGroupId
            };
    }
}