using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        public IExerciseInTrainingDayService ExercisesInTrainingDays { get; }
        public IWorkoutRoutineService WorkoutRoutines { get; }
        public ITrainingWeekService TrainingWeeks { get; }
        public ITrainingDayService TrainingDays { get; }
        public ITrainingCycleService TrainingCycles { get; }
        public IBodyMeasurementService BodyMeasurements { get; }
        public IDailyNutritionIntakeService DailyNutritionIntakes { get; }
        public IExerciseService Exercises { get; }
        public IUnitTypeService UnitTypes { get; }
        public IMuscleService Muscles { get; }
        public IMuscleGroupService MuscleGroups { get; }
        public ITrainingDayTypeService TrainingDayTypes { get; }
        public IExerciseTypeService ExerciseTypes { get; }
        public IRoutineTypeService RoutineTypes { get; }
        public IExerciseSetService ExerciseSets { get; }
        public ISetTypeService SetTypes { get; }
    }
}