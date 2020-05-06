using BLL.Base;
using BLL.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected IAppBLLMapperContext MapperContext;
        
        public AppBLL(IAppUnitOfWork unitOfWork, IAppBLLMapperContext mapperContext) : base(unitOfWork)
        {
            MapperContext = mapperContext;
        }

        public IPersonalRecordService PersonalRecords =>
            GetService<IPersonalRecordService>(
                () => new PersonalRecordService(UnitOfWork, MapperContext.PersonalRecordMapper));
        public IWorkoutRoutineService WorkoutRoutines =>
            GetService<IWorkoutRoutineService>(
                () => new WorkoutRoutineService(UnitOfWork, MapperContext.WorkoutRoutineMapper));
        public ITrainingWeekService TrainingWeeks =>
            GetService<ITrainingWeekService>(
                () => new TrainingWeekService(UnitOfWork, MapperContext.TrainingWeekMapper));
        public ITrainingDayService TrainingDays =>
            GetService<ITrainingDayService>(
                () => new TrainingDayService(UnitOfWork, MapperContext.TrainingDayMapper));
        public ITrainingCycleService TrainingCycles => 
            GetService<ITrainingCycleService>(
                () => new TrainingCycleService(UnitOfWork, MapperContext.TrainingCycleMapper));
        public IBodyMeasurementService BodyMeasurements =>
            GetService<IBodyMeasurementService>(
                () => new BodyMeasurementService(UnitOfWork, MapperContext.BodyMeasurementMapper));
        public IDailyNutritionIntakeService DailyNutritionIntakes => 
            GetService<IDailyNutritionIntakeService>(
                () => new DailyNutritionIntakeService(UnitOfWork, MapperContext.DailyNutritionIntakeMapper));
        public IExerciseService Exercises =>
            GetService<IExerciseService>(
                () => new ExerciseService(UnitOfWork, MapperContext.ExerciseMapper));
        public IUnitTypeService UnitTypes =>
            GetService<IUnitTypeService>(
            () => new UnitTypeService(UnitOfWork, MapperContext.UnitTypeMapper));
        public IMuscleService Muscles =>
            GetService<IMuscleService>(
                () => new MuscleService(UnitOfWork, MapperContext.MuscleMapper));
        public IMuscleGroupService MuscleGroups =>
            GetService<IMuscleGroupService>(
                () => new MuscleGroupService(UnitOfWork, MapperContext.MuscleGroupMapper));
        public ITrainingDayTypeService TrainingDayTypes => 
            GetService<ITrainingDayTypeService>(
                () => new TrainingDayTypeService(UnitOfWork, MapperContext.TrainingDayTypeMapper));
        public IExerciseTypeService ExerciseTypes => 
            GetService<IExerciseTypeService>(
                () => new ExerciseTypeService(UnitOfWork, MapperContext.ExerciseTypeMapper));
        public IRoutineTypeService RoutineTypes =>
            GetService<IRoutineTypeService>(
                () => new RoutineTypeService(UnitOfWork, MapperContext.RoutineTypeMapper));
    }
}