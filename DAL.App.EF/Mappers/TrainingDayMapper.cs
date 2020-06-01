using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class TrainingDayMapper : EFBaseMapper, IDALMapper<TrainingDay, DTO.TrainingDay>
    {
        public TrainingDayMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.TrainingDay MapDomainToDAL(TrainingDay domainObject)
        {
            return new DTO.TrainingDay
            {
                Id = domainObject.Id,
                Date = domainObject.Date,
                ExercisesInTrainingDay = domainObject.ExercisesInTrainingDay?
                    .Select(DALMapperContext.ExerciseInTrainingDayMapper.MapDomainToDAL),
                TrainingWeekId = domainObject.TrainingWeekId,
                TrainingDayType = domainObject.TrainingDayType == null
                    ? null
                    : DALMapperContext.TrainingDayTypeMapper.MapDomainToDAL(domainObject.TrainingDayType),
                TrainingDayTypeId = domainObject.TrainingDayTypeId
            };
        }

        public TrainingDay MapDALToDomain(DTO.TrainingDay dalObject)
        {
            return new TrainingDay
            {
                Id = dalObject.Id,
                Date = dalObject.Date,
                TrainingWeekId = dalObject.TrainingWeekId,
                TrainingDayTypeId = dalObject.TrainingDayTypeId,
                ExercisesInTrainingDay = dalObject
                    .ExercisesInTrainingDay?
                    .Select(DALMapperContext.ExerciseInTrainingDayMapper.MapDALToDomain)
                    .ToList()
            };
        }
    }
}