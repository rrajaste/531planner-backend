using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.BLL.Base.Mappers;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF;
using Domain;

namespace BLL.Services
{
    public class BodyMeasurementService : BaseEntityService<IBodyMeasurementRepository, IAppUnitOfWork, BodyMeasurement, BodyMeasurement>, IBodyMeasurementService 
    {
        public BodyMeasurementService(AppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<BodyMeasurement, BodyMeasurement>(), unitOfWork.BodyMeasurements)
        {
        }
    }
}