using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class TrainingWeekMapper : EFBaseMapper, IDALMapper<TrainingWeek, DTO.TrainingWeek>
    {
        public TrainingWeekMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.TrainingWeek MapDomainToDAL(TrainingWeek domainObject)
        {
            return new DTO.TrainingWeek
            {
                Id = domainObject.Id,
                WeekNumber = domainObject.WeekNumber,
                StartingDate = domainObject.StartingDate,
                EndingDate = domainObject.EndingDate,
                IsDeload = domainObject.IsDeload,
                TrainingCycle = domainObject.TrainingCycle == null
                    ? null
                    : DALMapperContext.TrainingCycleMapper.MapDomainToDAL(domainObject.TrainingCycle),
                TrainingCycleId = domainObject.TrainingCycleId,
                TrainingDays = domainObject.TrainingDays?.Select(DALMapperContext.TrainingDayMapper.MapDomainToDAL)
            };
        }

        public TrainingWeek MapDALToDomain(DTO.TrainingWeek dalObject)
        {
            return new TrainingWeek
            {
                Id = dalObject.Id,
                WeekNumber = dalObject.WeekNumber,
                StartingDate = dalObject.StartingDate,
                EndingDate = dalObject.EndingDate,
                IsDeload = dalObject.IsDeload,
                TrainingCycleId = dalObject.TrainingCycleId,
                TrainingDays = dalObject
                    .TrainingDays?
                    .Select(DALMapperContext.TrainingDayMapper.MapDALToDomain)
                    .ToList()
            };
        }
    }
}