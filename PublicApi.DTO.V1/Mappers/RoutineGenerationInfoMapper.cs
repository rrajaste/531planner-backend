using BLL.App.DTO;

namespace PublicApi.DTO.V1.Mappers
{
    public class RoutineGenerationInfoMapper
    {
        public static NewFiveThreeOneRoutineInfo MapPublicDTOToBLLEntity(RoutineGenerationInfo dto, BLL.App.DTO.WorkoutRoutine baseRoutine)
        {
            return new NewFiveThreeOneRoutineInfo()
            {
                BaseRoutine = baseRoutine,
                StartingDate = dto.StartingDate,
                CycleInfo = new NewFiveThreeOneCycleInfo()
                {
                    AddDeloadWeek = dto.AddDeloadWeek,
                    BenchPressMax = dto.BenchPressMax,
                    DeadliftMax = dto.DeadliftMax,
                    OverHeadPressMax = dto.OverHeadPressMax,
                    SquatMax = dto.SquatMax,
                    UnitTypeId = dto.UnitTypeId
                },
            };
        }
    }
}