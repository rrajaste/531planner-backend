using BLL.Base;
using BLL.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.EF;

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
        public IDailyNutritionIntakeService DailyNutritionIntakes => 
            GetService<IDailyNutritionIntakeService>(() => new DailyNutritionIntakeService(UnitOfWork));
        public IExerciseService Exercises =>
            GetService<IExerciseService>(() => new ExerciseService(UnitOfWork));
        public IUnitTypeService UnitTypes =>
            GetService<IUnitTypeService>(() => new UnitTypeService(UnitOfWork));
        public IMuscleService Muscles =>
            GetService<IMuscleService>(() => new MuscleService(UnitOfWork));
        public IMuscleGroupService MuscleGroups =>
            GetService<IMuscleGroupService>(() => new MuscleGroupService(UnitOfWork));
    }
}