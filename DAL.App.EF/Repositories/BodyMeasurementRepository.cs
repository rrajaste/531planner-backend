using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BodyMeasurementRepository : EFBaseRepository<AppDbContext, Domain.BodyMeasurement, DAL.App.DTO.BodyMeasurement>, IBodyMeasurementRepository
    {
        public BodyMeasurementRepository(AppDbContext repoDbContext, IDALMapper<Domain.BodyMeasurement, DAL.App.DTO.BodyMeasurement> mapper) 
            : base(repoDbContext, mapper)
        {
        }

        public async Task<IEnumerable<DAL.App.DTO.BodyMeasurement>> AllWithAppUserIdAsync(Guid id) => (
            await RepoDbSet
                .Include(b => b.UnitType)
                .Where(b => b.AppUserId.Equals(id))
                .ToListAsync()
            ).Select(domainEntity => Mapper.MapDomainToDAL(domainEntity));

        public async Task<DAL.App.DTO.BodyMeasurement> FindWithAppUserIdAsync(Guid id, Guid appUserId) => 
            Mapper.MapDomainToDAL(
                await RepoDbSet
                .Include(b => b.UnitType)
                .FirstOrDefaultAsync(d => d.Id == id && d.AppUserId == appUserId)
            );

        public override IEnumerable<DAL.App.DTO.BodyMeasurement> All() => 
            RepoDbSet
                .Include(b => b.UnitType)
                .ToList()
            .Select(domainEntity => Mapper.MapDomainToDAL(domainEntity));

        public override async Task<IEnumerable<DAL.App.DTO.BodyMeasurement>> AllAsync() => (
            await RepoDbSet
                .Include(b => b.UnitType)
                .ToListAsync()
            ).Select(domainEntity => Mapper.MapDomainToDAL(domainEntity));

        public override DAL.App.DTO.BodyMeasurement Find(Guid id) => 
            Mapper.MapDomainToDAL(
                RepoDbSet
                    .Include(b => b.UnitType)
                    .FirstOrDefault(d => d.Id == id)
            );


        public override async Task<DAL.App.DTO.BodyMeasurement> FindAsync(Guid id) =>
            Mapper.MapDomainToDAL(
                await RepoDbSet
                    .Include(b => b.UnitType)
                    .FirstOrDefaultAsync(d => d.Id == id)
            );
        
    }
}