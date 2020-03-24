using Contracts.DAL.App;
using DAL.App.EF.Repositories;
using DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public IBodyMeasurementsRepository BodyMeasurements => 
            GetRepository<IBodyMeasurementsRepository>(()=> new BodyMeasurementsRepository(UnitOfWorkDbContext));
        public IUnitsTypeRepository UnitsTypes => 
            GetRepository<IUnitsTypeRepository>(()=> new UnitsTypeRepository(UnitOfWorkDbContext));

        public AppUnitOfWork(AppDbContext unitOfWorkDbContext) : base(unitOfWorkDbContext)
        {
        }
    }
}