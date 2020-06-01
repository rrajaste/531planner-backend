using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class ExerciseTypeMapper : EFBaseMapper, IDALMapper<Domain.App.ExerciseType, ExerciseType>
    {
        public ExerciseTypeMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public ExerciseType MapDomainToDAL(Domain.App.ExerciseType domainObject) =>
            new ExerciseType()
            {
                Id = domainObject.Id,
                Name = ConvertNameToCurrentLanguage(domainObject),
                Description = ConvertDescriptionToCurrentLanguage(domainObject),
                TypeCode = domainObject.TypeCode
            };


        public Domain.App.ExerciseType MapDALToDomain(ExerciseType dalObject) =>
            new Domain.App.ExerciseType()
            {
                // TODO: Not mapped correctly
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

        private string ConvertNameToCurrentLanguage(Domain.App.ExerciseType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.Name_et;
            }
            return domainEntity.Name_eng;
        }
        
        private string ConvertDescriptionToCurrentLanguage(Domain.App.ExerciseType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.Description_et;
            }
            return domainEntity.Description_eng;
        }
    }
}