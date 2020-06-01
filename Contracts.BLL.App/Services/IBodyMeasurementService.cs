using System;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IBodyMeasurementService : IBaseEntityService<BodyMeasurement>,
        IBodyMeasurementRepository<Guid, BodyMeasurement>
    {
        Task<BodyMeasurementStatistics> GetUserStatisticsAsync(Guid userId);
    }
}