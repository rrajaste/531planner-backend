using System;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using BLL.App.DTO;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface ITrainingWeekService : ITrainingWeekRepository<Guid, TrainingWeek>, IBaseEntityService<TrainingWeek>
    {
        Task<TrainingWeek> AddNewWeekToBaseRoutineWithIdAsync(Guid routineId);
        Task AdjustWeekNumbersAsync(Guid routineId);
    }
}