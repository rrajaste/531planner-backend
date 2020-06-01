using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class WorkoutRoutineInfo : WorkoutRoutineInfo<Guid>, IDALBaseDTO
    {
    }

    public class WorkoutRoutineInfo<TKey> : IDALBaseDTO<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; } = default!;
        public string CultureCode { get; set; } = default!;
        public string Description { get; set; } = default!;
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public TKey WorkoutRoutineId { get; set; }
    }
}