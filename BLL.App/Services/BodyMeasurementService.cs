using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App; 
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;
using Domain;

namespace BLL.Services
{
    public class BodyMeasurementService : BaseEntityService<IBodyMeasurementRepository, IAppUnitOfWork, BodyMeasurement, BodyMeasurement>, IBodyMeasurementService 
    {
        public BodyMeasurementService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<BodyMeasurement, BodyMeasurement>(), unitOfWork.BodyMeasurements)
        {
        }
    }
}