using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IExerciseInTrainingDayService ExercisesInTrainingDays { get; }
        IWorkoutRoutineService WorkoutRoutines { get; }
        ITrainingWeekService TrainingWeeks { get; }
        ITrainingDayService TrainingDays { get; }
        ITrainingCycleService TrainingCycles { get; }
        IBodyMeasurementService BodyMeasurements { get; }
        IDailyNutritionIntakeService DailyNutritionIntakes { get; }
        IExerciseService Exercises { get; }
        IUnitTypeService UnitTypes { get; }
        IMuscleService Muscles { get; }
        IMuscleGroupService MuscleGroups { get; }
        ITrainingDayTypeService TrainingDayTypes { get; }
        IExerciseTypeService ExerciseTypes { get; }
        IRoutineTypeService RoutineTypes { get; }
        IExerciseSetService ExerciseSets { get; }
        ISetTypeService SetTypes { get; }
    }
}