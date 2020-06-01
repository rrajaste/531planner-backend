using System.Linq;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class TrainingWeekMapper : BLLBaseMapper, IBLLMapper<TrainingWeek, App.DTO.TrainingWeek>
    {
        public TrainingWeekMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.TrainingWeek MapDALToBLL(TrainingWeek dalObject)
        {
            return new App.DTO.TrainingWeek
            {
                Id = dalObject.Id,
                WeekNumber = dalObject.WeekNumber,
                StartingDate = dalObject.StartingDate,
                EndingDate = dalObject.EndingDate,
                IsDeload = dalObject.IsDeload,
                TrainingCycle = dalObject.TrainingCycle == null
                    ? null
                    : BLLMapperContext.TrainingCycleMapper.MapDALToBLL(dalObject.TrainingCycle),
                TrainingCycleId = dalObject.TrainingCycleId,
                TrainingDays =
                    dalObject.TrainingDays?.Select(BLLMapperContext.TrainingDayMapper.MapDALToUserTrainingDay)
            };
        }

        public TrainingWeek MapBLLToDAL(App.DTO.TrainingWeek bllObject)
        {
            return new TrainingWeek
            {
                Id = bllObject.Id,
                WeekNumber = bllObject.WeekNumber,
                StartingDate = bllObject.StartingDate,
                EndingDate = bllObject.EndingDate,
                IsDeload = bllObject.IsDeload,
                TrainingCycleId = bllObject.TrainingCycleId,
                TrainingDays = bllObject.TrainingDays?
                    .Select(BLLMapperContext.TrainingDayMapper.MapUserTrainingDayToDALEntity)
                    .ToList()
            };
        }
    }
}