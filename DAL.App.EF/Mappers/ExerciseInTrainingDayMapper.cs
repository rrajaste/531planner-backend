using System.Linq;
using Contracts.BLL.Base.Mappers;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class ExerciseInTrainingDayMapper : EFBaseMapper, IDALMapper<Domain.App.ExerciseInTrainingDay, ExerciseInTrainingDay>
    {
        public ExerciseInTrainingDayMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public ExerciseInTrainingDay MapDomainToDAL(Domain.App.ExerciseInTrainingDay domainObject) =>
            new ExerciseInTrainingDay()
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

        public Domain.App.ExerciseInTrainingDay MapDALToDomain(ExerciseInTrainingDay dalObject) =>
            new Domain.App.ExerciseInTrainingDay()
            {
                Id = dalObject.Id,
                ExerciseId = dalObject.ExerciseId,
                ExerciseTypeId = dalObject.ExerciseTypeId,
                TrainingDayId = dalObject.TrainingDayId
            };
    }
}