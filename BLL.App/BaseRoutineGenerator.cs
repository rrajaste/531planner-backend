using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using App.DTO;
using Contracts.BLL.App;
using Domain;
using Extensions;

namespace BLL
{
    public class BaseRoutineGenerator<TNewRoutineDto>  : IBaseRoutineGenerator
    where TNewRoutineDto : BaseNewRoutineDto
    {

        protected readonly TNewRoutineDto _newRoutineDto;
        
        protected BaseRoutineGenerator(TNewRoutineDto newRoutineDto)
        {
            _newRoutineDto = newRoutineDto;
        }
        
        public virtual WorkoutRoutine GenerateNewRoutine()
        {
            return new WorkoutRoutine() {
                Name = _newRoutineDto.RoutineName ?? _newRoutineDto.BaseRoutine.Name,
                Description = _newRoutineDto.RoutineDescription ?? _newRoutineDto.BaseRoutine.Description,
                TrainingCycles = new Collection<TrainingCycle>(){GenerateNewTrainingCycle()}
            };
        }

        protected virtual TrainingCycle GenerateNewTrainingCycle()
        {
            return new TrainingCycle()
            {
                CycleNumber = 1,
                StartingDate = _newRoutineDto.StartingDate.Date,
                EndingDate = GetTrainingCycleEndDate(),
                TrainingWeeks = GenerateTrainingWeeks()

            };
        }

        protected virtual DateTime GetTrainingCycleEndDate()
        {
            var nrOfWeeksInBaseRoutineCycle =
                GetFirstTrainingCycleFromBaseRoutine(_newRoutineDto.BaseRoutine).TrainingWeeks.Count;

            return _newRoutineDto.StartingDate
                .AddDays(7 * nrOfWeeksInBaseRoutineCycle).Date;
        }

        protected virtual ICollection<TrainingWeek> GenerateTrainingWeeks()
        {
            var baseTrainingWeeks =
                GetFirstTrainingCycleFromBaseRoutine(_newRoutineDto.BaseRoutine).TrainingWeeks.ToList();
            var weekStartingDates = new DateTime[baseTrainingWeeks.Count];
            
            for (var i = 0; i < baseTrainingWeeks.Count; i++)
            {
                weekStartingDates[i] = _newRoutineDto.StartingDate.AddDays(i * 7);
            }

            var newTrainingWeeks = new Collection<TrainingWeek>();
            
            for (var i = 0; i < baseTrainingWeeks.Count; i++)
            {
                newTrainingWeeks.Add(GenerateTrainingWeek(baseTrainingWeeks[i], weekStartingDates[i]));
            }

            return newTrainingWeeks;
        }

        protected virtual TrainingCycle GetFirstTrainingCycleFromBaseRoutine(WorkoutRoutine baseRoutine)
        {
            return baseRoutine.TrainingCycles?.First();
        }

        protected virtual TrainingWeek GenerateTrainingWeek(TrainingWeek baseTrainingWeek, DateTime startingDate)
        {
            var baseDates = baseTrainingWeek.TrainingDays.Select(d => d.Date).ToArray();
            var newDates = startingDate.StartingFromGetDatesWithSameDayOfWeek(baseDates);
            return new TrainingWeek()
            {
                StartingDate = startingDate,
                EndingDate = startingDate.AddDays(7),
                TrainingDays = GenerateTrainingDays(baseTrainingWeek, newDates),
                IsDeload = baseTrainingWeek.IsDeload,
                
            };
        }

        protected virtual ICollection<TrainingDay> GenerateTrainingDays(TrainingWeek baseTrainingWeek, IReadOnlyList<DateTime> dates)
        {
            var generatedTrainingDays = new Collection<TrainingDay>();
            var baseTrainingDays = baseTrainingWeek.TrainingDays.ToList();
            for(var i = 0; i < baseTrainingWeek.TrainingDays.Count; i++)
            {
                generatedTrainingDays.Add(GenerateTrainingDay(baseTrainingDays[i], dates[i], baseTrainingWeek.WeekNumber));
            }
            return generatedTrainingDays;
        }

        protected virtual TrainingDay GenerateTrainingDay(TrainingDay baseTrainingDay, DateTime date, int trainingWeekNumber)
        {
            return new TrainingDay()
            {
                Date = date,
                ExerciseSets = GenerateBaseExerciseSets(baseTrainingDay, trainingWeekNumber)
            };
        }
        
        protected virtual ICollection<ExerciseSet> GenerateBaseExerciseSets(TrainingDay baseTrainingDay, int trainingWeekNumber)
        {
            return baseTrainingDay.ExerciseSets.Select(GenerateBaseExerciseSet).ToList();
        }

        protected virtual ExerciseSet GenerateBaseExerciseSet(ExerciseSet exerciseSet, int trainingWeekNumber)
        {
            return new ExerciseSet()
            {
                Completed = false,
                Distance = exerciseSet.Distance,
                Duration = exerciseSet.Duration,
                NrOfReps = exerciseSet.NrOfReps,
                SetNumber = exerciseSet.SetNumber,
                Weight = exerciseSet.Weight,
                UnitTypeId = exerciseSet.UnitTypeId,
                ExerciseId = exerciseSet.ExerciseId,
                Exercise = exerciseSet.Exercise,
                UnitType = exerciseSet.UnitType
            };
        }
    }
}