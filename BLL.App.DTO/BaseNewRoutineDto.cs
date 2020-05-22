using System;
using BLL.App.DTO;

namespace App.DTO
{
    public class BaseNewRoutineDto
    {
        public WorkoutRoutine BaseRoutine { get; set; } = default!;
        public string? RoutineName { get; set; }
        public DateTime StartingDate { get; set; }
        public string? RoutineDescription { get; set; }
    }
}