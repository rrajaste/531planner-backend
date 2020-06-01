using System.Linq;
using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class WorkoutRoutineMapper : BLLBaseMapper, IBLLMapper<WorkoutRoutine, App.DTO.WorkoutRoutine>
    {
        public WorkoutRoutineMapper(IAppBLLMapperContext bllMapperContext) : base(bllMapperContext)
        {
        }

        public App.DTO.WorkoutRoutine MapDALToBLL(WorkoutRoutine dalObject)
        {
            return new App.DTO.WorkoutRoutine
            {
                Id = dalObject.Id,
                AppUserId = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                IsPublished = dalObject.IsPublished,
                IsBaseRoutine = dalObject.IsBaseRoutine,
                RoutineType = dalObject.RoutineType == null
                    ? null
                    : BLLMapperContext.RoutineTypeMapper.MapDALToBLL(dalObject.RoutineType),
                RoutineTypeId = dalObject.RoutineTypeId,
                TrainingCycles = dalObject.TrainingCycles?.Select(BLLMapperContext.TrainingCycleMapper.MapDALToBLL)
            };
        }

        public WorkoutRoutine MapBLLToDAL(App.DTO.WorkoutRoutine bllObject)
        {
            return new WorkoutRoutine
            {
                Id = bllObject.Id,
                AppUserId = bllObject.AppUserId,
                Name = bllObject.Name,
                Description = bllObject.Description,
                IsBaseRoutine = bllObject.IsBaseRoutine,
                IsPublished = bllObject.IsPublished,
                RoutineTypeId = bllObject.RoutineTypeId,
                TrainingCycles = bllObject.TrainingCycles?.Select(BLLMapperContext.TrainingCycleMapper.MapBLLToDAL)
            };
        }
    }
}