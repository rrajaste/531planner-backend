using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using Domain.App;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class SetTypeMapper : IDALMapper<SetType, DTO.SetType>
    {
        private readonly IAppDALMapperContext _context;

        public SetTypeMapper(IAppDALMapperContext context)
        {
            _context = context;
        }

        public DTO.SetType MapDomainToDAL(SetType domainObject)
        {
            return new DTO.SetType
            {
                Id = domainObject.Id,
                Name = ConvertNameToCurrentLanguage(domainObject),
                Description = ConvertDescriptionToCurrentLanguage(domainObject),
                TypeCode = domainObject.TypeCode
            };
        }

        public SetType MapDALToDomain(DTO.SetType dalObject)
        {
            return new SetType
            {
                Id = dalObject.Id,
                Name_eng = dalObject.Name,
                Name_et = dalObject.Name,
                Description_eng = dalObject.Description,
                Description_et = dalObject.Description,
                TypeCode = dalObject.TypeCode
            };
        }

        private string GetCurrentCulture()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == Culture.Estonian)
                return Culture.Estonian;
            return Culture.English;
        }

        private string ConvertNameToCurrentLanguage(SetType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.Name_et;
            return domainEntity.Name_eng;
        }

        private string ConvertDescriptionToCurrentLanguage(SetType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.Description_et;
            return domainEntity.Description_eng;
        }
    }
}