using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        private readonly IAppDALMapperContext _dalMapperContext;
        
        public IBodyMeasurementRepository BodyMeasurements => 
            GetRepository<IBodyMeasurementRepository>(
                ()=> new BodyMeasurementRepository(UnitOfWorkDbContext, _dalMapperContext.BodyMeasurementMapper));

        public IDailyNutritionIntakeRepository DailyNutritionIntakes => 
            GetRepository<IDailyNutritionIntakeRepository>(
                ()=> new DailyNutritionIntakeRepository(UnitOfWorkDbContext, _dalMapperContext.DailyNutritionIntakeMapper));

        public IExerciseInTrainingDayRepository ExercisesInTrainingDay => 
            GetRepository<IExerciseInTrainingDayRepository>(
                ()=> new ExerciseInTrainingDayRepository(UnitOfWorkDbContext, _dalMapperContext.ExerciseInTrainingDayMapper));
        
        public IExerciseSetRepository ExerciseSets => 
            GetRepository<IExerciseSetRepository>(
                ()=> new ExerciseSetRepository(UnitOfWorkDbContext, _dalMapperContext.ExerciseSetMapper));

        public IExerciseRepository Exercises => 
            GetRepository<IExerciseRepository>(
                ()=> new ExerciseRepository(UnitOfWorkDbContext, _dalMapperContext.ExerciseMapper));
        
        public IExerciseTypeRepository ExerciseTypes => 
            GetRepository<IExerciseTypeRepository>(
                ()=> new ExerciseTypeRepository(UnitOfWorkDbContext, _dalMapperContext.ExerciseTypeMapper));
        
        public IMuscleGroupRepository MuscleGroups => 
            GetRepository<IMuscleGroupRepository>(
                ()=> new MuscleGroupRepository(UnitOfWorkDbContext, _dalMapperContext.MuscleGroupMapper));
        
        public IMuscleRepository Muscles => 
            GetRepository<IMuscleRepository>(
                ()=> new MuscleRepository(UnitOfWorkDbContext, _dalMapperContext.MuscleMapper));

        public IRoutineTypeRepository RoutineTypes => 
            GetRepository<IRoutineTypeRepository>(
                ()=> new RoutineTypeRepository(UnitOfWorkDbContext, _dalMapperContext.RoutineTypeMapper));
        
        public ITargetMuscleGroupRepository TargetMuscleGroups => 
            GetRepository<ITargetMuscleGroupRepository>(
                ()=> new TargetMuscleGroupRepository(UnitOfWorkDbContext, _dalMapperContext.TargetMuscleGroupMapper));
        
        public ITrainingCycleRepository TrainingCycles => 
            GetRepository<ITrainingCycleRepository>(
                ()=> new TrainingCycleRepository(UnitOfWorkDbContext, _dalMapperContext.TrainingCycleMapper));
        
        public ITrainingDayRepository TrainingDays => 
            GetRepository<ITrainingDayRepository>(
                ()=> new TrainingDayRepository(UnitOfWorkDbContext, _dalMapperContext.TrainingDayMapper));
        
        public ITrainingDayTypeRepository TrainingDayTypes => 
            GetRepository<ITrainingDayTypeRepository>(
                ()=> new TrainingDayTypeRepository(UnitOfWorkDbContext, _dalMapperContext.TrainingDayTypeMapper));
        
        public ITrainingWeekRepository TrainingWeeks => 
            GetRepository<ITrainingWeekRepository>(
                ()=> new TrainingWeekRepository(UnitOfWorkDbContext, _dalMapperContext.TrainingWeekMapper));
        

        public IUnitTypesRepository UnitTypes => 
            GetRepository<IUnitTypesRepository>(
                ()=> new UnitTypesRepository(UnitOfWorkDbContext, _dalMapperContext.UnitTypeMapper));

        public IWorkoutRoutineRepository WorkoutRoutines => 
            GetRepository<IWorkoutRoutineRepository>(
                ()=> new WorkoutRoutineRepository(UnitOfWorkDbContext, _dalMapperContext.WorkoutRoutineMapper));

        public ISetTypeRepository SetTypes => 
            GetRepository<SetTypeRepository>(
                ()=> new SetTypeRepository(UnitOfWorkDbContext, _dalMapperContext.SetTypeMapper));
        
        public AppUnitOfWork(AppDbContext unitOfWorkDbContext, IAppDALMapperContext ctx) : base(unitOfWorkDbContext)
        {
            _dalMapperContext = ctx;
        }
    }
}