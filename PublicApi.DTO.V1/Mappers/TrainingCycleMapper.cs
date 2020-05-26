using System;
using System.Linq;

namespace PublicApi.DTO.V1.Mappers
{
    public class TrainingCycleMapper
    {
        public static TrainingCycle MapBLLEntityToPublicDTO(BLL.App.DTO.TrainingCycle bllEntity)
        {
            if (bllEntity.EndingDate == null)
            {
                throw new ArgumentException("Mapping failed: EndingDate on BLL entity was null!");
            }
            return new TrainingCycle()
            {
                Id = bllEntity.Id,
                CycleNumber = bllEntity.CycleNumber,
                StartingDate = bllEntity.StartingDate,
                EndingDate = (DateTime) bllEntity.EndingDate,
                TrainingWeeks = bllEntity.TrainingWeeks
                    .OrderBy(week => week.WeekNumber)
                    .Select(TrainingWeekMapper.MapBLLEntityToPublicDTO)
            };
        }
    }
}