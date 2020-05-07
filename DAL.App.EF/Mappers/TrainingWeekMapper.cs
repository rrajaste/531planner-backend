using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class TrainingWeekMapper : EFBaseMapper, IDALMapper<Domain.App.TrainingWeek, TrainingWeek>
    {
        public TrainingWeekMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public TrainingWeek MapDomainToDAL(Domain.App.TrainingWeek domainObject) =>
            new TrainingWeek()
            {
                Id = domainObject.Id,
                WeekNumber = domainObject.WeekNumber,
                StartingDate = domainObject.StartingDate,
                EndingDate = domainObject.EndingDate,
                IsDeload = domainObject.IsDeload,
                TrainingCycle = domainObject.TrainingCycle == null ? 
                    null 
                    : DALMapperContext.TrainingCycleMapper.MapDomainToDAL(domainObject.TrainingCycle),
                TrainingCycleId = domainObject.TrainingCycleId,
                TrainingDays = domainObject.TrainingDays?.Select(DALMapperContext.TrainingDayMapper.MapDomainToDAL),
            };

        public Domain.App.TrainingWeek MapDALToDomain(TrainingWeek dalObject) =>
            new Domain.App.TrainingWeek()
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