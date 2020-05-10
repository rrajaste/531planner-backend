using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using Contracts.DAL.App;

namespace BLL.Mappers
{
    public class BodyMeasurementMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.BodyMeasurement, BodyMeasurement>
    {
        public BodyMeasurementMapper(IAppBLLMapperContext context) : base(context)
        {
        }

        public BodyMeasurement MapDALToBLL(DAL.App.DTO.BodyMeasurement dalObject) =>
            new BodyMeasurement()
            {
                AppUserId = dalObject.AppUserId,
                Arm = dalObject.Arm,
                BodyFatPercentage = dalObject.BodyFatPercentage,
                Chest = dalObject.Chest,
                Height = dalObject.Height,
                Hip = dalObject.Hip,
                Id = dalObject.Id,
                LoggedAt = dalObject.LoggedAt,
                UnitType = dalObject.UnitType == null
                    ? null
                    : BLLMapperContext.UnitTypeMapper.MapDALToBLL(dalObject.UnitType),
                UnitTypeId = dalObject.UnitTypeId,
                Weight = dalObject.Weight,
                Waist = dalObject.Waist
            };
        
        public DAL.App.DTO.BodyMeasurement MapBLLToDAL(BodyMeasurement bllObject)
        {
            return new DAL.App.DTO.BodyMeasurement()
            {
                AppUserId = bllObject.AppUserId,
                Weight = bllObject.Weight,
                Arm = bllObject.Arm,
                BodyFatPercentage = bllObject.BodyFatPercentage,
                Chest = bllObject.Chest,
                Height = bllObject.Height,
                Hip = bllObject.Hip,
                Id = bllObject.Id,
                UnitTypeId = bllObject.UnitTypeId,
                Waist = bllObject.Waist
            };
        }
    }
}