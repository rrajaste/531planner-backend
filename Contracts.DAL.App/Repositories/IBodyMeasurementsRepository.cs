using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App
{
    public interface IBodyMeasurementsRepository : IBaseRepository<BodyMeasurements>
    {
        Task<IEnumerable<BodyMeasurements>> AllWithAppUserIdAsync (object id);
    }
}