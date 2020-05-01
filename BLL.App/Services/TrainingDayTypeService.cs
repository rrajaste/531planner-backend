using BLL.Base.Mappers;
using BLL.Base.Services;

using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;


namespace BLL.Services
{
    public class TrainingDayTypeService : BaseEntityService<ITrainingDayTypeRepository, IAppUnitOfWork,
        DAL.App.DTO.TrainingDayType, BLL.App.DTO.TrainingDayType>, ITrainingDayTypeService
    {
        public TrainingDayTypeService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.TrainingDayType, BLL.App.DTO.TrainingDayType>(), unitOfWork.TrainingDayTypes)
        {
        }
    }
}