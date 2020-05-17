using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class TrainingWeekService : BaseEntityService<ITrainingWeekRepository, IAppUnitOfWork,
        DAL.App.DTO.TrainingWeek, BLL.App.DTO.TrainingWeek, IBLLMapper<DAL.App.DTO.TrainingWeek, BLL.App.DTO.TrainingWeek>>,
        ITrainingWeekService
    {
        public TrainingWeekService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.TrainingWeek, TrainingWeek> mapper)
            : base(unitOfWork, mapper, unitOfWork.TrainingWeeks)
        {
        }

        public async Task<IEnumerable<TrainingWeek>> AllWithBaseRoutineIdAsync(Guid baseRoutineId) =>
            (await ServiceRepository.AllWithBaseRoutineIdAsync(baseRoutineId)).Select(Mapper.MapDALToBLL);

        public async Task<bool> IsPartOfBaseRoutineAsync(Guid id) => 
            await ServiceRepository.IsPartOfBaseRoutineAsync(id);

        public async Task<TrainingWeek> FindAsync(Guid id, bool includeTrainingDays = false) =>
            Mapper.MapDALToBLL(await ServiceRepository.FindAsync(id, includeTrainingDays));

        public async Task<TrainingWeek> AddNewWeekToBaseRoutineWithIdAsync(Guid routineId, bool isDeload)
        {
            var parentCycle = await UnitOfWork.TrainingCycles.FindWithBaseRoutineIdAsync(routineId);
            var trainingWeeks = 
                (await UnitOfWork.TrainingWeeks.AllWithBaseRoutineIdAsync(routineId)).ToList();
            
            var weekNumber = 1;
            if (trainingWeeks.Count != 0)
            {
                weekNumber += trainingWeeks.Max(w => w.WeekNumber);
            }
            var trainingWeek = new TrainingWeek()
            {
                TrainingCycleId = parentCycle.Id,
                WeekNumber = weekNumber,
                IsDeload = isDeload
            };
            ServiceRepository.Add(Mapper.MapBLLToDAL(trainingWeek));
            return trainingWeek;
        }

        public async Task NormalizeWeekNumbersAsync(Guid routineId)
        {
            var trainingWeeks = await GetTrainingWeeksFromRoutineWithIdAsync(routineId);
            for (var i = 1; i <= trainingWeeks.Count(); i++)
            {
                var trainingWeek = trainingWeeks[i - 1];
                trainingWeek.WeekNumber = i;
                ServiceRepository.Update(trainingWeek);
            }
        }
        
        public async Task<TrainingWeek> DecrementWeekNumberAsync(Guid trainingWeekId)
        {
            var parentRoutine = (await UnitOfWork.WorkoutRoutines.FindWithWeekIdAsync(trainingWeekId));
            var trainingWeeks = await GetTrainingWeeksFromRoutineWithIdAsync(parentRoutine.Id);
            var weekToDecrement = trainingWeeks.FirstOrDefault(w => w.Id == trainingWeekId);
            if (weekToDecrement.WeekNumber > 1)
            {
                var weekToIncrement = trainingWeeks
                    .FirstOrDefault(w => w.WeekNumber == weekToDecrement.WeekNumber - 1);
                weekToDecrement.WeekNumber--;
                weekToIncrement.WeekNumber++;
                ServiceRepository.Update(weekToDecrement);
                ServiceRepository.Update(weekToIncrement);
            }
            return Mapper.MapDALToBLL(weekToDecrement);
        }

        public async Task<TrainingWeek> IncrementWeekNumberAsync(Guid trainingWeekId)
        {
            var parentRoutine = (await UnitOfWork.WorkoutRoutines.FindWithWeekIdAsync(trainingWeekId));
            var trainingWeeks = await GetTrainingWeeksFromRoutineWithIdAsync(parentRoutine.Id);
            var weekToIncrement = trainingWeeks.FirstOrDefault(w => w.Id == trainingWeekId);
            var maxWeekNumber = trainingWeeks.Max(w => w.WeekNumber);
            if (weekToIncrement.WeekNumber < maxWeekNumber)
            {
                var weekToDecrement = trainingWeeks
                    .FirstOrDefault(w => w.WeekNumber == weekToIncrement.WeekNumber + 1);
                weekToDecrement.WeekNumber--;
                weekToIncrement.WeekNumber++;
                ServiceRepository.Update(weekToDecrement);
                ServiceRepository.Update(weekToIncrement);
            }
            return Mapper.MapDALToBLL(weekToIncrement);
        }

        private async Task<DAL.App.DTO.TrainingWeek[]> GetTrainingWeeksFromRoutineWithIdAsync(Guid routineId)
        {
            return (await ServiceRepository.AllWithBaseRoutineIdAsync(routineId))
                .OrderBy(w => w.WeekNumber)
                .ToArray();
        }
    }
}