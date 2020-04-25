using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
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

        public async Task<IEnumerable<BodyMeasurement>> AllWithAppUserIdAsync(Guid id) => (
                await UnitOfWork.BodyMeasurements.AllWithAppUserIdAsync(id)
            ).Select(Mapper.Map<DAL.App.DTO.BodyMeasurement, BodyMeasurement>);

        public async Task<BodyMeasurement> FindWithAppUserIdAsync(Guid id, Guid appUserId) =>
            Mapper.Map<DAL.App.DTO.BodyMeasurement, BodyMeasurement>(
                await UnitOfWork.BodyMeasurements.FindWithAppUserIdAsync(id, appUserId));
    }
}