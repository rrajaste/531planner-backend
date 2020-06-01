using System.Linq;
using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class RoutineTypeMapper : EFBaseMapper, IDALMapper<RoutineType, DTO.RoutineType>
    {
        public RoutineTypeMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.RoutineType MapDomainToDAL(RoutineType domainObject)
        {
            return new DTO.RoutineType
            {
                Id = domainObject.Id,
                Name = ConvertNameToCurrentLanguage(domainObject),
                Description = ConvertDescriptionToCurrentLanguage(domainObject),
                ParentTypeId = domainObject.ParentTypeId,
                SubTypes = domainObject.SubTypes?.Select(MapDomainToDAL)
            };
        }

        public RoutineType MapDALToDomain(DTO.RoutineType dalObject)
        {
            return new RoutineType
            {
                Id = dalObject.Id,
                Name_eng = dalObject.Name,
                Name_et = dalObject.Name,
                Description_eng = dalObject.Description,
                Description_et = dalObject.Description,
                ParentTypeId = dalObject.ParentTypeId
            };
        }

        private string GetCurrentCulture()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == Culture.Estonian)
                return Culture.Estonian;
            return Culture.English;
        }

        private string ConvertNameToCurrentLanguage(RoutineType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.Name_et;
            return domainEntity.Name_eng;
        }

        private string ConvertDescriptionToCurrentLanguage(RoutineType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.Description_et;
            return domainEntity.Description_eng;
        }
    }
}