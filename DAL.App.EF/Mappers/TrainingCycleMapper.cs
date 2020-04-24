using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class TrainingCycleMapper : EFBaseMapper, IDALMapper<Domain.TrainingCycle, TrainingCycle>
    {
        public TrainingCycleMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public TrainingCycle MapDomainToDAL(Domain.TrainingCycle domainObject) =>
            new TrainingCycle()
            {
                Id = domainObject.Id,
                CycleNumber = domainObject.CycleNumber,
                StartingDate = domainObject.StartingDate,
                EndingDate = domainObject.EndingDate,
                TrainingWeeks = domainObject.TrainingWeeks?.Select(MapperContext.TrainingWeekMapper.MapDomainToDAL),
                WorkoutRoutine = MapperContext.WorkoutRoutineMapper.MapDomainToDAL(domainObject.WorkoutRoutine),
                WorkoutRoutineId = domainObject.WorkoutRoutineId
            };

        public Domain.TrainingCycle MapDALToDomain(TrainingCycle dalObject) =>
            new Domain.TrainingCycle()
            {
                Id = dalObject.Id,
                CycleNumber = dalObject.CycleNumber,
                StartingDate = dalObject.StartingDate,
                EndingDate = dalObject.EndingDate,
                WorkoutRoutineId = dalObject.WorkoutRoutineId
            };
    }
}