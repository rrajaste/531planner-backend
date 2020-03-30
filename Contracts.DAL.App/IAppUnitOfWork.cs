using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;


namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IBodyMeasurementRepository BodyMeasurements { get; }
        IDailyNutritionIntakeRepository DailyNutritionIntakes { get; }
        IExerciseInTrainingDayRepository ExercisesInTrainingDays { get; }
        IExerciseRepository Exercises { get; }
        IExerciseTypeRepository ExerciseTypes { get; }
        IMuscleGroupRepository MuscleGroups { get; }
        IMuscleRepository Muscles { get; }
        IPerformedExerciseRepository PerformedExercises { get; }
        IRoutineTypeRepository RoutineTypes { get; }
        ITargetMuscleGroupRepository TargetMuscleGroups { get; }
        ITrainingCycleRepository TrainingCycles { get; }
        ITrainingDayRepository TrainingDays { get; }
        ITrainingDayTypeRepository TrainingDayTypes { get; }
        ITrainingWeekRepository TrainingWeeks { get; }
        IUnitTypesRepository UnitTypes { get; }
        IWorkoutRoutineRepository WorkoutRoutines { get; }
    }
}