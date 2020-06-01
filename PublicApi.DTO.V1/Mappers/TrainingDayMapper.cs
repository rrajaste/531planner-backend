using System;
using System.Linq;
using BLL.App.DTO;

namespace PublicApi.DTO.V1.Mappers
{
    public class TrainingDayMapper
    {
        public static TrainingDay MapBLLEntityToPublicDTO(UserTrainingDay bllEntity)
        {
            if (bllEntity.TrainingDayType == null)
                throw new ArgumentException("Mapping failed: TrainingDayType on BLL entity was null!");
            return new TrainingDay
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