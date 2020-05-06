using Contracts.BLL.App.Mappers;
using bllDTO =  BLL.App.DTO;
using dalDTO = DAL.App.DTO;

namespace Contracts.DAL.App
{
    public interface IAppBLLMapperContext
    {
        IBLLMapper<dalDTO.UnitType, bllDTO.UnitType> UnitTypeMapper { get; }
        IBLLMapper<dalDTO.BodyMeasurement, bllDTO.BodyMeasurement> BodyMeasurementMapper { get; }
        IBLLMapper<dalDTO.DailyNutritionIntake, bllDTO.DailyNutritionIntake> DailyNutritionIntakeMapper { get; }
        IBLLMapper<dalDTO.Exercise, bllDTO.Exercise> ExerciseMapper { get; }
        IBLLMapper<dalDTO.ExerciseSet, bllDTO.ExerciseSet> ExerciseSetMapper { get; }
        IBLLMapper<dalDTO.ExerciseType, bllDTO.ExerciseType> ExerciseTypeMapper { get; }
        IBLLMapper<dalDTO.MuscleGroup, bllDTO.MuscleGroup> MuscleGroupMapper { get; }
        IBLLMapper<dalDTO.Muscle, bllDTO.Muscle> MuscleMapper { get; }
        IBLLMapper<dalDTO.PersonalRecord, bllDTO.PersonalRecord> PersonalRecordMapper { get; }
        IBLLMapper<dalDTO.RoutineType, bllDTO.RoutineType> RoutineTypeMapper { get; }
        IBLLMapper<dalDTO.TrainingCycle, bllDTO.TrainingCycle> TrainingCycleMapper { get; }
        IBLLMapper<dalDTO.TrainingDay, bllDTO.TrainingDay> TrainingDayMapper { get; }
        IBLLMapper<dalDTO.TrainingWeek, bllDTO.TrainingWeek> TrainingWeekMapper { get; }
        IBLLMapper<dalDTO.WorkoutRoutine, bllDTO.WorkoutRoutine> WorkoutRoutineMapper { get; }
        IBLLMapper<dalDTO.TargetMuscleGroup, bllDTO.TargetMuscleGroup> TargetMuscleGroupMapper { get; }
        IBLLMapper<dalDTO.TrainingDayType, bllDTO.TrainingDayType> TrainingDayTypeMapper { get; }
        IBLLMapper<dalDTO.SetType, bllDTO.SetType> SetTypeMapper { get; }
    }
}