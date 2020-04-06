using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingCycleRepository : IBaseRepository<TrainingCycle>
    {
        Task<IEnumerable<TrainingCycle>> AllWithRoutineIdAuthorizeAsync(Guid routineId, Guid userId);
        Task<TrainingCycle> FindAuthorizeAsync(Guid? id, Guid userId);
    }
}