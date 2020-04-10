using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
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

        public async Task<IEnumerable<BodyMeasurement>> AllWithAppUserIdAsync(Guid id)
        {
            return await RepoDbSet
                .Include(b => b.UnitType)
                .Where(b => b.AppUserId.Equals(id)).ToListAsync();
        }

        public async Task<BodyMeasurement> FindWithAppUserIdAsync(Guid id, Guid appUserId)
        {
            return await RepoDbSet
                .Include(b => b.UnitType)
                .FirstOrDefaultAsync(d => d.Id == id && d.AppUserId == appUserId);
        }

        public override IEnumerable<BodyMeasurement> All()
        {
            return RepoDbContext.BodyMeasurements
                .Include(b => b.UnitType)
                .ToList();
        }

        public override async Task<IEnumerable<BodyMeasurement>> AllAsync()
        {
            return await RepoDbSet
                .Include(b => b.UnitType)
                .ToListAsync();
        }

        public override BodyMeasurement Find(Guid? id)
        {
            return RepoDbSet
                .Include(b => b.UnitType)
                .FirstOrDefault(d => d.Id == id);
        }

        public override async Task<BodyMeasurement> FindAsync(Guid? id)
        {
            return await RepoDbSet
                .Include(b => b.UnitType)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}