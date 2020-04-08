using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;
using PublicApi.DTO.V1;

namespace Contracts.DAL.App.Repositories
{
    public interface IBodyMeasurementRepository : IBaseRepository<BodyMeasurement>
    {
        Task<IEnumerable<BodyMeasurement>> AllWithAppUserIdAsync (object id);
        Task<BodyMeasurement> FindWithAppUserIdAsync(Guid id, Guid appUserId);
    }
}