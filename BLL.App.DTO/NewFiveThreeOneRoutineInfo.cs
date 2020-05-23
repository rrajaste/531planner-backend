using System;

namespace BLL.App.DTO
{
    public class NewFiveThreeOneRoutineInfo : BaseNewRoutineInfo
    {
        public NewFiveThreeOneCycleInfo CycleInfo { get; set; }
        public Guid SquatExerciseId { get; set; }
        public Guid DeadliftExerciseId { get; set; }
        public Guid BenchPressExerciseId { get; set; }
        public Guid OverheadPressExerciseId { get; set; }
    }
}