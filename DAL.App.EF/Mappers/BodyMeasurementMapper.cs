using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class BodyMeasurementMapper : EFBaseMapper, IDALMapper<BodyMeasurement, DTO.BodyMeasurement>
    {
        public BodyMeasurementMapper(IAppDALMapperContext context) : base(context)
        {
        }

        public DTO.BodyMeasurement MapDomainToDAL(BodyMeasurement domainObject)
        {
            return new DTO.BodyMeasurement
            {
                AppUserId = domainObject.AppUserId,
                Arm = domainObject.Arm,
                BodyFatPercentage = domainObject.BodyFatPercentage,
                Chest = domainObject.Chest,
                Height = domainObject.Height,
                Hip = domainObject.Hip,
                Weight = domainObject.Weight,
                Id = domainObject.Id,
                LoggedAt = domainObject.LoggedAt,
                Waist = domainObject.Waist
            };
        }

        public BodyMeasurement MapDALToDomain(DTO.BodyMeasurement dalObject)
        {
            return new BodyMeasurement
            {
                AppUserId = dalObject.AppUserId,
                Arm = dalObject.Arm,
                BodyFatPercentage = dalObject.BodyFatPercentage,
                Chest = dalObject.Chest,
                Height = dalObject.Height,
                Hip = dalObject.Hip,
                Id = dalObject.Id,
                Waist = dalObject.Waist,
                Weight = dalObject.Weight
            };
        }
    }
}