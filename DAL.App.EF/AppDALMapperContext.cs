using Contracts.DAL.App;
using DAL.App.EF.Mappers;
using DAL.Base;
using Contracts.DAL.App.Mappers;
using Domain;
using Domain.App;

namespace DAL.App.EF
{
    public class AppDALMapperContext : BaseMapperContext, IAppDALMapperContext
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
        
        public IDALMapper<ExerciseInTrainingDay, DTO.ExerciseInTrainingDay> ExerciseInTrainingDayMapper =>
            GetMapper(() => new ExerciseInTrainingDayMapper(this));
        
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
        
        public IDALMapper<SetType, DTO.SetType> SetTypeMapper =>
            GetMapper(() => new SetTypeMapper(this));
        public IDALMapper<WorkoutRoutineInfo, DTO.WorkoutRoutineInfo> WorkoutRoutineInfoMapper =>
            GetMapper(() => new WorkoutRoutineInfoMapper(this));
        
    }
}