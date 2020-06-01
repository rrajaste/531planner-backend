using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class SetTypeMapper : IDALMapper<Domain.App.SetType, SetType>
    {
        private readonly IAppDALMapperContext _context;
        public SetTypeMapper(IAppDALMapperContext context)
        {
            _context = context;
        }
        
        public SetType MapDomainToDAL(Domain.App.SetType domainObject) =>
            new SetType()
            {
                Id = domainObject.Id,
                Name = ConvertNameToCurrentLanguage(domainObject),
                Description = ConvertDescriptionToCurrentLanguage(domainObject),
                TypeCode = domainObject.TypeCode
            };

        public Domain.App.SetType MapDALToDomain(SetType dalObject) =>
            new Domain.App.SetType()
            {
                Id = dalObject.Id,
                Name_eng = dalObject.Name,
                Name_et = dalObject.Name,
                Description_eng = dalObject.Description,
                Description_et = dalObject.Description,
                TypeCode = dalObject.TypeCode
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
        private string ConvertNameToCurrentLanguage(Domain.App.SetType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.Name_et;
            }
            return domainEntity.Name_eng;
        }
        
        private string ConvertDescriptionToCurrentLanguage(Domain.App.SetType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.Description_et;
            }
            return domainEntity.Description_eng;
        }
    }
}