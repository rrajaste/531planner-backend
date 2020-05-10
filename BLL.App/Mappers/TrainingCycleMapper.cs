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
    public class TrainingCycleMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.TrainingCycle, TrainingCycle>
    {
        public TrainingCycleMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public TrainingCycle MapDALToBLL(DAL.App.DTO.TrainingCycle dalObject) =>
            new TrainingCycle()
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

        public DAL.App.DTO.TrainingCycle MapBLLToDAL(TrainingCycle bllObject) =>
            new DAL.App.DTO.TrainingCycle()
            {
                Id = bllObject.Id,
                CycleNumber = bllObject.CycleNumber,
                StartingDate = bllObject.StartingDate,
                EndingDate = bllObject.EndingDate,
                WorkoutRoutineId = bllObject.WorkoutRoutineId
            };
    }
}