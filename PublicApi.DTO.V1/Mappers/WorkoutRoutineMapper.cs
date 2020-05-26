using System;
using System.Linq;
using Extensions;

namespace PublicApi.DTO.V1.Mappers
{
    public class WorkoutRoutineMapper
    {
        public static FullWorkoutRoutine MapBLLEntityToFullWorkoutRoutine(BLL.App.DTO.WorkoutRoutine bllEntity)
        {
            if (bllEntity.TrainingCycles.IsEmptyOrNull())
            {
                throw new Exception("Workout routine mapping failed: training cycles in bll entity were null or empty");
            }
            return new FullWorkoutRoutine()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                Description = bllEntity.Description,
                TrainingCycles = bllEntity.TrainingCycles
                    .OrderBy(cycle => cycle.CycleNumber)
                    .Select(TrainingCycleMapper.MapBLLEntityToPublicDTO)
            };
        }
        
        public static BaseWorkoutRoutine MapBLLEntityToBaseWorkoutRoutine(BLL.App.DTO.WorkoutRoutine bllEntity)
        {
            return new BaseWorkoutRoutine()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                Description = bllEntity.Description,
            };
        }
    }
}