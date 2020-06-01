using System.Linq;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class TrainingCycleMapper : BLLBaseMapper, IBLLMapper<TrainingCycle, App.DTO.TrainingCycle>
    {
        public TrainingCycleMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.TrainingCycle MapDALToBLL(TrainingCycle dalObject)
        {
            return new App.DTO.TrainingCycle
            {
                Id = dalObject.Id,
                CycleNumber = dalObject.CycleNumber,
                StartingDate = dalObject.StartingDate,
                EndingDate = dalObject.EndingDate,
                TrainingWeeks = dalObject.TrainingWeeks?.Select(BLLMapperContext.TrainingWeekMapper.MapDALToBLL),
                WorkoutRoutine = dalObject.WorkoutRoutine == null
                    ? null
                    : BLLMapperContext.WorkoutRoutineMapper.MapDALToBLL(dalObject.WorkoutRoutine),
                WorkoutRoutineId = dalObject.WorkoutRoutineId
            };
        }

        public TrainingCycle MapBLLToDAL(App.DTO.TrainingCycle bllObject)
        {
            return new TrainingCycle
            {
                Id = bllObject.Id,
                CycleNumber = bllObject.CycleNumber,
                StartingDate = bllObject.StartingDate,
                EndingDate = bllObject.EndingDate,
                WorkoutRoutineId = bllObject.WorkoutRoutineId,
                TrainingWeeks = bllObject.TrainingWeeks?.Select(BLLMapperContext.TrainingWeekMapper.MapBLLToDAL)
            };
        }
    }
}