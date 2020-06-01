using System;
using System.Linq;
using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;
using Domain.App.Constants;

namespace DAL.App.EF.Mappers
{
    public class ExerciseMapper : EFBaseMapper, IDALMapper<Exercise, DTO.Exercise>
    {
        public ExerciseMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.Exercise MapDomainToDAL(Exercise domainObject)
        {
            return new DTO.Exercise
            {
                Id = domainObject.Id,
                Name = ConvertNameToCurrentLanguage(domainObject),
                Description = ConvertDescriptionToCurrentLanguage(domainObject),
                TargetMuscleGroups = domainObject.TargetMuscleGroups?
                    .Select(
                        t => t.MuscleGroup != null
                            ? DALMapperContext.MuscleGroupMapper.MapDomainToDAL(t.MuscleGroup)
                            : throw new ApplicationException("Muscle group cannot be null!")
                    )
            };
        }

        public Exercise MapDALToDomain(DTO.Exercise dalObject)
        {
            return new Exercise
            {
                Id = dalObject.Id,
                NameET = dalObject.Name,
                NameENG = dalObject.Name,
                DescriptionET = dalObject.Description,
                DescriptionENG = dalObject.Description
            };
        }

        private string GetCurrentCulture()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == Culture.Estonian)
                return Culture.Estonian;
            return Culture.English;
        }

        private string ConvertNameToCurrentLanguage(Exercise domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.NameET;
            return domainEntity.NameENG;
        }

        private string ConvertDescriptionToCurrentLanguage(Exercise domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian) return domainEntity.DescriptionET;
            return domainEntity.DescriptionENG;
        }
    }
}