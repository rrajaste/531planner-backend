using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingDayRepository : IBaseRepository<TrainingDay>
    {
        Task<TrainingDay> FindAsyncAuthorize(Guid? trainingWeekId, Guid userId);
        Task<ICollection<TrainingDay>> AllWithTrainingWeekIdAsyncAuthorize(Guid id, Guid userId);
    }
}