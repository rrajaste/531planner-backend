using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class TrainingCycleMapper : EFBaseMapper, IDALMapper<TrainingCycle, DTO.TrainingCycle>
    {
        public TrainingCycleMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public DTO.TrainingCycle MapDomainToDAL(TrainingCycle domainObject)
        {
            return new DTO.TrainingCycle
            {
                Id = domainObject.Id,
                CycleNumber = domainObject.CycleNumber,
                StartingDate = domainObject.StartingDate,
                EndingDate = domainObject.EndingDate,
                TrainingWeeks = domainObject.TrainingWeeks?.Select(DALMapperContext.TrainingWeekMapper.MapDomainToDAL),
                WorkoutRoutine = domainObject.WorkoutRoutine == null
                    ? null
                    : DALMapperContext.WorkoutRoutineMapper.MapDomainToDAL(domainObject.WorkoutRoutine),
                WorkoutRoutineId = domainObject.WorkoutRoutineId
            };
        }

        public TrainingCycle MapDALToDomain(DTO.TrainingCycle dalObject)
        {
            return new TrainingCycle
            {
                Id = dalObject.Id,
                CycleNumber = dalObject.CycleNumber,
                StartingDate = dalObject.StartingDate,
                EndingDate = dalObject.EndingDate,
                WorkoutRoutineId = dalObject.WorkoutRoutineId,
                TrainingWeeks = dalObject?
                    .TrainingWeeks?
                    .Select(DALMapperContext.TrainingWeekMapper.MapDALToDomain)
                    .ToList()
            };
        }
    }
}