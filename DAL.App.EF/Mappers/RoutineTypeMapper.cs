using System.Linq;
using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class RoutineTypeMapper : EFBaseMapper, IDALMapper<Domain.App.RoutineType, RoutineType>
    {
        public RoutineTypeMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public RoutineType MapDomainToDAL(Domain.App.RoutineType domainObject)
        {
            return new RoutineType()
            {
                Id = domainObject.Id,
                Name = ConvertNameToCurrentLanguage(domainObject),
                Description = ConvertDescriptionToCurrentLanguage(domainObject),
                ParentTypeId = domainObject.ParentTypeId,
                SubTypes = domainObject.SubTypes?.Select(MapDomainToDAL)
            };
        }

        public Domain.App.RoutineType MapDALToDomain(RoutineType dalObject) =>
            new Domain.App.RoutineType()
            {
                Id = dalObject.Id,
                Name_eng = dalObject.Name,
                Name_et = dalObject.Name,
                Description_eng = dalObject.Description,
                Description_et = dalObject.Description,
                ParentTypeId = dalObject.ParentTypeId
            };
        
        private string GetCurrentCulture()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == Culture.Estonian)
            {
                return Culture.Estonian;
            }
            else
            {
                return Culture.English;
            }
        }

        private string ConvertNameToCurrentLanguage(Domain.App.RoutineType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.Name_et;
            }
            return domainEntity.Name_eng;
        }
        
        private string ConvertDescriptionToCurrentLanguage(Domain.App.RoutineType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.Description_et;
            }
            return domainEntity.Description_eng;
        }
    }
}