using System.Linq;
using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WorkoutRoutineMapper : IBaseDALMapper<Domain.WorkoutRoutine, WorkoutRoutine>
    {
        public WorkoutRoutine MapDomainToDAL(Domain.WorkoutRoutine domainObject) =>
            new WorkoutRoutine()
            {
                Id = domainObject.Id,
                AppUserId = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                IsBaseRoutine = domainObject.IsBaseRoutine,
                RoutineType = RoutineTypeMapper.MapDomainToDAL(domainObject.RoutineType),
                RoutineTypeId = domainObject.RoutineTypeId,
                TrainingCycles = domainObject.TrainingCycles?.Select(TrainingCycleMapper.MapDomainToDAL)
            };

        public Domain.WorkoutRoutine MapDALToDomain(WorkoutRoutine dalObject) =>
            new Domain.WorkoutRoutine()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                IsBaseRoutine = dalObject.IsBaseRoutine,
                RoutineTypeId = dalObject.RoutineTypeId,
            };
    }
}