using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class BodyMeasurementService :
        BaseEntityService<IBodyMeasurementRepository, IAppUnitOfWork, DAL.App.DTO.BodyMeasurement,
            BLL.App.DTO.BodyMeasurement>, IBodyMeasurementService
    {
        public BodyMeasurementService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.BodyMeasurement, BodyMeasurement> mapper) 
            : base(unitOfWork, mapper, unitOfWork.BodyMeasurements)
        {
        }

        public async Task<IEnumerable<BodyMeasurement>> AllWithAppUserIdAsync(Guid id) => (
                await UnitOfWork.BodyMeasurements.AllWithAppUserIdAsync(id)
            ).Select(Mapper.MapDALToBLL);

        public async Task<BodyMeasurement> FindWithAppUserIdAsync(Guid id, Guid appUserId) =>
            Mapper.MapDALToBLL(
                await UnitOfWork.BodyMeasurements.FindWithAppUserIdAsync(id, appUserId));
    }
}