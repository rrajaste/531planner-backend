using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class ExerciseTypeMapper : EFBaseMapper, IDALMapper<ExerciseType, DTO.ExerciseType>
    {
        public ExerciseTypeMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.ExerciseType MapDomainToDAL(ExerciseType domainObject)
        {
            return new DTO.ExerciseType
            {
                Id = domainObject.Id,
                Name = ConvertNameToCurrentLanguage(domainObject),
                Description = ConvertDescriptionToCurrentLanguage(domainObject),
                TypeCode = domainObject.TypeCode
            };
        }


        public ExerciseType MapDALToDomain(DTO.ExerciseType dalObject)
        {
            return new ExerciseType
            {
                // TODO: Not mapped correctly
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

        private string ConvertNameToCurrentLanguage(ExerciseType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.Name_et;
            return domainEntity.Name_eng;
        }

        private string ConvertDescriptionToCurrentLanguage(ExerciseType domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.Description_et;
            return domainEntity.Description_eng;
        }
    }
}