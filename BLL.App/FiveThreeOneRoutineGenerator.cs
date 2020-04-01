using System;
using System.Collections.Generic;
using App.DTO;
using Contracts.BLL.App;
using Domain;

namespace BLL
{
    public class FiveThreeOneRoutineGenerator : BaseRoutineGenerator<NewFiveThreeOneRoutineDto>, IFiveThreeOneRoutineGenerator
    {
        
        protected static readonly Dictionary<int, float[]> MainLiftLoadCoefficientMap = new Dictionary<int, float[]>()
        {
            [1] = new float[]{0.65F, 0.75F, 0.85F},
            [2] = new float[]{0.7F, 0.8F, 0.9F},
            [3] = new float[]{0.75F, 0.85F, 0.95F},
            [4] = new float[]{0.4F, 0.5F, 0.6F}
        };

        protected FiveThreeOneRoutineGenerator(NewFiveThreeOneRoutineDto newRoutineDto) : base(newRoutineDto)
        {
        }

        public TrainingCycle GenerateNewCycle(TrainingCycle previousCycle)
        {
            throw new NotImplementedException();
        }
        
        protected ExerciseSet GenerateExerciseSet(ExerciseSet exerciseSet, int trainingWeekNumber)
        {
            var baseExerciseSet = base.GenerateBaseExerciseSet(exerciseSet, trainingWeekNumber);
            if (baseExerciseSet.Exercise.ExerciseType.TypeCode == Domain.Enums.ExerciseTypeCodes.MainLiftWorkSet)
            {
                baseExerciseSet.Weight *= MainLiftLoadCoefficientMap[trainingWeekNumber][1];
            }
            return baseExerciseSet;
        }
    }
}