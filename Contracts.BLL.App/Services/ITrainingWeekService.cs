using System;
using Contracts.BLL.Base.Services;
using BLL.App.DTO;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface ITrainingWeekService : ITrainingWeekRepository<Guid, TrainingWeek>, IBaseEntityService<TrainingWeek>
    {
    }
}