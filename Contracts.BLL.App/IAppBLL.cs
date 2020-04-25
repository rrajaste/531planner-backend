using Contracts.BLL.App.Services;
using Contracts.BLL.Base;
using Contracts.BLL.Base.Services;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        public IPersonalRecordService PersonalRecords { get; }
        public IWorkoutRoutineService WorkoutRoutines { get; }
        public ITrainingWeekService TrainingWeeks { get; }
        public ITrainingDayService TrainingDays { get; }
        public IBodyMeasurementService BodyMeasurements { get; }
        public IDailyNutritionIntakeService DailyNutritionIntakes { get; }
        public IExerciseService Exercises { get; }
        public IUnitTypeService UnitTypes { get; }
        public IMuscleService Muscles { get; }
        public IMuscleGroupService MuscleGroups { get; }
    }
}