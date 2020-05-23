using System;

namespace BLL.App.DTO
{
    public class BaseNewRoutineInfo
    {
        public WorkoutRoutine BaseRoutine { get; set; } = default!;
        public DateTime StartingDate { get; set; }
        public Guid UnitTypeId { get; set; }
    }
}