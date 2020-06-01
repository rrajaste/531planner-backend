using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class TrainingDayTypeMapper : EFBaseMapper, IDALMapper<TrainingDayType, DTO.TrainingDayType>
    {
        public TrainingDayTypeMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.TrainingDayType MapDomainToDAL(TrainingDayType domainObject)
        {
            return new DTO.TrainingDayType
            {
                Id = domainObject.Id,
                Name = ConvertNameToCurrentLanguage(domainObject),
                Description = ConvertDescriptionToCurrentLanguage(domainObject)
            };
        }

        public TrainingDayType MapDALToDomain(DTO.TrainingDayType dalObject)
        {
            return new TrainingDayType
            {
                Id = dalObject.Id,
                Name_eng = dalObject.Name,
                Name_et = dalObject.Name,
                Description_eng = dalObject.Description,
                Description_et = dalObject.Description
            };
        }

        private string GetCurrentCulture()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == Culture.Estonian)
                return Culture.Estonian;
            return Culture.English;
        }

        private string ConvertNameToCurrentLanguage(TrainingDayType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.Name_et;
            return domainEntity.Name_eng;
        }

        private string ConvertDescriptionToCurrentLanguage(TrainingDayType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.Description_et;
            return domainEntity.Description_eng;
        }
    }
}