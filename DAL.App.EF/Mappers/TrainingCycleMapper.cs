using System.Linq;
using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class TrainingCycleMapper : IBaseDALMapper<Domain.TrainingCycle, TrainingCycle>
    {
        public TrainingCycle MapDomainToDAL(Domain.TrainingCycle domainObject) =>
            new TrainingCycle()
            {
                Id = domainObject.Id,
                CycleNumber = domainObject.CycleNumber,
                StartingDate = domainObject.StartingDate,
                EndingDate = domainObject.EndingDate,
                TrainingWeeks = domainObject.TrainingWeeks?.Select(TrainingWeeksMapper.MapDomainToDAL),
                WorkoutRoutine = WorkoutRoutineMapper.MapDomainToDAL(domainObject.WorkoutRoutine),
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