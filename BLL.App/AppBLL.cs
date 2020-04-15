using BLL.Base;
using BLL.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using DAL.App.EF;

namespace BLL
{
    public class AppBLL : BaseBLL<AppUnitOfWork>, IAppBLL
    {
        public AppBLL(AppUnitOfWork unitOfWork) : base(unitOfWork)
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
    }
}