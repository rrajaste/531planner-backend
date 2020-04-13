using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.V1.BaseDTOs.BaseDictionaryTypeDto;

namespace DAL.App.EF.Repositories
{
    public class DailyNutritionIntakeRepository : EFBaseRepository<DailyNutritionIntake, AppDbContext>,
        IDailyNutritionIntakeRepository
    {
        public DailyNutritionIntakeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }

        public override IEnumerable<DailyNutritionIntake> All()
        {
            return RepoDbSet.Include(d => d.UnitType).ToList();
        }

        public override async Task<IEnumerable<DailyNutritionIntake>> AllAsync()
        {
            return await RepoDbSet.Include(d => d.UnitType).ToListAsync();
        }

        public override DailyNutritionIntake Find(Guid? id)
        {
            return RepoDbSet
                .Include(d => d.UnitType)
                .SingleOrDefault(d => d.Id == id);
        }

        public override async Task<DailyNutritionIntake> FindAsync(Guid? id)
        {
            return await RepoDbSet
                .Include(d => d.UnitType)
                .SingleOrDefaultAsync(d => d.Id == id);
        }
        
        public async Task<DailyNutritionIntake> FindWithAppUserIdAsync(Guid? id, Guid appUserId)
        {
            return RepoDbSet
                .Include(d => d.UnitType)
                .SingleOrDefault(d => d.Id == id && d.AppUserId == appUserId);
        }

        public async Task<IEnumerable<DailyNutritionIntake>> AllWithAppUserIdAsync(Guid id)
        {
            return await RepoDbSet.Include(d => d.UnitType)
                .Where(b => b.AppUserId == id).ToListAsync();
        }
    }
}