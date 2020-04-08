using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MuscleRepository : EFBaseRepository<Muscle, AppDbContext>, IMuscleRepository
    {
        public MuscleRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }

        public override async Task<IEnumerable<Muscle>> AllAsync()
        {
            return await RepoDbSet.Include(m => m.MuscleGroup).ToListAsync();
        }

        public override async Task<Muscle> FindAsync(Guid? id)
        {
            return await RepoDbSet.Include(m => m.MuscleGroup).SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}