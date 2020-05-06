using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class ExerciseSetMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.ExerciseSet, ExerciseSet>
    {
        public ExerciseSetMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public ExerciseSet MapDALToBLL(DAL.App.DTO.ExerciseSet dalObject) =>
            new ExerciseSet()
            {
                Id = dalObject.Id,
                Completed = dalObject.Completed,
                Distance = dalObject.Distance,
                Duration = dalObject.Duration,
                ExerciseId = dalObject.ExerciseId,
                Exercise = dalObject.Exercise == null 
                    ? null 
                    : BLLMapperContext.ExerciseMapper.MapDALToBLL(dalObject.Exercise),
                NrOfReps = dalObject.NrOfReps,
                SetNumber = dalObject.SetNumber,
                TrainingDay = dalObject.TrainingDay == null 
                ? null 
                : BLLMapperContext.TrainingDayMapper.MapDALToBLL(dalObject.TrainingDay),
                TrainingDayId = dalObject.TrainingDayId,
            };

        public DAL.App.DTO.ExerciseSet MapBLLToDAL(ExerciseSet bllObject) =>
            new DAL.App.DTO.ExerciseSet()
            {
                Id = bllObject.Id,
                Completed = bllObject.Completed,
                Distance = bllObject.Distance,
                Duration = bllObject.Duration,
                ExerciseId = bllObject.ExerciseId,
                NrOfReps = bllObject.NrOfReps,
                SetNumber = bllObject.SetNumber,
                TrainingDayId = bllObject.TrainingDayId,
            };
    }
}
