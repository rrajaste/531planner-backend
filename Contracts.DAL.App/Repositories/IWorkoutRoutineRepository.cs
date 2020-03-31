using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkoutRoutineRepository : IBaseRepository<WorkoutRoutine>
    {
        // TODO: Abstract the key type
        WorkoutRoutine ActiveRoutineForUserId(Guid id);
        Task<WorkoutRoutine> ActiveRoutineForUserIdAsync(Guid id);
        IEnumerable<WorkoutRoutine> AllNonActiveRoutinesForUserId(Guid id);
        Task<IEnumerable<WorkoutRoutine>> AllNonActiveRoutinesForUserIdAsync(Guid id);
        IEnumerable<WorkoutRoutine> AllBaseRoutines();
        Task<IEnumerable<WorkoutRoutine>> AllBaseRoutinesAsync();
    }
}