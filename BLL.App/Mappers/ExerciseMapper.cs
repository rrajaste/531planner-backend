using System.Linq;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class ExerciseMapper : BLLBaseMapper, IBLLMapper<Exercise, App.DTO.Exercise>
    {
        public ExerciseMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.Exercise MapDALToBLL(Exercise dalObject)
        {
            return new App.DTO.Exercise
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                TargetMuscleGroups = dalObject.TargetMuscleGroups?
                    .Select(BLLMapperContext.MuscleGroupMapper.MapDALToBLL)
            };
        }

        public Exercise MapBLLToDAL(App.DTO.Exercise bllObject)
        {
            return new Exercise
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description
            };
        }
    }
}