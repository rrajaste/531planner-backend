using System;
using Domain;

namespace Contracts.App.DTO
{
    public interface IBaseRoutineDTO
    {
        WorkoutRoutine BaseRoutine { get; set; }
        string? RoutineName { get; set; }
        string? RoutineDescription { get; set; }
        DateTime RoutineStartingDate { get; set; }
    }
}