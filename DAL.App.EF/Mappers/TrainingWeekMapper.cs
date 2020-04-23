using System.Linq;
using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class TrainingWeekMapper : IBaseDALMapper<Domain.TrainingWeek, TrainingWeek>
    {
        public TrainingWeek MapDomainToDAL(Domain.TrainingWeek domainObject) =>
            new TrainingWeek()
            {
                Id = domainObject.Id,
                WeekNumber = domainObject.WeekNumber,
                StartingDate = domainObject.StartingDate,
                EndingDate = domainObject.EndingDate,
                IsDeload = domainObject.IsDeload,
                TrainingCycle = TrainingCycleMapper.MapDomainToDAL(domainObject.TrainingCycle),
                TrainingCycleId = domainObject.TrainingCycleId,
                TrainingDays = domainObject.TrainingDays?.Select(TrainingDayMapper.MapDomainToDAL),
            };

        public Domain.TrainingWeek MapDALToDomain(TrainingWeek dalObject) =>
            new Domain.TrainingWeek()
            {
                Id = dalObject.Id,
                WeekNumber = dalObject.WeekNumber,
                StartingDate = dalObject.StartingDate,
                EndingDate = dalObject.EndingDate,
                IsDeload = dalObject.IsDeload,
                TrainingCycleId = dalObject.TrainingCycleId,
            };
    }
}