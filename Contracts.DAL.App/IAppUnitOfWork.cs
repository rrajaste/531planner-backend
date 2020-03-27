using Contracts.DAL.Base;
using Domain;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IBodyMeasurementRepository BodyMeasurements { get; }
        IUnitsTypeRepository UnitTypes { get; }
    }
}