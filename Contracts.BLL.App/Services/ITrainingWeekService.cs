using System;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface ITrainingWeekService : ITrainingWeekRepository<Guid, TrainingWeek>,
        IBaseEntityService<TrainingWeek>
    {
        Task<TrainingWeek> AddNewWeekToBaseRoutineWithIdAsync(Guid routineId, bool isDeload);
        Task NormalizeWeekNumbersAsync(Guid routineId);
        Task<TrainingWeek> DecrementWeekNumberAsync(Guid trainingWeekId);
        Task<TrainingWeek> IncrementWeekNumberAsync(Guid trainingWeekId);
    }
}