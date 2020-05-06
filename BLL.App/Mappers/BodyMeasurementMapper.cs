using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.DAL.App;

namespace BLL.Mappers
{
    public class BodyMeasurementMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.BodyMeasurement, BodyMeasurement>
    {
        public BodyMeasurementMapper(IAppBLLMapperContext context) : base(context)
        {
        }

        public BodyMeasurement MapDALToBLL(DAL.App.DTO.BodyMeasurement dalObject)
        {
            var bodyMeasurement = new BodyMeasurement() {
            };
            bodyMeasurement.AppUserId = dalObject.AppUserId;
            bodyMeasurement.Arm = dalObject.Arm;
            bodyMeasurement.BodyFatPercentage = dalObject.BodyFatPercentage;
            bodyMeasurement.Chest = dalObject.Chest;
            bodyMeasurement.Height = dalObject.Height;
            bodyMeasurement.Hip = dalObject.Height;
            bodyMeasurement.Id = dalObject.Id;
            bodyMeasurement.LoggedAt = dalObject.LoggedAt;
            if (dalObject.UnitType != null)
            {
                BLLMapperContext.UnitTypeMapper.MapDALToBLL(dalObject.UnitType);
            }
            bodyMeasurement.UnitTypeId = dalObject.UnitTypeId;
            bodyMeasurement.Waist = dalObject.Waist;
            return bodyMeasurement;
        }
        public DAL.App.DTO.BodyMeasurement MapBLLToDAL(BodyMeasurement bllObject)
        {
            return new DAL.App.DTO.BodyMeasurement()
            {
                AppUserId = bllObject.AppUserId,
                Arm = bllObject.Arm,
                BodyFatPercentage = bllObject.BodyFatPercentage,
                Chest = bllObject.Chest,
                Height = bllObject.Height,
                Hip = bllObject.Height,
                Id = bllObject.Id,
                UnitTypeId = bllObject.UnitTypeId,
                Waist = bllObject.Waist
            };
        }
    }
}