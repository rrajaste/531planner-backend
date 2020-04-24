using BLL.Base;
using BLL.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        public AppBLL(IAppUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IPersonalRecordService PersonalRecords =>
            GetService<IPersonalRecordService>(() => new PersonalRecordService(UnitOfWork));
        public IWorkoutRoutineService WorkoutRoutines =>
            GetService<IWorkoutRoutineService>(() => new WorkoutRoutineService(UnitOfWork));
        public ITrainingWeekService TrainingWeeks =>
            GetService<ITrainingWeekService>(() => new TrainingWeekService(UnitOfWork));
        public ITrainingDayService TrainingDays =>
            GetService<ITrainingDayService>(() => new TrainingDayService(UnitOfWork));
        public IBodyMeasurementService BodyMeasurements =>
            GetService<IBodyMeasurementService>(() => new BodyMeasurementService(UnitOfWork));
        public IExerciseService Exercises =>
            GetService<IExerciseService>(() => new ExerciseService(UnitOfWork));
        public ITrainingCycleService TrainingCycles =>
            GetService<ITrainingCycleService>(() => new TrainingCycleService(TrainingCycle));
        public IExerciseSetService ExerciseSets =>
            GetService<IExerciseSetService>(() => new ExerciseSetService(ExerciseSet));
    }
}