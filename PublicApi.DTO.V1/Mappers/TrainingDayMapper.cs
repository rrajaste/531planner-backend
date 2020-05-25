using System;
using System.Linq;

namespace PublicApi.DTO.V1.Mappers
{
    public class TrainingDayMapper
    {
        public static TrainingDay MapBLLEntityToPublicDTO(BLL.App.DTO.UserTrainingDay bllEntity)
        {
            if (bllEntity.TrainingDayType == null)
            {
                throw new ArgumentException("Mapping failed: TrainingDayType on BLL entity was null!");
            }
            return new TrainingDay()
            {
                Id = bllEntity.Id,
                Date = bllEntity.Date,
                Name = bllEntity.TrainingDayType.Name,
                Description = bllEntity.TrainingDayType.Description,
                MainLifts = bllEntity.MainLifts.Select(ExerciseMapper.MapBLLEntityToPublicDTO),
                AccessoryLifts = bllEntity.AccessoryLifts.Select(ExerciseMapper.MapBLLEntityToPublicDTO)
            };
        }
    }
}