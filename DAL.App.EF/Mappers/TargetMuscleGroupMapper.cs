using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class TargetMuscleGroupMapper : EFBaseMapper, IDALMapper<Domain.TargetMuscleGroup, TargetMuscleGroup>
    {
        public TargetMuscleGroupMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
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