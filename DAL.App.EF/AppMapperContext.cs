using Contracts.DAL.App;
using DAL.App.EF.Mappers;
using DAL.Base;
using DAL.Base.Mappers;
using Domain;

namespace DAL.App.EF
{
    public class AppMapperContext : BaseMapperContext, IAppMapperContext
    {
        public IDALMapper<UnitType, DTO.UnitType> UnitTypeMapper =>
            GetMapper(() => new UnitTypeMapper(this));

        public IDALMapper<BodyMeasurement, DTO.BodyMeasurement> BodyMeasurementMapper =>
            GetMapper(() => new BodyMeasurementMapper(this));

        public IDALMapper<DailyNutritionIntake, DTO.DailyNutritionIntake> DailyNutritionIntakeMapper =>
            GetMapper(() => new DailyNutritionIntakeMapper(this));

        public IDALMapper<Exercise, DTO.Exercise> ExerciseMapper =>
            GetMapper(() => new ExerciseMapper(this));
        
        public IDALMapper<ExerciseSet, DTO.ExerciseSet> ExerciseSetMapper =>
            GetMapper(() => new ExerciseSetMapper(this));
        
        public IDALMapper<ExerciseType, DTO.ExerciseType> ExerciseTypeMapper =>
            GetMapper(() => new ExerciseTypeMapper(this));

        public IDALMapper<MuscleGroup, DTO.MuscleGroup> MuscleGroupMapper =>
            GetMapper(() => new MuscleGroupMapper(this));
            
        public IDALMapper<Muscle, DTO.Muscle> MuscleMapper =>
            GetMapper(() => new MuscleMapper(this));
        
        public IDALMapper<PersonalRecord, DTO.PersonalRecord> PersonalRecordMapper =>
            GetMapper(() => new PersonalRecordMapper(this));
        
        public IDALMapper<RoutineType, DTO.RoutineType> RoutineTypeMapper =>
            GetMapper(() => new RoutineTypeMapper(this));
        
        public IDALMapper<TrainingCycle, DTO.TrainingCycle> TrainingCycleMapper =>
            GetMapper(() => new TrainingCycleMapper(this));
        
        public IDALMapper<TrainingDay, DTO.TrainingDay> TrainingDayMapper =>
            GetMapper(() => new TrainingDayMapper(this));
        
        public IDALMapper<TrainingWeek, DTO.TrainingWeek> TrainingWeekMapper =>
            GetMapper(() => new TrainingWeekMapper(this));
        
        public IDALMapper<WorkoutRoutine, DTO.WorkoutRoutine> WorkoutRoutineMapper =>
            GetMapper(() => new WorkoutRoutineMapper(this));
        
        public IDALMapper<TargetMuscleGroup, DTO.TargetMuscleGroup> TargetMuscleGroupMapper =>
            GetMapper(() => new TargetMuscleGroupMapper(this));

        public IDALMapper<TrainingDayType, DTO.TrainingDayType> TrainingDayTypeMapper =>
            GetMapper(() => new TrainingDayTypeMapper(this));
    }
}