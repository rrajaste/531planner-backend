using BLL.App.DTO;

namespace Contracts.BLL.App.RoutineGenerators
{
    public interface IBaseRoutineGenerator
    {
        WorkoutRoutine GenerateNewRoutine();
    }
}