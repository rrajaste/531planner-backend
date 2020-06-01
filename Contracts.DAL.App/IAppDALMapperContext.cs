using Contracts.DAL.App.Mappers;
using Domain.App;

namespace Contracts.DAL.App
{
    public interface IAppDALMapperContext
    {
        IDALMapper<UnitType, global::DAL.App.DTO.UnitType> UnitTypeMapper { get; }
        IDALMapper<BodyMeasurement, global::DAL.App.DTO.BodyMeasurement> BodyMeasurementMapper { get; }
        IDALMapper<DailyNutritionIntake, global::DAL.App.DTO.DailyNutritionIntake> DailyNutritionIntakeMapper { get; }
        IDALMapper<Exercise, global::DAL.App.DTO.Exercise> ExerciseMapper { get; }
        IDALMapper<ExerciseSet, global::DAL.App.DTO.ExerciseSet> ExerciseSetMapper { get; }
        IDALMapper<ExerciseType, global::DAL.App.DTO.ExerciseType> ExerciseTypeMapper { get; }
        IDALMapper<MuscleGroup, global::DAL.App.DTO.MuscleGroup> MuscleGroupMapper { get; }
        IDALMapper<Muscle, global::DAL.App.DTO.Muscle> MuscleMapper { get; }

        IDALMapper<ExerciseInTrainingDay, global::DAL.App.DTO.ExerciseInTrainingDay> ExerciseInTrainingDayMapper
        {
            get;
        }

        IDALMapper<RoutineType, global::DAL.App.DTO.RoutineType> RoutineTypeMapper { get; }
        IDALMapper<TrainingCycle, global::DAL.App.DTO.TrainingCycle> TrainingCycleMapper { get; }
        IDALMapper<TrainingDay, global::DAL.App.DTO.TrainingDay> TrainingDayMapper { get; }
        IDALMapper<TrainingWeek, global::DAL.App.DTO.TrainingWeek> TrainingWeekMapper { get; }
        IDALMapper<WorkoutRoutine, global::DAL.App.DTO.WorkoutRoutine> WorkoutRoutineMapper { get; }
        IDALMapper<TargetMuscleGroup, global::DAL.App.DTO.TargetMuscleGroup> TargetMuscleGroupMapper { get; }
        IDALMapper<TrainingDayType, global::DAL.App.DTO.TrainingDayType> TrainingDayTypeMapper { get; }
        IDALMapper<SetType, global::DAL.App.DTO.SetType> SetTypeMapper { get; }
        IDALMapper<WorkoutRoutineInfo, global::DAL.App.DTO.WorkoutRoutineInfo> WorkoutRoutineInfoMapper { get; }
    }
}