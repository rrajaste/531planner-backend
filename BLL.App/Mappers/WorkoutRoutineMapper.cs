using System.Linq;
using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using BLL.App.DTO;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.Base.EF;

namespace BLL.Mappers
{
    public class WorkoutRoutineMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.WorkoutRoutine, WorkoutRoutine>
    {
        public WorkoutRoutineMapper(IAppBLLMapperContext BLLMapperContext) : base(BLLMapperContext)
        {
        }

        public WorkoutRoutine MapDALToBLL(DAL.App.DTO.WorkoutRoutine dalObject) =>
            new WorkoutRoutine()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.Id,
                Name = dalObject.Name,
                Description = dalObject.Description,
                IsBaseRoutine = dalObject.AppUserId == null,
                RoutineType = dalObject.RoutineType == null 
                    ? null 
                    : BLLMapperContext.RoutineTypeMapper.MapDALToBLL(dalObject.RoutineType),
                RoutineTypeId = dalObject.RoutineTypeId,
                TrainingCycles = dalObject.TrainingCycles?.Select(BLLMapperContext.TrainingCycleMapper.MapDALToBLL)
            };

        public DAL.App.DTO.WorkoutRoutine MapBLLToDAL(WorkoutRoutine bllObject) =>
            new DAL.App.DTO.WorkoutRoutine()
            {
                Id = bllObject.Id,
                AppUserId = bllObject.AppUserId,
                Name = bllObject.Name,
                Description = bllObject.Description,
                IsBaseRoutine = bllObject.IsBaseRoutine,
                RoutineTypeId = bllObject.RoutineTypeId,
            };
    }
}
