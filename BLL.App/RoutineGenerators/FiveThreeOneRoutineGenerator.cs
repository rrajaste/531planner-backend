using System;
using System.Collections.Generic;
using BLL.App.DTO;
using Contracts.BLL.App.RoutineGenerators;
using Domain.App.Enums;

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
                Id = Guid.NewGuid(),
                TrainingDayId = parentId,
                ExerciseTypeId = baseExercise.ExerciseTypeId,
                ExerciseId = baseExercise.ExerciseId,
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
            
            exercise.WorkSets = GenerateExerciseSets(baseExercise.WorkSets, exercise.Id, baseExercise.ExerciseId);

            return exercise;
        }
        
        protected virtual IEnumerable<ExerciseSet> GenerateExerciseSets(IEnumerable<ExerciseSet> baseSets, Guid parentId, Guid exerciseId)
        {
            var exerciseSets = new List<ExerciseSet>();
            foreach (var set in baseSets)
            {
                if (set.Weight == null)
                {
                    throw new ApplicationException(
                        $"Routine generation failed: base set ID ${set.Id} set weight is null.");
                }
                var weight = GetUserExerciseSetWeight(exerciseId, (float) set.Weight);
                var generatedSet = GenerateExerciseSet(set, weight);
                generatedSet.ExerciseInTrainingDayId = parentId;
                exerciseSets.Add(generatedSet);
            }
            return exerciseSets;
        }

        protected virtual ExerciseSet GenerateExerciseSet(ExerciseSet exerciseSet, float weight)
        {
            return new ExerciseSet()
            {
                Id = Guid.NewGuid(),
                Completed = false,
                Distance = exerciseSet.Distance,
                Duration = exerciseSet.Duration,
                NrOfReps = exerciseSet.NrOfReps,
                SetNumber = exerciseSet.SetNumber,
                Weight = weight,
                UnitTypeId = NewRoutineInfo.CycleInfo.UnitTypeId,
                SetTypeId = exerciseSet.SetTypeId,
                WorkoutRoutineId = NewRoutineId
            };
        }

        protected virtual float GetUserExerciseSetWeight(Guid exerciseInTrainingDayId, float baseWeight)
        {
            var setWeight = 0F;
            var wendlerMaxes = NewRoutineInfo.CycleInfo;
            if (exerciseInTrainingDayId == MainLiftExerciseIDs.DeadLift)
            {
                setWeight = wendlerMaxes.DeadliftMax * (baseWeight / 100);
            } else if (exerciseInTrainingDayId == MainLiftExerciseIDs.BenchPress)
            {
                setWeight = wendlerMaxes.BenchPressMax * (baseWeight / 100);
            } else if (exerciseInTrainingDayId == MainLiftExerciseIDs.Squat)
            {
                setWeight = wendlerMaxes.SquatMax * (baseWeight / 100);
            }
            else if (exerciseInTrainingDayId == MainLiftExerciseIDs.OverHeadPress)
            {
                setWeight = wendlerMaxes.OverHeadPressMax * (baseWeight / 100);
            }
            return setWeight;
        }
    }
}