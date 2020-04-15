using App.DTO;
using Domain;

namespace Contracts.BLL.App
{
    public interface IBaseRoutineGenerator
    {
        WorkoutRoutine GenerateNewRoutine();
    }
}