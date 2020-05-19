using Contracts.DAL.App.Mappers;
using DAL.App.DTO;

namespace Contracts.DAL.App
{
    public interface IAppDALMapperContext
    {
        IDALMapper<global::Domain.App.UnitType, UnitType> UnitTypeMapper { get; }
        IDALMapper<global::Domain.App.BodyMeasurement, BodyMeasurement> BodyMeasurementMapper { get; }
        IDALMapper<global::Domain.App.DailyNutritionIntake, DailyNutritionIntake> DailyNutritionIntakeMapper { get; }
        IDALMapper<global::Domain.App.Exercise, Exercise> ExerciseMapper { get; }
        IDALMapper<global::Domain.App.ExerciseSet, ExerciseSet> ExerciseSetMapper { get; }
        IDALMapper<global::Domain.App.ExerciseType, ExerciseType> ExerciseTypeMapper { get; }
        IDALMapper<global::Domain.App.MuscleGroup, MuscleGroup> MuscleGroupMapper { get; }
        IDALMapper<global::Domain.App.Muscle, Muscle> MuscleMapper { get; }
        IDALMapper<global::Domain.App.ExerciseInTrainingDay, ExerciseInTrainingDay> ExerciseInTrainingDayMapper { get; }
        IDALMapper<global::Domain.App.RoutineType, RoutineType> RoutineTypeMapper { get; }
        IDALMapper<global::Domain.App.TrainingCycle, TrainingCycle> TrainingCycleMapper { get; }
        IDALMapper<global::Domain.App.TrainingDay, TrainingDay> TrainingDayMapper { get; }
        IDALMapper<global::Domain.App.TrainingWeek, TrainingWeek> TrainingWeekMapper { get; }
        IDALMapper<global::Domain.App.WorkoutRoutine, WorkoutRoutine> WorkoutRoutineMapper { get; }
        IDALMapper<global::Domain.App.TargetMuscleGroup, TargetMuscleGroup> TargetMuscleGroupMapper { get; }
        IDALMapper<global::Domain.App.TrainingDayType, TrainingDayType> TrainingDayTypeMapper { get; }
        IDALMapper<global::Domain.App.SetType, SetType> SetTypeMapper { get; }
    }
}