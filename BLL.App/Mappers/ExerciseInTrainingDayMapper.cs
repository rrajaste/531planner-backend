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
    public class ExerciseInTrainingDayMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.ExerciseInTrainingDay, ExerciseInTrainingDay>
    {
        public ExerciseInTrainingDayMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public ExerciseInTrainingDay MapDALToBLL(DAL.App.DTO.ExerciseInTrainingDay dalObject) =>
            new ExerciseInTrainingDay()
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                Exercise = dalObject.Exercise == null 
                    ? null 
                    : BLLMapperContext.ExerciseMapper.MapDALToBLL(dalObject.Exercise),
                ExerciseTypeId = dalObject.ExerciseTypeId,
                ExerciseType = dalObject.ExerciseType == null 
                    ? null 
                    : BLLMapperContext.ExerciseTypeMapper.MapDALToBLL(dalObject.ExerciseType),
                ExerciseSets = dalObject.ExerciseSets?.Select(BLLMapperContext.ExerciseSetMapper.MapDALToBLL)
            };

        public DAL.App.DTO.ExerciseInTrainingDay MapBLLToDAL(ExerciseInTrainingDay bllObject) =>
            new DAL.App.DTO.ExerciseInTrainingDay()
            {
                Id = bllObject.Id,
                ExerciseId = bllObject.ExerciseId,
                ExerciseTypeId = bllObject.ExerciseTypeId,
                TrainingDayId = bllObject.TrainingDayId
            };
    }
}