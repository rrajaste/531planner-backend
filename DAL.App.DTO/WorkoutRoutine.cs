using System;
using System.Collections.Generic;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class WorkoutRoutine : WorkoutRoutine<Guid>, IDALBaseDTO
    {
    }

    public class WorkoutRoutine<TKey> : IDALBaseDTO<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsBaseRoutine { get; set; } = default!;
        public TKey RoutineTypeId { get; set; } = default!;
        public TKey AppUserId { get; set; }
        public AppUser<TKey>? AppUser { get; set; }
        public RoutineType? RoutineType { get; set; }
        public ICollection<PersonalRecord>? PersonalRecord { get; set; }
        public ICollection<TrainingCycle>? TrainingCycles { get; set; }
    }
}