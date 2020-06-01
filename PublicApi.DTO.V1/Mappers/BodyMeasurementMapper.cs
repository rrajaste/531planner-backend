using System;
using System.Globalization;

namespace PublicApi.DTO.V1.Mappers
{
    public static class BodyMeasurementMapper
    {
        public static BodyMeasurement MapBLLEntityToPublicDTO(BLL.App.DTO.BodyMeasurement bllEntity)
        {
            return new BodyMeasurement()
            {
                Id = bllEntity.Id.ToString(),
                Height = bllEntity.Height,
                Weight = bllEntity.Weight,
                Chest = bllEntity.Chest ?? 0,
                Waist = bllEntity.Waist ?? 0,
                Hip = bllEntity.Hip ?? 0,
                Arm = bllEntity.Arm ?? 0,
                BodyFatPercentage = bllEntity.BodyFatPercentage,
                LoggedAt = bllEntity.LoggedAt,
            };
        }
        
        public static BodyMeasurementStatistics MapBLLEntityToPublicDTO(BLL.App.DTO.BodyMeasurementStatistics bllEntity)
        {
            return new BodyMeasurementStatistics()
            {
                FirstLogAt = bllEntity.FirstLogAt,
                BMIChange = (float) Math.Round(bllEntity.BMIChange, 2),
                BodyFatPercentageChange = (float) Math.Round(bllEntity.BodyFatPercentageChange, 2),
                CurrentBMI = (float) Math.Round(bllEntity.CurrentBMI, 2),
                CurrentBodyFatPercentage = (float) Math.Round(bllEntity.CurrentBodyFatPercentage, 2),
                CurrentWeight = (float) Math.Round(bllEntity.CurrentWeight, 2),
                WeightChange = (float) Math.Round(bllEntity.WeightChange, 2)
            };
        }
        
        public static BLL.App.DTO.BodyMeasurement MapPublicDTOToBLLEntity<TDto>(TDto dto)
            where TDto : BodyMeasurementCreate => 
            MapPublicDTOFieldsToBLLEntity(dto, new BLL.App.DTO.BodyMeasurement());

        public static BLL.App.DTO.BodyMeasurement MapPublicDTOFieldsToBLLEntity<TDto>(TDto dto, BLL.App.DTO.BodyMeasurement bllEntity)
            where TDto : BodyMeasurementCreate
        {
            bllEntity.Height = dto.Height;
            bllEntity.Weight = dto.Weight;
            bllEntity.Chest = dto.Chest;
            bllEntity.Waist = dto.Waist;
            bllEntity.Hip = dto.Hip;
            bllEntity.Arm = dto.Arm;
            bllEntity.BodyFatPercentage = dto.BodyFatPercentage;
            return bllEntity;
        }
    }
}