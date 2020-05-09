using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class WorkoutRoutineMapper : EFBaseMapper, IDALMapper<Domain.App.WorkoutRoutine, WorkoutRoutine>
    {
        public WorkoutRoutineMapper(IAppDALMapperContext dalMapperContext) : base(dalMapperContext)
        {
        }

        public WorkoutRoutine MapDomainToDAL(Domain.App.WorkoutRoutine domainObject) =>
            new WorkoutRoutine()
            {
                Id = domainObject.Id,
                AppUserId = domainObject.Id,
                Name = domainObject.Name,
                Description = domainObject.Description,
                IsBaseRoutine = domainObject.AppUserId == null,
                RoutineType = domainObject.RoutineType == null 
                    ? null 
                    : DALMapperContext.RoutineTypeMapper.MapDomainToDAL(domainObject.RoutineType),
                RoutineTypeId = domainObject.RoutineTypeId,
                TrainingCycles = domainObject.TrainingCycles?.Select(DALMapperContext.TrainingCycleMapper.MapDomainToDAL)
            };

        public Domain.App.WorkoutRoutine MapDALToDomain(WorkoutRoutine dalObject) =>
            new Domain.App.WorkoutRoutine()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.AppUserId,
                Name = dalObject.Name,
                Description = dalObject.Description,
                RoutineTypeId = dalObject.RoutineTypeId,
            };
    }
}
