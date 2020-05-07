using Domain;
using Domain.App;

namespace Contracts.BLL.App.Services
{
    public interface IBaseRoutineGenerator
    {
        WorkoutRoutine GenerateNewRoutine();
    }
}