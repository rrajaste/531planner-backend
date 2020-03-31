using System;
using Domain;

namespace App.DTO
{
    public class NewRoutineDTO
    {
        public WorkoutRoutine BaseRoutine { get; set; }
        public string? RoutineName { get; set; }
        public DateTime StartingDate { get; set; }
        public string? RoutineDescription { get; set; }
    }
}