using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class TrainingCycle : TrainingCycle<Guid>, IBLLBaseDTO
    {
    }

    public class TrainingCycle<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public TKey WorkoutRoutineId { get; set; } = default!;
        public int CycleNumber { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public IEnumerable<TrainingWeek>? TrainingWeeks { get; set; }
    }
}