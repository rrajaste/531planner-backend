using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class WorkoutRoutineMapper : EFBaseMapper, IDALMapper<Domain.WorkoutRoutine, WorkoutRoutine>
    {
        public WorkoutRoutineMapper(IAppMapperContext mapperContext) : base(mapperContext)
        {
        }

        public WorkoutRoutine MapDomainToDAL(Domain.WorkoutRoutine domainObject) =>
            new WorkoutRoutine()
            {
                Id = domainObject.Id,
                AppUserId = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                IsBaseRoutine = domainObject.AppUserId == null,
                RoutineType = domainObject.RoutineType == null 
                    ? null 
                    : MapperContext.RoutineTypeMapper.MapDomainToDAL(domainObject.RoutineType),
                RoutineTypeId = domainObject.RoutineTypeId,
                TrainingCycles = domainObject.TrainingCycles?.Select(MapperContext.TrainingCycleMapper.MapDomainToDAL)
            };

        public Domain.WorkoutRoutine MapDALToDomain(WorkoutRoutine dalObject) =>
            new Domain.WorkoutRoutine()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.AppUserId,
                Name = dalObject.Name,
                Description = dalObject.Description,
                IsBaseRoutine = dalObject.IsBaseRoutine,
                RoutineTypeId = dalObject.RoutineTypeId,
            };
    }
}
