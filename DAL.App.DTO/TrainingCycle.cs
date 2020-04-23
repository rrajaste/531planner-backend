using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class TrainingCycle : TrainingCycle<Guid>, IDALBaseDTO
    {
    }

    public class TrainingCycle<TKey> : IDALBaseDTO<TKey> 
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