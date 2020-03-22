using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BodyMeasurementsRepository : BaseRepository<BodyMeasurements>, IBodyMeasurementsRepository
    {
        public BodyMeasurementsRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}