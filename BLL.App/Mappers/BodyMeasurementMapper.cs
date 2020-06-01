using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class BodyMeasurementMapper : BLLBaseMapper, IBLLMapper<BodyMeasurement, App.DTO.BodyMeasurement>
    {
        public BodyMeasurementMapper(IAppBLLMapperContext context) : base(context)
        {
        }

        public App.DTO.BodyMeasurement MapDALToBLL(BodyMeasurement dalObject)
        {
            return new App.DTO.BodyMeasurement
            {
                AppUserId = dalObject.AppUserId,
                Arm = dalObject.Arm,
                BodyFatPercentage = dalObject.BodyFatPercentage,
                Chest = dalObject.Chest,
                Height = dalObject.Height,
                Hip = dalObject.Hip,
                Id = dalObject.Id,
                LoggedAt = dalObject.LoggedAt,
                Weight = dalObject.Weight,
                Waist = dalObject.Waist
            };
        }

        public BodyMeasurement MapBLLToDAL(App.DTO.BodyMeasurement bllObject)
        {
            return new BodyMeasurement
            {
                AppUserId = bllObject.AppUserId,
                Weight = bllObject.Weight,
                Arm = bllObject.Arm,
                BodyFatPercentage = bllObject.BodyFatPercentage,
                Chest = bllObject.Chest,
                Height = bllObject.Height,
                Hip = bllObject.Hip,
                Id = bllObject.Id,
                Waist = bllObject.Waist
            };
        }
    }
}