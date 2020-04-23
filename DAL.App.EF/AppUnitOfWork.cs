using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        private readonly IAppMapperContext _mapperContext;
        
        public IBodyMeasurementRepository BodyMeasurements => 
            GetRepository<IBodyMeasurementRepository>(
                ()=> new BodyMeasurementRepository(UnitOfWorkDbContext, _mapperContext.BodyMeasurementMapper));

        public IDailyNutritionIntakeRepository DailyNutritionIntakes => 
            GetRepository<IDailyNutritionIntakeRepository>(
                ()=> new DailyNutritionIntakeRepository(UnitOfWorkDbContext, _mapperContext.DailyNutritionIntakeMapper));

        public IPersonalRecordRepository PersonalRecords => 
            GetRepository<IPersonalRecordRepository>(
                ()=> new PersonalRecordRepository(UnitOfWorkDbContext, _mapperContext.PersonalRecordMapper));
        
        public IExerciseSetRepository ExerciseSets => 
            GetRepository<IExerciseSetRepository>(
                ()=> new ExerciseSetRepository(UnitOfWorkDbContext, _mapperContext.ExerciseSetMapper));

        public IExerciseRepository Exercises => 
            GetRepository<IExerciseRepository>(
                ()=> new ExerciseRepository(UnitOfWorkDbContext, _mapperContext.ExerciseMapper));
        
        public IExerciseTypeRepository ExerciseTypes => 
            GetRepository<IExerciseTypeRepository>(
                ()=> new ExerciseTypeRepository(UnitOfWorkDbContext, _mapperContext.ExerciseTypeMapper));
        
        public IMuscleGroupRepository MuscleGroups => 
            GetRepository<IMuscleGroupRepository>(
                ()=> new MuscleGroupRepository(UnitOfWorkDbContext, _mapperContext.MuscleGroupMapper));
        
        public IMuscleRepository Muscles => 
            GetRepository<IMuscleRepository>(
                ()=> new MuscleRepository(UnitOfWorkDbContext, _mapperContext.MuscleMapper));

        public IRoutineTypeRepository RoutineTypes => 
            GetRepository<IRoutineTypeRepository>(
                ()=> new RoutineTypeRepository(UnitOfWorkDbContext, _mapperContext.RoutineTypeMapper));
        
        public ITargetMuscleGroupRepository TargetMuscleGroups => 
            GetRepository<ITargetMuscleGroupRepository>(
                ()=> new TargetMuscleGroupRepository(UnitOfWorkDbContext, _mapperContext.TargetMuscleGroupMapper));
        
        public ITrainingCycleRepository TrainingCycles => 
            GetRepository<ITrainingCycleRepository>(
                ()=> new TrainingCycleRepository(UnitOfWorkDbContext, _mapperContext.TrainingCycleMapper));
        
        public ITrainingDayRepository TrainingDays => 
            GetRepository<ITrainingDayRepository>(
                ()=> new TrainingDayRepository(UnitOfWorkDbContext, _mapperContext.TrainingDayMapper));
        
        public ITrainingDayTypeRepository TrainingDayTypes => 
            GetRepository<ITrainingDayTypeRepository>(
                ()=> new TrainingDayTypeRepository(UnitOfWorkDbContext, _mapperContext.TrainingDayTypeMapper));
        
        public ITrainingWeekRepository TrainingWeeks => 
            GetRepository<ITrainingWeekRepository>(
                ()=> new TrainingWeekRepository(UnitOfWorkDbContext, _mapperContext.TrainingWeekMapper));
        

        public IUnitTypesRepository UnitTypes => 
            GetRepository<IUnitTypesRepository>(
                ()=> new UnitTypesRepository(UnitOfWorkDbContext, _mapperContext.UnitTypeMapper));

        public IWorkoutRoutineRepository WorkoutRoutines => 
            GetRepository<IWorkoutRoutineRepository>(
                ()=> new WorkoutRoutineRepository(UnitOfWorkDbContext, _mapperContext.WorkoutRoutineMapper));

        public AppUnitOfWork(AppDbContext unitOfWorkDbContext, IAppMapperContext ctx) : base(unitOfWorkDbContext)
        {
            _mapperContext = ctx;
        }
    }
}