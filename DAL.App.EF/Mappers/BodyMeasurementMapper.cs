using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class BodyMeasurementMapper : EFBaseMapper, IDALMapper<Domain.App.BodyMeasurement, BodyMeasurement>
    {
        public BodyMeasurementMapper(IAppDALMapperContext context) : base(context)
        {
        }
        
        public BodyMeasurement MapDomainToDAL(Domain.App.BodyMeasurement domainObject) => 
            new BodyMeasurement(){
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

        public Domain.App.BodyMeasurement MapDALToDomain(BodyMeasurement dalObject)
        {
            return new Domain.App.BodyMeasurement()
            {
                AppUserId = dalObject.AppUserId,
                Arm = dalObject.Arm,
                BodyFatPercentage = dalObject.BodyFatPercentage,
                Chest = dalObject.Chest,
                Height = dalObject.Height,
                Hip = dalObject.Hip,
                Id = dalObject.Id,
                Waist = dalObject.Waist,
                Weight = dalObject.Weight,
            };
        }
    }
}