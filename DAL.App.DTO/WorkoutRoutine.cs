using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class WorkoutRoutine : WorkoutRoutine<Guid>, IDALBaseDTO
    {
    }

    public class WorkoutRoutine<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsBaseRoutine { get; set; } = default!;
        public TKey RoutineTypeId { get; set; } = default!;
        public TKey AppUserId { get; set; } = default!;
        public RoutineType? RoutineType { get; set; }
        public ICollection<PersonalRecord>? PersonalRecord { get; set; }
        public IEnumerable<TrainingCycle>? TrainingCycles { get; set; }
    }
}