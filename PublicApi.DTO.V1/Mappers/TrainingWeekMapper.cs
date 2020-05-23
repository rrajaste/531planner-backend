using System;
using System.Linq;

namespace PublicApi.DTO.V1.Mappers
{
    public class TrainingWeekMapper
    {
        public static TrainingWeek MapBLLEntityToPublicDTO(BLL.App.DTO.TrainingWeek bllEntity)
        {
            if (bllEntity.EndingDate == null)
            {
                throw new ArgumentException("Mapping failed: EndingDate on BLL entity was null!");
            }
            return new TrainingWeek()
            {
                Id = bllEntity.Id,
                WeekNumber = bllEntity.WeekNumber,
                StartingDate = bllEntity.StartingDate,
                EndingDate = (DateTime) bllEntity.EndingDate,
                IsDeload = bllEntity.IsDeload,
                TrainingDays = bllEntity.TrainingDays.Select(TrainingDayMapper.MapBLLEntityToPublicDTO)
            };
        }
    }
}