using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.App.Repositories.Identity;
using DAL.App.EF.Repositories;
using DAL.App.EF.Repositories.Identity;
using DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        
        public IAppUserRoleRepository AppUserRoles => 
            GetRepository<IAppUserRoleRepository>(
                ()=> new AppUserRoleRepository(UnitOfWorkDbContext));

        public IAppUserRepository AppUsers => 
            GetRepository<IAppUserRepository>(
            ()=> new AppUserRepository(UnitOfWorkDbContext));
        
        public IBodyMeasurementRepository BodyMeasurements => 
            GetRepository<IBodyMeasurementRepository>(
                ()=> new BodyMeasurementRepository(UnitOfWorkDbContext));

        public IDailyNutritionIntakeRepository DailyNutritionIntakes => 
            GetRepository<IDailyNutritionIntakeRepository>(
                ()=> new DailyNutritionIntakeRepository(UnitOfWorkDbContext));

        public IPersonalRecordRepository PersonalRecords => 
            GetRepository<IPersonalRecordRepository>(
                ()=> new PersonalRecordRepository(UnitOfWorkDbContext));
        
        public IExerciseSetRepository ExerciseSets => 
            GetRepository<IExerciseSetRepository>(
                ()=> new ExerciseSetRepository(UnitOfWorkDbContext));

        public IExerciseRepository Exercises => 
            GetRepository<IExerciseRepository>(
                ()=> new ExerciseRepository(UnitOfWorkDbContext));
        
        public IExerciseTypeRepository ExerciseTypes => 
            GetRepository<IExerciseTypeRepository>(
                ()=> new ExerciseTypeRepository(UnitOfWorkDbContext));
        
        public IMuscleGroupRepository MuscleGroups => 
            GetRepository<IMuscleGroupRepository>(
                ()=> new MuscleGroupRepository(UnitOfWorkDbContext));
        
        public IMuscleRepository Muscles => 
            GetRepository<IMuscleRepository>(
                ()=> new MuscleRepository(UnitOfWorkDbContext));

        public IRoutineTypeRepository RoutineTypes => 
            GetRepository<IRoutineTypeRepository>(
                ()=> new RoutineTypeRepository(UnitOfWorkDbContext));
        
        public ITargetMuscleGroupRepository TargetMuscleGroups => 
            GetRepository<ITargetMuscleGroupRepository>(
                ()=> new TargetMuscleGroupRepository(UnitOfWorkDbContext));
        
        public ITrainingCycleRepository TrainingCycles => 
            GetRepository<ITrainingCycleRepository>(
                ()=> new TrainingCycleRepository(UnitOfWorkDbContext));
        
        public ITrainingDayRepository TrainingDays => 
            GetRepository<ITrainingDayRepository>(
                ()=> new TrainingDayRepository(UnitOfWorkDbContext));
        
        public ITrainingDayTypeRepository TrainingDayTypes => 
            GetRepository<ITrainingDayTypeRepository>(
                ()=> new TrainingDayTypeRepository(UnitOfWorkDbContext));
        
        public ITrainingWeekRepository TrainingWeeks => 
            GetRepository<ITrainingWeekRepository>(
                ()=> new TrainingWeekRepository(UnitOfWorkDbContext));
        

        public IUnitTypesRepository UnitTypes => 
            GetRepository<IUnitTypesRepository>(()=> new UnitTypesRepository(UnitOfWorkDbContext));

        public IWorkoutRoutineRepository WorkoutRoutines => 
            GetRepository<IWorkoutRoutineRepository>(
                ()=> new WorkoutRoutineRepository(UnitOfWorkDbContext));

        public AppUnitOfWork(AppDbContext unitOfWorkDbContext) : base(unitOfWorkDbContext)
        {
        }
    }
}