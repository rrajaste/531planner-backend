using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class TrainingDayMapper : EFBaseMapper, IDALMapper<Domain.TrainingDay, TrainingDay>
    {
        public TrainingDayMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public TrainingDay MapDomainToDAL(Domain.TrainingDay domainObject) =>
            new TrainingDay()
            {
                Id = domainObject.Id,
                Date = domainObject.Date,
                ExerciseSets = domainObject.ExerciseSets?.Select(DALMapperContext.ExerciseSetMapper.MapDomainToDAL),
                TrainingWeek = domainObject.TrainingWeek == null 
                    ? null 
                    : DALMapperContext.TrainingWeekMapper.MapDomainToDAL(domainObject.TrainingWeek),
                TrainingWeekId = domainObject.TrainingWeekId,
                TrainingDayType = domainObject.TrainingDayType == null 
                    ? null 
                    : DALMapperContext.TrainingDayTypeMapper.MapDomainToDAL(domainObject.TrainingDayType),
                TrainingDayTypeId = domainObject.TrainingDayTypeId
            };

        public Domain.TrainingDay MapDALToDomain(TrainingDay dalObject) =>
            new Domain.TrainingDay()
            {
                Id = dalObject.Id,
                Date = dalObject.Date,
                TrainingWeekId = dalObject.TrainingWeekId,
                TrainingDayTypeId = dalObject.TrainingDayTypeId
            };
    }
}