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
    }
}