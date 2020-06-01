using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class WorkoutRoutine : WorkoutRoutine<Guid>, IBLLBaseDTO
    {
    }

    public class WorkoutRoutine<TKey> : IBLLBaseDTO<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.BLL.WorkoutRoutine))]
        public string Name { get; set; } = default!;

        [Display(Name = nameof(Description), ResourceType = typeof(Resources.BLL.WorkoutRoutine))]
        public string Description { get; set; } = default!;

        public bool IsBaseRoutine { get; set; }
        public bool IsPublished { get; set; }
        public TKey RoutineTypeId { get; set; } = default!;
        public TKey? AppUserId { get; set; } = default!;

        [Display(Name = nameof(RoutineType), ResourceType = typeof(Resources.BLL.WorkoutRoutine))]
        public RoutineType? RoutineType { get; set; }

        public IEnumerable<TrainingCycle>? TrainingCycles { get; set; }
        public TKey Id { get; set; } = default!;
    }
}