using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class TrainingDayTypeMapper : EFBaseMapper, IDALMapper<Domain.App.TrainingDayType, TrainingDayType>
    {
        public TrainingDayTypeMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public TrainingDayType MapDomainToDAL(Domain.App.TrainingDayType domainObject) =>
            new TrainingDayType()
            {
                Id = domainObject.Id,
                Name = ConvertNameToCurrentLanguage(domainObject),
                Description = ConvertDescriptionToCurrentLanguage(domainObject)
            };

        public Domain.App.TrainingDayType MapDALToDomain(TrainingDayType dalObject) =>
            new Domain.App.TrainingDayType()
            {
                Id = dalObject.Id,
                Name_eng = dalObject.Name,
                Name_et = dalObject.Name,
                Description_eng = dalObject.Description,
                Description_et = dalObject.Description
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
        private string ConvertNameToCurrentLanguage(Domain.App.TrainingDayType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.Name_et;
            }
            return domainEntity.Name_eng;
        }
        
        private string ConvertDescriptionToCurrentLanguage(Domain.App.TrainingDayType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.Description_et;
            }
            return domainEntity.Description_eng;
        }
    }
}
