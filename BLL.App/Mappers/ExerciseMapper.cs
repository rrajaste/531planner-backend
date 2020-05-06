using System;
using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class ExerciseMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.Exercise, Exercise>
    {
        public ExerciseMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public Exercise MapDALToBLL(DAL.App.DTO.Exercise dalObject) =>
            new Exercise()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                ExerciseTypeId = dalObject.ExerciseTypeId,
                ExerciseType = dalObject.ExerciseType == null 
                    ? null 
                    : BLLMapperContext.ExerciseTypeMapper.MapDALToBLL(dalObject.ExerciseType),
                TargetMuscleGroups = dalObject.TargetMuscleGroups?
                    .Select(BLLMapperContext.MuscleGroupMapper.MapDALToBLL)
            };

        public DAL.App.DTO.Exercise MapBLLToDAL(Exercise dalObject) =>
            new DAL.App.DTO.Exercise()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                ExerciseTypeId = dalObject.ExerciseTypeId,
            };
    }
}