using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BodyMeasurementRepository : EFBaseRepository<BodyMeasurement, AppDbContext>, IBodyMeasurementRepository
    {
        public BodyMeasurementRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }

        public async Task<IEnumerable<BodyMeasurement>> AllWithAppUserIdAsync(object id)
        {
            return await RepoDbSet.Where(b => b.AppUserId.Equals(id)).ToListAsync();
        }

        public override IEnumerable<BodyMeasurement> All()
        {
            return RepoDbContext.BodyMeasurements
                .Include(b => b.UnitsType)
                .ToList();
        }

        public override async Task<IEnumerable<BodyMeasurement>> AllAsync()
        {
            return await RepoDbSet
                .Include(b => b.UnitsType)
                .ToListAsync();
        }

        public override BodyMeasurement Find(params object[] id)
        {
            return base.Find(id);
        }

        public override Task<BodyMeasurement> FindAsync(params object[] id)
        {
            return base.FindAsync(id);
        }
    }
}