using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<BodyMeasurements>> AllWithAppUserIdAsync(object id)
        {
            return await RepoDbSet.Where(b => b.AppUserId.Equals(id)).ToListAsync();
        }
    }
}