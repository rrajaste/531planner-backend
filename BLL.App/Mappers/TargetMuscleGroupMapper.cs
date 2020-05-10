using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class TargetMuscleGroupMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.TargetMuscleGroup, TargetMuscleGroup>
    {
        public TargetMuscleGroupMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public TargetMuscleGroup MapDALToBLL(DAL.App.DTO.TargetMuscleGroup dalObject) =>
            new TargetMuscleGroup()
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                MuscleGroupId = dalObject.MuscleGroupId
            };

        public DAL.App.DTO.TargetMuscleGroup MapBLLToDAL(TargetMuscleGroup bllObject) =>
            new DAL.App.DTO.TargetMuscleGroup()
            {
                Id = bllObject.Id,
                ExerciseId = bllObject.ExerciseId,
                MuscleGroupId = bllObject.MuscleGroupId
            };
    }
}