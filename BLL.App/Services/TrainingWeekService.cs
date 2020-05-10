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

        public async Task<TrainingWeek> AddNewWeekToBaseRoutineWithIdAsync(Guid routineId)
        {
            var parentCycle = await UnitOfWork.TrainingCycles.FindWithBaseRoutineIdAsync(routineId);
            var trainingWeeks = 
                (await UnitOfWork.TrainingWeeks.AllWithBaseRoutineIdAsync(routineId)).ToList();
            var weekNumber = 1;
            if (trainingWeeks.Count != 0)
            {
                weekNumber = weekNumber + trainingWeeks.Max(w => w.WeekNumber);
            }
            var trainingWeek = new TrainingWeek()
            {
                TrainingCycleId = parentCycle.Id,
                WeekNumber = weekNumber
            };
            ServiceRepository.Add(Mapper.MapBLLToDAL(trainingWeek));
            return trainingWeek;
        }
    }
}