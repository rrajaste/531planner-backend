using System;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using BLL.App.DTO;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface ITrainingDayService : ITrainingDayRepository<Guid, TrainingDay>, IBaseEntityService<TrainingDay>
    {
        BaseTrainingDay Add(BaseTrainingDay dto);
        Task<BaseTrainingDay> FindBaseTrainingDay(Guid id);
        
    }
}