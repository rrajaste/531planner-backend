using Contracts.DAL.App;
using DAL.App.EF.Repositories;
using DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public IBodyMeasurementRepository BodyMeasurements => 
            GetRepository<IBodyMeasurementRepository>(()=> new BodyMeasurementRepository(UnitOfWorkDbContext));
        public IUnitsTypeRepository UnitTypes => 
            GetRepository<IUnitsTypeRepository>(()=> new UnitsTypeRepository(UnitOfWorkDbContext));

        public AppUnitOfWork(AppDbContext unitOfWorkDbContext) : base(unitOfWorkDbContext)
        {
        }
    }
}