using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class TargetMuscleGroupMapper : EFBaseMapper, IDALMapper<Domain.App.TargetMuscleGroup, TargetMuscleGroup>
    {
        public TargetMuscleGroupMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public TargetMuscleGroup MapDomainToDAL(Domain.App.TargetMuscleGroup domainObject) =>
            new TargetMuscleGroup()
            {
                Id = domainObject.Id,
                ExerciseId = domainObject.ExerciseId,
                MuscleGroupId = domainObject.MuscleGroupId
            };

        public Domain.App.TargetMuscleGroup MapDALToDomain(TargetMuscleGroup dalObject) =>
            new Domain.App.TargetMuscleGroup()
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                MuscleGroupId = dalObject.MuscleGroupId
            };
    }
}