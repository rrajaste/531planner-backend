using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class TargetMuscleGroupMapper : BLLBaseMapper, IBLLMapper<TargetMuscleGroup, App.DTO.TargetMuscleGroup>
    {
        public TargetMuscleGroupMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.TargetMuscleGroup MapDALToBLL(TargetMuscleGroup dalObject)
        {
            return new App.DTO.TargetMuscleGroup
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                MuscleGroupId = dalObject.MuscleGroupId
            };
        }

        public TargetMuscleGroup MapBLLToDAL(App.DTO.TargetMuscleGroup bllObject)
        {
            return new TargetMuscleGroup
            {
                Id = bllObject.Id,
                ExerciseId = bllObject.ExerciseId,
                MuscleGroupId = bllObject.MuscleGroupId
            };
        }
    }
}