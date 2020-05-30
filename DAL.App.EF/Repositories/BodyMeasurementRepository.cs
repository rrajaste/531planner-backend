using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BodyMeasurementRepository : EFBaseRepository<AppDbContext, BodyMeasurement, DAL.App.DTO.BodyMeasurement>, IBodyMeasurementRepository
    {
        public BodyMeasurementRepository(AppDbContext repoDbContext, IDALMapper<BodyMeasurement, DAL.App.DTO.BodyMeasurement> mapper) 
            : base(repoDbContext, mapper)
        {
        }

        public async Task<IEnumerable<DAL.App.DTO.BodyMeasurement>> AllWithAppUserIdAsync(Guid id)
        {
            var items = await RepoDbSet
                .Where(b => b.AppUserId.Equals(id))
                .ToListAsync();
            var mappedItems = items.Select(Mapper.MapDomainToDAL);
            return mappedItems;
        }

        public async Task<DAL.App.DTO.BodyMeasurement> FindWithAppUserIdAsync(Guid id, Guid appUserId) => 
            Mapper.MapDomainToDAL(
                await RepoDbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(d => d.Id == id && d.AppUserId == appUserId)
            );

        public async Task<DTO.BodyMeasurement> FirstForUserWithIdAsync(Guid userId)
        {
            var measurements = await RepoDbSet
                .Where(measurement => measurement.AppUserId == userId)
                .ToListAsync();
            var first = measurements.OrderBy(measurement => measurement.LoggedAt).FirstOrDefault();
            return Mapper.MapDomainToDAL(first);
        }
        
        public async Task<DTO.BodyMeasurement> LatestForUserWithIdAsync(Guid userId)
        {
            var measurements = await RepoDbSet
                .Where(measurement => measurement.AppUserId == userId)
                .ToListAsync();
            var last = measurements.OrderBy(measurement => measurement.LoggedAt).LastOrDefault();
            return Mapper.MapDomainToDAL(last);
        }

        public override async Task<IEnumerable<DAL.App.DTO.BodyMeasurement>> AllAsync() => (
            await RepoDbSet
                .ToListAsync()
            ).Select(domainEntity => Mapper.MapDomainToDAL(domainEntity));

        public override async Task<DAL.App.DTO.BodyMeasurement> FindAsync(Guid id) =>
            Mapper.MapDomainToDAL(
                await RepoDbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(d => d.Id == id)
            );
    }
}