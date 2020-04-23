using Contracts.DAL.App;
using DAL.App.DTO;
using DAL.Base.EF;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class BodyMeasurementMapper : EFBaseMapper, IDALMapper<Domain.BodyMeasurement, BodyMeasurement>
    {
        public BodyMeasurementMapper(IAppMapperContext context) : base(context)
        {
        }
        
        public BodyMeasurement MapDomainToDAL(Domain.BodyMeasurement domainObject) => 
            new BodyMeasurement(){
                AppUserId = domainObject.AppUserId,
                Arm = domainObject.Arm,
                BodyFatPercentage = domainObject.BodyFatPercentage,
                Chest = domainObject.Chest,
                Height = domainObject.Height,
                Hip = domainObject.Height,
                Id = domainObject.Id,
                LoggedAt = domainObject.LoggedAt,
                UnitType = domainObject.UnitType == null 
                    ? null 
                    : MapperContext.UnitTypeMapper.MapDomainToDAL(domainObject.UnitType),
                UnitTypeId = domainObject.UnitTypeId,
                Waist = domainObject.Waist
            };

        public Domain.BodyMeasurement MapDALToDomain(BodyMeasurement dalObject)
        {
            return new Domain.BodyMeasurement()
            {
                AppUserId = dalObject.AppUserId,
                Arm = dalObject.Arm,
                BodyFatPercentage = dalObject.BodyFatPercentage,
                Chest = dalObject.Chest,
                Height = dalObject.Height,
                Hip = dalObject.Height,
                Id = dalObject.Id,
                UnitTypeId = dalObject.UnitTypeId,
                Waist = dalObject.Waist
            };
        }
    }
}