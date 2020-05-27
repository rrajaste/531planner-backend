using BLL.App.DTO;

namespace Contracts.BLL.App.RoutineGenerators
{
    public interface IFiveThreeOneRoutineGenerator : IBaseRoutineGenerator
    {
        TrainingCycle GenerateNewTrainingCycle(WorkoutRoutine parentRoutine);
    }
}