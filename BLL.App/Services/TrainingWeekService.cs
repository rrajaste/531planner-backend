using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class TrainingWeekService : BaseEntityService<ITrainingWeekRepository, IAppUnitOfWork, 
        DAL.App.DTO.TrainingWeek, BLL.App.DTO.TrainingWeek>, ITrainingWeekService 
    {
    public TrainingWeekService(IAppUnitOfWork unitOfWork) 
        : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.TrainingWeek, BLL.App.DTO.TrainingWeek>(), unitOfWork.TrainingWeeks)
    {
    }
    }
}