using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class UnitTypeMapper : IBaseDALMapper<Domain.UnitType, UnitType>
    {
        public UnitType MapDomainToDAL(Domain.UnitType domainObject) =>
            new UnitType()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description
            };

        public Domain.UnitType MapDALToDomain(UnitType dalObject) =>
            new Domain.UnitType()
            {
                Id = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description
            };
    }
}