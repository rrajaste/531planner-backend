using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using BLL.App.DTO;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using TrainingCycle = BLL.App.DTO.TrainingCycle;
using WorkoutRoutine = BLL.App.DTO.WorkoutRoutine;

namespace Contracts.BLL.App.Services
{
    public interface IWorkoutRoutineService : IBaseEntityService<WorkoutRoutine>, 
        IWorkoutRoutineRepository<Guid, WorkoutRoutine>
    {
        WorkoutRoutine GenerateNewFiveThreeOneRoutine(NewFiveThreeOneRoutineInfo routineInfo);
        Task<TrainingCycle> GenerateNewCycleForFiveThreeOneRoutine(WorkoutRoutine baseRoutine, NewFiveThreeOneCycleInfo cycleInfo);
        void AddTranslationToWorkoutRoutine(WorkoutRoutineTranslation dto, Guid workoutRoutineId);
        void UpdateTranslation(WorkoutRoutineTranslation translation, Guid routineId);
        Task<IEnumerable<WorkoutRoutineTranslation>> AllTranslationsForWorkoutRoutineWithIdAsync(Guid routineId);
    }
}