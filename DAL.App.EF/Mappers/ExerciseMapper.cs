using System;
using System.Linq;
using System.Threading;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;
using Domain.App.Enums;

namespace DAL.App.EF.Mappers
{
    public class ExerciseMapper : EFBaseMapper, IDALMapper<Domain.App.Exercise, Exercise>
    {
        public ExerciseMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public Exercise MapDomainToDAL(Domain.App.Exercise domainObject) =>
            new Exercise()
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

        public Domain.App.Exercise MapDALToDomain(Exercise dalObject) =>
            new Domain.App.Exercise()
            {
                Id = dalObject.Id,
                NameET = dalObject.Name,
                NameENG = dalObject.Name,
                DescriptionET = dalObject.Description,
                DescriptionENG = dalObject.Description,
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
        private string ConvertNameToCurrentLanguage(Domain.App.Exercise domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.NameET;
            }
            return domainEntity.NameENG;
        }
        
        private string ConvertDescriptionToCurrentLanguage(Domain.App.Exercise domainEntity)
        {
            if (GetCurrentCulture() == Culture.Estonian)
            {
                return domainEntity.DescriptionET;
            }
            return domainEntity.DescriptionENG;
        }
    }
}