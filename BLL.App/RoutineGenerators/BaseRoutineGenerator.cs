using System;
using System.Collections.Generic;
using System.Linq;
using BLL.App.DTO;
using Contracts.BLL.App.RoutineGenerators;
using Extensions;

namespace BLL.RoutineGenerators
{
    public abstract class BaseRoutineGenerator<TNewRoutineInfo>  : IBaseRoutineGenerator
        where TNewRoutineInfo : BaseNewRoutineInfo
    {

        protected readonly TNewRoutineInfo NewRoutineInfo;
        protected Guid NewRoutineId;
        
        protected BaseRoutineGenerator(TNewRoutineInfo newRoutineInfo)
        {
            NewRoutineInfo = newRoutineInfo;
            NewRoutineId = Guid.NewGuid();
            // CheckBaseRoutine();
            // CheckStartingDate();
        }
        
        public virtual WorkoutRoutine GenerateNewRoutine()
        {
            var routine = new WorkoutRoutine() {
                Id = NewRoutineId,
                RoutineTypeId = NewRoutineInfo.BaseRoutine.RoutineTypeId,
                Name = NewRoutineInfo.BaseRoutine.Name,
                Description = NewRoutineInfo.BaseRoutine.Description,
            };
            routine.TrainingCycles = new List<TrainingCycle>() {GenerateNewTrainingCycle(routine.Id)};
            return routine;
        }

        protected virtual TrainingCycle GenerateNewTrainingCycle(Guid parentId, int cycleNumber = 1)
        {
            var trainingCycle =  new TrainingCycle()
            {
                Id = Guid.NewGuid(),
                WorkoutRoutineId = parentId,
                CycleNumber = cycleNumber,
                StartingDate = NewRoutineInfo.StartingDate.StartOfWeek(DayOfWeek.Monday).AddDays(7),
            };
            var generatedTrainingWeeks = GenerateTrainingWeeks(trainingCycle.Id, trainingCycle.StartingDate).ToList();
            trainingCycle.TrainingWeeks = generatedTrainingWeeks;
            trainingCycle.EndingDate = trainingCycle.StartingDate.AddDays((generatedTrainingWeeks.Count * 7) - 1);
            return trainingCycle;
        }
        
        protected virtual TrainingCycle GetFirstTrainingCycleFromBaseRoutine(WorkoutRoutine baseRoutine)
        {
            if (baseRoutine.TrainingCycles.IsEmptyOrNull())
            {
                throw new ApplicationException(
                    "Routine generation failed: base routine provided in NewRoutineInfo has no cycles!"
                );
            }
            return baseRoutine.TrainingCycles!.First();
        }

        protected virtual IEnumerable<TrainingWeek> GenerateTrainingWeeks(Guid parentId, DateTime startingDate)
        {
            var baseTrainingWeeks =
                GetFirstTrainingCycleFromBaseRoutine(NewRoutineInfo.BaseRoutine).TrainingWeeks.ToArray();
            
            if (baseTrainingWeeks.IsEmptyOrNull())
            {
                throw new ApplicationException(
                    "Routine generation failed: base routine provided in NewRoutineInfo has no training weeks!"
                );
            }
            
            var nrOfTrainingWeeks = baseTrainingWeeks.Length;
            var weekStartingDates = new DateTime[nrOfTrainingWeeks];
            
            for (var i = 0; i < nrOfTrainingWeeks; i++)
            {
                weekStartingDates[i] = startingDate.AddDays(i * 7);
            }
            var newTrainingWeeks = new List<TrainingWeek>();
            
            for (var i = 0; i < nrOfTrainingWeeks; i++)
            {
                var generatedTrainingWeek = GenerateTrainingWeek(baseTrainingWeeks[i], weekStartingDates[i]);
                generatedTrainingWeek.TrainingCycleId = parentId;
                newTrainingWeeks.Add(generatedTrainingWeek);
            }

            return newTrainingWeeks;
        }

        protected virtual TrainingWeek GenerateTrainingWeek(TrainingWeek baseTrainingWeek, DateTime startingDate)
        {
            var baseDates = baseTrainingWeek.TrainingDays.Select(d => d.Date)
                .OrderBy(d => d.Date)
                .ToArray();
            
            var newDates = startingDate.StartingFromGetDatesWithSameDayOfWeek(baseDates);
            var generatedTrainingWeek = new TrainingWeek()
            {
                Id = Guid.NewGuid(),
                StartingDate = startingDate,
                EndingDate = startingDate.AddDays(6),
                IsDeload = baseTrainingWeek.IsDeload,
                WeekNumber = baseTrainingWeek.WeekNumber
            };
            generatedTrainingWeek.TrainingDays =
                GenerateTrainingDays(baseTrainingWeek, newDates, generatedTrainingWeek.Id);
            return generatedTrainingWeek;
        }
        
        protected virtual IEnumerable<UserTrainingDay> GenerateTrainingDays(TrainingWeek baseTrainingWeek, IReadOnlyList<DateTime> dates, Guid parentId)
        {
            var generatedTrainingDays = new List<UserTrainingDay>();
            var baseTrainingDays = baseTrainingWeek.TrainingDays.ToArray();
            for(var i = 0; i < baseTrainingWeek.TrainingDays.Count(); i++)
            {
                var generatedTrainingDay =
                    GenerateTrainingDay(baseTrainingDays[i], dates[i], baseTrainingWeek.WeekNumber);
                generatedTrainingDay.TrainingWeekId = parentId;
                generatedTrainingDays.Add(generatedTrainingDay);
            }
            return generatedTrainingDays;
        }

        protected virtual UserTrainingDay GenerateTrainingDay(UserTrainingDay baseTrainingDay, DateTime date, int trainingWeekNumber)
        {
            var trainingDay = new UserTrainingDay()
            {
                Id = Guid.NewGuid(),
                Date = date,
                TrainingDayTypeId = baseTrainingDay.TrainingDayTypeId,
            };
            if (baseTrainingDay.AccessoryLifts == null)
            {
                throw new ApplicationException(
                    $"Routine generation failed: base TrainingDay with ID ${baseTrainingDay.Id} accessory lifts are null.");
            }
            if (baseTrainingDay.MainLifts == null)
            {
                throw new ApplicationException(
                    $"Routine generation failed: base TrainingDay with ID ${baseTrainingDay.Id} main lifts are null.");
            }
            trainingDay.AccessoryLifts = GenerateExercises(baseTrainingDay.AccessoryLifts, trainingWeekNumber, trainingDay.Id);
            trainingDay.MainLifts = GenerateExercises(baseTrainingDay.MainLifts, trainingWeekNumber, trainingDay.Id);
            return trainingDay;
        }
        
        protected virtual IEnumerable<ExerciseInTrainingDay> GenerateExercises(IEnumerable<ExerciseInTrainingDay> baseExercises,
            int trainingWeekNumber, Guid parentId)
        {
            return baseExercises.Select(exercise => GenerateExercise(exercise, trainingWeekNumber, parentId));
        }

        protected abstract ExerciseInTrainingDay GenerateExercise(ExerciseInTrainingDay baseExercise, int trainingWeekNumber, Guid parentId);
        
        public void CheckBaseRoutine()
        {
            var baseRoutine = NewRoutineInfo.BaseRoutine;
            if (!baseRoutine.IsBaseRoutine)
            {
                throw new ApplicationException(
                    "Routine generation failed: base routine provided in NewRoutineInfo was not a base routine!"
                );
            }

            if (!baseRoutine.IsPublished)
            {
                throw new ApplicationException(
                    "Routine generation failed: base routine provided in NewRoutineInfo is not published!"
                );
            }
        }

        public void CheckStartingDate()
        {
            var startingDate = NewRoutineInfo.StartingDate.Date;
            if (startingDate < DateTime.Now.AddDays(-1))
            {
                throw new ApplicationException(
                    $"Routine generation failed: provided starting date {startingDate} was more than 24H ago!"
                );
            }

            if (startingDate > DateTime.Now.AddDays(14))
            {
                throw new ApplicationException(
                    $"Routine generation failed: provided starting date {startingDate} is more than 14 days in the future!"
                );
            }
        }
    }
}