using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.V1.BaseDTOs.BaseDictionaryTypeDto;

namespace DAL.App.EF.Repositories
{
    public class DailyNutritionIntakeRepository :
        EFBaseRepository<AppDbContext, Domain.DailyNutritionIntake, DAL.App.DTO.DailyNutritionIntake>,
        IDailyNutritionIntakeRepository
    {
        public DailyNutritionIntakeRepository(AppDbContext repoDbContext) : base(repoDbContext, new BaseDALMapper<DailyNutritionIntake, DTO.DailyNutritionIntake>())
        {
        }

        public override IEnumerable<DAL.App.DTO.DailyNutritionIntake> All() => 
            RepoDbSet
                .Include(d => d.UnitType)
                .ToList()
            .Select(domainEntity => Mapper.Map(domainEntity));


        public override async Task<IEnumerable<DAL.App.DTO.DailyNutritionIntake>> AllAsync() => (
            await RepoDbSet
                .Include(d => d.UnitType)
                .ToListAsync()
            ).Select(domainEntity => Mapper.Map(domainEntity));

        public override DAL.App.DTO.DailyNutritionIntake Find(Guid id) =>
            Mapper.Map(RepoDbSet
                .Include(d => d.UnitType)
                .SingleOrDefault(d => d.Id == id));

        public override async Task<DAL.App.DTO.DailyNutritionIntake> FindAsync(Guid id) =>
            Mapper.Map(await RepoDbSet
                .Include(d => d.UnitType)
                .SingleOrDefaultAsync(d => d.Id == id));

        public async Task<DAL.App.DTO.DailyNutritionIntake> FindWithAppUserIdAsync(Guid id, Guid appUserId) =>
            Mapper.Map(await RepoDbSet
                .Include(d => d.UnitType)
                .SingleOrDefaultAsync(d => d.Id == id && d.AppUserId == appUserId));

        public async Task<IEnumerable<DAL.App.DTO.DailyNutritionIntake>> AllWithAppUserIdAsync(Guid id) => (
            await RepoDbSet
                .Include(d => d.UnitType)
                .Where(b => b.AppUserId == id)
                .ToListAsync())
            .Select(domainEntity => Mapper.Map(domainEntity)
        );
    }
}