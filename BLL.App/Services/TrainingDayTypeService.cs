using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class TrainingDayTypeService : BaseEntityService<ITrainingDayTypeRepository, IAppUnitOfWork,
        TrainingDayType, App.DTO.TrainingDayType,
        IBLLMapper<TrainingDayType, App.DTO.TrainingDayType>>, ITrainingDayTypeService
    {
        public TrainingDayTypeService(IAppUnitOfWork unitOfWork,
            IBLLMapper<TrainingDayType, App.DTO.TrainingDayType> mapper)
            : base(unitOfWork, mapper, unitOfWork.TrainingDayTypes)
        {
        }
    }
}