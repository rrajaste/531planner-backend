using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class TrainingCycleService : BaseEntityService<ITrainingCycleRepository, IAppUnitOfWork,
            TrainingCycle, App.DTO.TrainingCycle, IBLLMapper<TrainingCycle, App.DTO.TrainingCycle>>,
        ITrainingCycleService
    {
        public TrainingCycleService(IAppUnitOfWork unitOfWork, IBLLMapper<TrainingCycle, App.DTO.TrainingCycle> mapper)
            : base(unitOfWork, mapper, unitOfWork.TrainingCycles)
        {
        }

        public async Task<IEnumerable<App.DTO.TrainingCycle>> AllWithRoutineIdForUserWithIdAsync(Guid id, Guid? userId)
        {
            return (
                await UnitOfWork.TrainingCycles.AllWithRoutineIdForUserWithIdAsync(id, userId)
            ).Select(Mapper.MapDALToBLL);
        }

        public async Task<App.DTO.TrainingCycle> FindWithRoutineIdForUserWithIdAsync(Guid id, Guid userId)
        {
            return Mapper.MapDALToBLL(
                await UnitOfWork.TrainingCycles.FindWithRoutineIdForUserWithIdAsync(id, userId)
            );
        }

        public async Task<App.DTO.TrainingCycle> FindWithBaseRoutineIdAsync(Guid id)
        {
            return Mapper.MapDALToBLL(
                await UnitOfWork.TrainingCycles.FindWithBaseRoutineIdAsync(id)
            );
        }

        public Task<bool> IsPartOfBaseRoutineAsync(Guid cycleId)
        {
            return ServiceRepository.IsPartOfBaseRoutineAsync(cycleId);
        }

        public async Task<App.DTO.TrainingCycle> GetFullActiveCycleForUserWithIdAsync(Guid userId)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.GetFullActiveCycleForUserWithIdAsync(userId));
        }

        public App.DTO.TrainingCycle GenerateBaseCycle(Guid workoutRoutineId)
        {
            return new App.DTO.TrainingCycle
            {
                CycleNumber = 1,
                StartingDate = DateTime.Now,
                WorkoutRoutineId = workoutRoutineId
            };
        }
    }
}