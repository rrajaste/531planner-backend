using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IBodyMeasurementRepository : IBaseRepository<BodyMeasurement>
    {
        Task<IEnumerable<BodyMeasurement>> AllWithAppUserIdAsync (object id);
    }
}