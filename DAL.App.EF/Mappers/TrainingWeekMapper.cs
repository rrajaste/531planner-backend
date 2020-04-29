using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class TrainingWeekMapper : EFBaseMapper, IDALMapper<Domain.TrainingWeek, TrainingWeek>
    {
        public TrainingWeekMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public TrainingWeek MapDomainToDAL(Domain.TrainingWeek domainObject) =>
            new TrainingWeek()
            {
                Id = domainObject.Id,
                WeekNumber = domainObject.WeekNumber,
                StartingDate = domainObject.StartingDate,
                EndingDate = domainObject.EndingDate,
                IsDeload = domainObject.IsDeload,
                TrainingCycle = domainObject.TrainingCycle == null ? 
                    null 
                    : MapperContext.TrainingCycleMapper.MapDomainToDAL(domainObject.TrainingCycle),
                TrainingCycleId = domainObject.TrainingCycleId,
                TrainingDays = domainObject.TrainingDays?.Select(MapperContext.TrainingDayMapper.MapDomainToDAL),
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