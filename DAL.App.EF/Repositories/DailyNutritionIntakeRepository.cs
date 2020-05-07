using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using DailyNutritionIntake = Domain.App.DailyNutritionIntake;

namespace DAL.App.EF.Repositories
{
    public class DailyNutritionIntakeRepository :
        EFBaseRepository<AppDbContext, DailyNutritionIntake, DTO.DailyNutritionIntake>,
        IDailyNutritionIntakeRepository
    {
        public DailyNutritionIntakeRepository(AppDbContext repoDbContext, IDALMapper<DailyNutritionIntake, DTO.DailyNutritionIntake> mapper) 
            : base(repoDbContext, mapper)
        {
        }
        public override async Task<IEnumerable<DTO.DailyNutritionIntake>> AllAsync() => (
            await RepoDbSet
                .AsNoTracking()
                .Include(d => d.UnitType)
                .ToListAsync()
            ).Select(domainEntity => Mapper.MapDomainToDAL(domainEntity));

        public override async Task<DTO.DailyNutritionIntake> FindAsync(Guid id) =>
            Mapper.MapDomainToDAL(await RepoDbSet
                .AsNoTracking()
                .Include(d => d.UnitType)
                .SingleOrDefaultAsync(d => d.Id == id));

        public async Task<DTO.DailyNutritionIntake> FindWithAppUserIdAsync(Guid id, Guid appUserId) =>
            Mapper.MapDomainToDAL(await RepoDbSet
                .AsNoTracking()
                .Include(d => d.UnitType)
                .SingleOrDefaultAsync(d => d.Id == id && d.AppUserId == appUserId));
        
        public async Task<IEnumerable<DTO.DailyNutritionIntake>> AllWithAppUserIdAsync(Guid id) => (
            await RepoDbSet
                .Include(d => d.UnitType)
                .Where(b => b.AppUserId == id)
                .ToListAsync())
            .Select(domainEntity => Mapper.MapDomainToDAL(domainEntity)
        );
    }
}