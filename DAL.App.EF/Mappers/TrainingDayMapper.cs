using System.Linq;
using Contracts.DAL.App;
using DAL.App.DTO;
using DAL.Base.EF;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class TrainingDayMapper : EFBaseMapper, IDALMapper<Domain.TrainingDay, TrainingDay>
    {
        public TrainingDayMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public TrainingDay MapDomainToDAL(Domain.TrainingDay domainObject) =>
            new TrainingDay()
            {
                Id = domainObject.Id,
                Date = domainObject.Date,
                ExerciseSets = domainObject.ExerciseSets?.Select(MapperContext.ExerciseSetMapper.MapDomainToDAL),
                TrainingWeek = MapperContext.TrainingWeekMapper.MapDomainToDAL(domainObject.TrainingWeek),
                TrainingWeekId = domainObject.TrainingWeekId,
                TrainingDayType = MapperContext.TrainingDayTypeMapper.MapDomainToDAL(domainObject.TrainingDayType),
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