using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;
using Domain;

namespace BLL.Services
{
    public class TrainingDayService : BaseEntityService<ITrainingDayRepository, IAppUnitOfWork,
        DAL.App.DTO.TrainingDay, BLL.App.DTO.TrainingDay>, ITrainingDayService 
    {
        public TrainingDayService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.TrainingDay, BLL.App.DTO.TrainingDay>(), unitOfWork.TrainingDays)
        {
        }
    }
}