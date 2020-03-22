using System;
using System.ComponentModel.DataAnnotations;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class WorkoutRoutine : DomainEntity
    { 
        public int WorkoutRoutineId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = default!;
        [MaxLength(255)]
        public string Description { get; set; } = default!;
        public Guid RoutineTypeId { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? User { get; set; }
        public RoutineType? RoutineType { get; set; }
    }
}