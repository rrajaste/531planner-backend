using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class BodyMeasurementService :
        BaseEntityService<IBodyMeasurementRepository, IAppUnitOfWork, DAL.App.DTO.BodyMeasurement,
            BLL.App.DTO.BodyMeasurement>, IBodyMeasurementService 
    {
        public BodyMeasurementService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.BodyMeasurement,
                BLL.App.DTO.BodyMeasurement>(), unitOfWork.BodyMeasurements)
        {
        }
    }
}