using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        public IPersonalRecordService PersonalRecords { get; }
        public IWorkoutRoutineService WorkoutRoutines { get; }
        public ITrainingWeekService TrainingWeeks { get; }
        public ITrainingDayService TrainingDays { get; }
        public IBodyMeasurementService BodyMeasurements { get; }
        public IExerciseService Exercises { get; }
    }
}