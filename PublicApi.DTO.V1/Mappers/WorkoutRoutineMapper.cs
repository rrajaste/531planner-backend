using System.Linq;

namespace PublicApi.DTO.V1.Mappers
{
    public class WorkoutRoutineMapper
    {
        public static WorkoutRoutine MapBLLEntityToPublicDTO(BLL.App.DTO.WorkoutRoutine bllEntity)
        {
            return new WorkoutRoutine()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                Description = bllEntity.Description,
                TrainingCycles = bllEntity.TrainingCycles?.Select(TrainingCycleMapper.MapBLLEntityToPublicDTO)
            };
        }
    }
}