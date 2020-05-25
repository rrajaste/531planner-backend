using System;
using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public abstract class WorkoutRoutine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class FullWorkoutRoutine : WorkoutRoutine
    {
        public IEnumerable<TrainingCycle> TrainingCycles { get; set; }
    }
    
    public class BaseWorkoutRoutine : WorkoutRoutine
    {
    }
}