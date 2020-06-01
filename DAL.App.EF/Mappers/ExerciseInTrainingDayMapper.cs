using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class ExerciseInTrainingDayMapper : EFBaseMapper,
        IDALMapper<ExerciseInTrainingDay, DTO.ExerciseInTrainingDay>
    {
        public ExerciseInTrainingDayMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.ExerciseInTrainingDay MapDomainToDAL(ExerciseInTrainingDay domainObject)
        {
            return new DTO.ExerciseInTrainingDay
            {
                Id = domainObject.Id,
                TrainingDayId = domainObject.TrainingDayId,
                ExerciseTypeId = domainObject.ExerciseTypeId,
                ExerciseType = domainObject.ExerciseType == null
                    ? null
                    : DALMapperContext.ExerciseTypeMapper.MapDomainToDAL(domainObject.ExerciseType),
                ExerciseId = domainObject.ExerciseId,
                Exercise = domainObject.Exercise == null
                    ? null
                    : DALMapperContext.ExerciseMapper.MapDomainToDAL(domainObject.Exercise),
                ExerciseSets = domainObject.ExerciseSets?.Select(DALMapperContext.ExerciseSetMapper.MapDomainToDAL)
            };
        }

        public ExerciseInTrainingDay MapDALToDomain(DTO.ExerciseInTrainingDay dalObject)
        {
            return new ExerciseInTrainingDay
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                ExerciseTypeId = dalObject.ExerciseTypeId,
                TrainingDayId = dalObject.TrainingDayId,
                ExerciseSets = dalObject
                    .ExerciseSets?
                    .Select(DALMapperContext.ExerciseSetMapper.MapDALToDomain)
                    .ToList()
            };
        }
    }
}