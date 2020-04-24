using Contracts.DAL.App.Mappers;
using DAL.App.DTO;

namespace Contracts.DAL.App
{
    public interface IAppMapperContext
    {
        IDALMapper<Domain.UnitType, UnitType> UnitTypeMapper { get; }
        IDALMapper<Domain.BodyMeasurement, BodyMeasurement> BodyMeasurementMapper { get; }
        IDALMapper<Domain.DailyNutritionIntake, DailyNutritionIntake> DailyNutritionIntakeMapper { get; }
        IDALMapper<Domain.Exercise, Exercise> ExerciseMapper { get; }
        IDALMapper<Domain.ExerciseSet, ExerciseSet> ExerciseSetMapper { get; }
        IDALMapper<Domain.ExerciseType, ExerciseType> ExerciseTypeMapper { get; }
        IDALMapper<Domain.MuscleGroup, MuscleGroup> MuscleGroupMapper { get; }
        IDALMapper<Domain.Muscle, Muscle> MuscleMapper { get; }
        IDALMapper<Domain.PersonalRecord, PersonalRecord> PersonalRecordMapper { get; }
        IDALMapper<Domain.RoutineType, RoutineType> RoutineTypeMapper { get; }
        IDALMapper<Domain.TrainingCycle, TrainingCycle> TrainingCycleMapper { get; }
        IDALMapper<Domain.TrainingDay, TrainingDay> TrainingDayMapper { get; }
        IDALMapper<Domain.TrainingWeek, TrainingWeek> TrainingWeekMapper { get; }
        IDALMapper<Domain.WorkoutRoutine, WorkoutRoutine> WorkoutRoutineMapper { get; }
        IDALMapper<Domain.TargetMuscleGroup, TargetMuscleGroup> TargetMuscleGroupMapper { get; }
        IDALMapper<Domain.TrainingDayType, TrainingDayType> TrainingDayTypeMapper { get; }
    }
}