using Domain;

namespace Contracts.BLL.App.Services
{
    public interface IBaseRoutineGenerator
    {
        WorkoutRoutine GenerateNewRoutine();
    }
}