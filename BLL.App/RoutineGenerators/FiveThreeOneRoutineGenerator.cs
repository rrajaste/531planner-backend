using System;
using System.Collections.Generic;
using BLL.App.DTO;
using Contracts.BLL.App.RoutineGenerators;

namespace BLL.RoutineGenerators
{
    public class FiveThreeOneRoutineGenerator : BaseRoutineGenerator<NewFiveThreeOneRoutineInfo>, IFiveThreeOneRoutineGenerator
    {
        public FiveThreeOneRoutineGenerator(NewFiveThreeOneRoutineInfo newRoutineInfo) : base(newRoutineInfo)
        {
        }

        protected override ExerciseInTrainingDay GenerateExercise(ExerciseInTrainingDay baseExercise, int trainingWeekNumber, Guid parentId)
        {
            var exercise = new ExerciseInTrainingDay()
            {
                Id = new Guid(),
                TrainingDayId = parentId,
                ExerciseTypeId = baseExercise.ExerciseTypeId
            };
            if (baseExercise.WarmUpSets == null)
            {
                throw new ApplicationException(
                    $"Routine generation failed: base ExerciseInTrainingDay with ID ${baseExercise.Id} warm-up sets are null.");
            }
            
            exercise.WarmUpSets = GenerateExerciseSets(baseExercise.WarmUpSets, exercise.Id, baseExercise.ExerciseId);
            
            if (baseExercise.WorkSets == null)
            {
                throw new ApplicationException(
                    $"Routine generation failed: base ExerciseInTrainingDay with ID ${baseExercise.Id} work sets are null.");
            }
            
            exercise.WorkSets = GenerateExerciseSets(baseExercise.WarmUpSets, exercise.Id, baseExercise.ExerciseId);

            return exercise;
        }
        
        protected virtual IEnumerable<ExerciseSet> GenerateExerciseSets(IEnumerable<ExerciseSet> baseSets, Guid parentId, Guid exerciseId)
        {
            var exerciseSets = new List<ExerciseSet>();
            foreach (var set in baseSets)
            {
                var weight = GetUserExerciseSetWeight(exerciseId);
                var generatedSet = GenerateExerciseSet(set, weight);
                generatedSet.Id = parentId;
                exerciseSets.Add(generatedSet);
            }
            return exerciseSets;
        }

        protected virtual ExerciseSet GenerateExerciseSet(ExerciseSet exerciseSet, float weight)
        {
            return new ExerciseSet()
            {
                Id = new Guid(),
                Completed = false,
                Distance = exerciseSet.Distance,
                Duration = exerciseSet.Duration,
                NrOfReps = exerciseSet.NrOfReps,
                SetNumber = exerciseSet.SetNumber,
                Weight = weight,
                UnitTypeId = NewRoutineInfo.UnitTypeId,
            };
        }

        protected virtual float GetUserExerciseSetWeight(Guid exerciseInTrainingDayId)
        {
            var setWeight = 0F;
            var wendlerMaxes = NewRoutineInfo.CycleInfo.WendlerMaxes;
            if (exerciseInTrainingDayId == NewRoutineInfo.DeadliftExerciseId)
            {
                setWeight = wendlerMaxes.DeadliftMax;
            } else if (exerciseInTrainingDayId == NewRoutineInfo.BenchPressExerciseId)
            {
                setWeight = wendlerMaxes.BenchPressMax;
            } else if (exerciseInTrainingDayId == NewRoutineInfo.SquatExerciseId)
            {
                setWeight = wendlerMaxes.SquatMax;
            }
            else if (exerciseInTrainingDayId == NewRoutineInfo.OverheadPressExerciseId)
            {
                setWeight = wendlerMaxes.OverHeadPressMax;
            }
            return setWeight;
        }
    }
}