using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain;

namespace BLL.Services
{
    public class TrainingWeekService : BaseEntityService<ITrainingWeekRepository, IAppUnitOfWork, TrainingWeek, TrainingWeek>, ITrainingWeekService 
    {
    public TrainingWeekService(AppUnitOfWork unitOfWork) 
        : base(unitOfWork, new BaseBLLMapper<TrainingWeek, TrainingWeek>(), unitOfWork.TrainingWeeks)
    {
    }
    }
}