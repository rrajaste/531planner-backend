using BLL.App.DTO;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;


namespace BLL.Services
{
    public class TrainingDayTypeService : BaseEntityService<ITrainingDayTypeRepository, IAppUnitOfWork,
        DAL.App.DTO.TrainingDayType, BLL.App.DTO.TrainingDayType, 
        IBLLMapper<DAL.App.DTO.TrainingDayType, BLL.App.DTO.TrainingDayType>>, ITrainingDayTypeService
    {
        public TrainingDayTypeService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.TrainingDayType, TrainingDayType> mapper) 
            : base(unitOfWork, mapper, unitOfWork.TrainingDayTypes)
        {
        }
    }
}