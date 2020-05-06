using BLL.Base;
using BLL.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.DAL.App;
using BLL.App.DTO;

namespace BLL
{
    public class AppBLLMapperContext : BaseMapperContext, IAppBLLMapperContext
    {
        public IBLLMapper<DAL.App.DTO.UnitType, UnitType> UnitTypeMapper =>
            GetMapper(() => new UnitTypeMapper(this));

        public IBLLMapper<DAL.App.DTO.BodyMeasurement, BodyMeasurement> BodyMeasurementMapper =>
            GetMapper(() => new BodyMeasurementMapper(this));

        public IBLLMapper<DAL.App.DTO.DailyNutritionIntake, DailyNutritionIntake> DailyNutritionIntakeMapper =>
            GetMapper(() => new DailyNutritionIntakeMapper(this));

        public IBLLMapper<DAL.App.DTO.Exercise, Exercise> ExerciseMapper =>
            GetMapper(() => new ExerciseMapper(this));
        
        public IBLLMapper<DAL.App.DTO.ExerciseSet, ExerciseSet> ExerciseSetMapper =>
            GetMapper(() => new ExerciseSetMapper(this));
        
        public IBLLMapper<DAL.App.DTO.ExerciseType, ExerciseType> ExerciseTypeMapper =>
            GetMapper(() => new ExerciseTypeMapper(this));

        public IBLLMapper<DAL.App.DTO.MuscleGroup, MuscleGroup> MuscleGroupMapper =>
            GetMapper(() => new MuscleGroupMapper(this));
            
        public IBLLMapper<DAL.App.DTO.Muscle, Muscle> MuscleMapper =>
            GetMapper(() => new MuscleMapper(this));
        
        public IBLLMapper<DAL.App.DTO.PersonalRecord, PersonalRecord> PersonalRecordMapper =>
            GetMapper(() => new PersonalRecordMapper(this));
        
        public IBLLMapper<DAL.App.DTO.RoutineType, RoutineType> RoutineTypeMapper =>
            GetMapper(() => new RoutineTypeMapper(this));
        
        public IBLLMapper<DAL.App.DTO.TrainingCycle, TrainingCycle> TrainingCycleMapper =>
            GetMapper(() => new TrainingCycleMapper(this));
        
        public IBLLMapper<DAL.App.DTO.TrainingDay, TrainingDay> TrainingDayMapper =>
            GetMapper(() => new TrainingDayMapper(this));
        
        public IBLLMapper<DAL.App.DTO.TrainingWeek, TrainingWeek> TrainingWeekMapper =>
            GetMapper(() => new TrainingWeekMapper(this));
        
        public IBLLMapper<DAL.App.DTO.WorkoutRoutine, WorkoutRoutine> WorkoutRoutineMapper =>
            GetMapper(() => new WorkoutRoutineMapper(this));
        
        public IBLLMapper<DAL.App.DTO.TargetMuscleGroup, TargetMuscleGroup> TargetMuscleGroupMapper =>
            GetMapper(() => new TargetMuscleGroupMapper(this));

        public IBLLMapper<DAL.App.DTO.TrainingDayType, TrainingDayType> TrainingDayTypeMapper =>
            GetMapper(() => new TrainingDayTypeMapper(this));
        
        public IBLLMapper<DAL.App.DTO.SetType, SetType> SetTypeMapper =>
            GetMapper(() => new SetTypeMapper(this));
    }
}