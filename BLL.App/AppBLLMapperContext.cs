using BLL.Base;
using BLL.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL
{
    public class AppBLLMapperContext : BaseMapperContext, IAppBLLMapperContext
    {
        public IBLLMapper<UnitType, App.DTO.UnitType> UnitTypeMapper =>
            GetMapper(() => new UnitTypeMapper(this));

        public IBLLMapper<BodyMeasurement, App.DTO.BodyMeasurement> BodyMeasurementMapper =>
            GetMapper(() => new BodyMeasurementMapper(this));

        public IBLLMapper<DailyNutritionIntake, App.DTO.DailyNutritionIntake> DailyNutritionIntakeMapper =>
            GetMapper(() => new DailyNutritionIntakeMapper(this));

        public IBLLMapper<Exercise, App.DTO.Exercise> ExerciseMapper =>
            GetMapper(() => new ExerciseMapper(this));


        public IExerciseSetMapper ExerciseSetMapper =>
            GetMapper(() => new ExerciseSetMapper(this));

        public IBLLMapper<ExerciseType, App.DTO.ExerciseType> ExerciseTypeMapper =>
            GetMapper(() => new ExerciseTypeMapper(this));

        public IBLLMapper<MuscleGroup, App.DTO.MuscleGroup> MuscleGroupMapper =>
            GetMapper(() => new MuscleGroupMapper(this));

        public IBLLMapper<Muscle, App.DTO.Muscle> MuscleMapper =>
            GetMapper(() => new MuscleMapper(this));

        public IBLLMapper<ExerciseInTrainingDay, App.DTO.ExerciseInTrainingDay> ExerciseInTrainingDayMapper =>
            GetMapper(() => new ExerciseInTrainingDayMapper(this));

        public IBLLMapper<RoutineType, App.DTO.RoutineType> RoutineTypeMapper =>
            GetMapper(() => new RoutineTypeMapper(this));

        public IBLLMapper<TrainingCycle, App.DTO.TrainingCycle> TrainingCycleMapper =>
            GetMapper(() => new TrainingCycleMapper(this));

        public ITrainingDayMapper TrainingDayMapper =>
            GetMapper(() => new TrainingDayMapper(this));

        public IBLLMapper<TrainingWeek, App.DTO.TrainingWeek> TrainingWeekMapper =>
            GetMapper(() => new TrainingWeekMapper(this));

        public IBLLMapper<WorkoutRoutine, App.DTO.WorkoutRoutine> WorkoutRoutineMapper =>
            GetMapper(() => new WorkoutRoutineMapper(this));

        public IBLLMapper<TargetMuscleGroup, App.DTO.TargetMuscleGroup> TargetMuscleGroupMapper =>
            GetMapper(() => new TargetMuscleGroupMapper(this));

        public IBLLMapper<TrainingDayType, App.DTO.TrainingDayType> TrainingDayTypeMapper =>
            GetMapper(() => new TrainingDayTypeMapper(this));

        public IBLLMapper<SetType, App.DTO.SetType> SetTypeMapper =>
            GetMapper(() => new SetTypeMapper(this));
    }
}