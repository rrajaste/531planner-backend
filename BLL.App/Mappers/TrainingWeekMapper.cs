using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class TrainingWeekMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.TrainingWeek, TrainingWeek>
    {
        public TrainingWeekMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public TrainingWeek MapDALToBLL(DAL.App.DTO.TrainingWeek dalObject) =>
            new TrainingWeek()
            {
                Id = dalObject.Id,
                WeekNumber = dalObject.WeekNumber,
                StartingDate = dalObject.StartingDate,
                EndingDate = dalObject.EndingDate,
                IsDeload = dalObject.IsDeload,
                TrainingCycle = dalObject.TrainingCycle == null ? 
                    null 
                    : BLLMapperContext.TrainingCycleMapper.MapDALToBLL(dalObject.TrainingCycle),
                TrainingCycleId = dalObject.TrainingCycleId,
                TrainingDays = dalObject.TrainingDays?.Select(BLLMapperContext.TrainingDayMapper.MapDALToBLL),
            };

        public DAL.App.DTO.TrainingWeek MapBLLToDAL(TrainingWeek bllObject) =>
            new DAL.App.DTO.TrainingWeek()
            {
                Id = bllObject.Id,
                WeekNumber = bllObject.WeekNumber,
                StartingDate = bllObject.StartingDate,
                EndingDate = bllObject.EndingDate,
                IsDeload = bllObject.IsDeload,
                TrainingCycleId = bllObject.TrainingCycleId,
            };
    }
}