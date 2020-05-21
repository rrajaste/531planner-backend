using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using BLL.App.DTO;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface ITrainingDayService : ITrainingDayRepository<Guid, BaseTrainingDay>, IBaseEntityService<BaseTrainingDay>
    {
        UserTrainingDay Add(UserTrainingDay dto);
        UserTrainingDay Update(UserTrainingDay dto);
        Task<IEnumerable<DayOfWeek>> GetUnusedDaysInWeekWithIdAsync(Guid trainingWeekId);
    }
}