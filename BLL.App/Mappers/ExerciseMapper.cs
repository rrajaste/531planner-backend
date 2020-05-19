using System;
using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App;
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
                TargetMuscleGroups = dalObject.TargetMuscleGroups?
                    .Select(BLLMapperContext.MuscleGroupMapper.MapDALToBLL)
            };

        public DAL.App.DTO.Exercise MapBLLToDAL(Exercise bllObject) =>
            new DAL.App.DTO.Exercise()
            {
                Id = bllObject.Id,
                Name = bllObject.Name,
                Description = bllObject.Description,
            };
    }
}