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
                Chest = bllEntity.Chest,
                Waist = bllEntity.Waist,
                Hip = bllEntity.Hip,
                Arm = bllEntity.Arm,
                BodyFatPercentage = bllEntity.BodyFatPercentage,
                LoggedAt = bllEntity.LoggedAt.ToString(CultureInfo.CurrentCulture),
                UnitType = bllEntity.UnitType == null ? "" : bllEntity.UnitType.Name,
                UnitTypeId = bllEntity.UnitTypeId.ToString()
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
            bllEntity.UnitTypeId = Guid.Parse(dto.UnitTypeId);
            return bllEntity;
        }
    }
}