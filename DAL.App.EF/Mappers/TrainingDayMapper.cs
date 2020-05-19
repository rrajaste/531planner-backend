using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class TrainingDayMapper : EFBaseMapper, IDALMapper<Domain.App.TrainingDay, TrainingDay>
    {
        public TrainingDayMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public TrainingDay MapDomainToDAL(Domain.App.TrainingDay domainObject) =>
            new TrainingDay()
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

        public Domain.App.TrainingDay MapDALToDomain(TrainingDay dalObject) =>
            new Domain.App.TrainingDay()
            {
                Id = dalObject.Id,
                Date = dalObject.Date,
                TrainingWeekId = dalObject.TrainingWeekId,
                TrainingDayTypeId = dalObject.TrainingDayTypeId
            };
    }
}