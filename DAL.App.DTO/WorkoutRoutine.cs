using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class WorkoutRoutine : WorkoutRoutine<Guid>, IDALBaseDTO
    {
    }

    public class WorkoutRoutine<TKey> : IDALBaseDTO<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsBaseRoutine { get; set; }
        public bool IsPublished { get; set; }
        public TKey RoutineTypeId { get; set; }
        public TKey? AppUserId { get; set; }
        public RoutineType? RoutineType { get; set; }
        public IEnumerable<TrainingCycle>? TrainingCycles { get; set; }
        public TKey Id { get; set; }
    }
}