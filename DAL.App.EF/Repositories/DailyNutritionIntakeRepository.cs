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
    public class DailyNutritionIntakeRepository :
        EFBaseRepository<AppDbContext, DailyNutritionIntake, DTO.DailyNutritionIntake>,
        IDailyNutritionIntakeRepository
    {
        public DailyNutritionIntakeRepository(AppDbContext repoDbContext,
            IDALMapper<DailyNutritionIntake, DTO.DailyNutritionIntake> mapper)
            : base(repoDbContext, mapper)
        {
        }

        public override async Task<IEnumerable<DTO.DailyNutritionIntake>> AllAsync()
        {
            return (
                await RepoDbSet
                    .AsNoTracking()
                    .ToListAsync()
            ).Select(domainEntity => Mapper.MapDomainToDAL(domainEntity));
        }

        public override async Task<DTO.DailyNutritionIntake> FindAsync(Guid id)
        {
            return Mapper.MapDomainToDAL(await RepoDbSet
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.Id == id));
        }

        public async Task<DTO.DailyNutritionIntake> FindWithAppUserIdAsync(Guid id, Guid appUserId)
        {
            return Mapper.MapDomainToDAL(await RepoDbSet
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.Id == id && d.AppUserId == appUserId));
        }

        public async Task<IEnumerable<DTO.DailyNutritionIntake>> AllWithAppUserIdAsync(Guid id)
        {
            return (
                    await RepoDbSet
                        .Where(b => b.AppUserId == id)
                        .ToListAsync())
                .Select(domainEntity => Mapper.MapDomainToDAL(domainEntity)
                );
        }
    }
}