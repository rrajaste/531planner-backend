using System.Linq;
using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class TrainingDayMapper : IBaseDALMapper<Domain.TrainingDay, TrainingDay>
    {
        public TrainingDay MapDomainToDAL(Domain.TrainingDay domainObject) =>
            new TrainingDay()
            {
                Id = domainObject.Id,
                Date = domainObject.Date,
                ExerciseSets = domainObject.ExerciseSets?.Select(ExerciseSetMapper.MapDomainToDAL),
                TrainingWeek = TrainingWeekMapper.MapDomainToDAL(domainObject.TrainingWeek),
                TrainingWeekId = domainObject.TrainingWeekId,
                TrainingDayType = TrainingDayTypeMapper.MapDomainToDAL(domainObject.TrainingDayType),
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