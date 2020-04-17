using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MuscleRepository : EFBaseRepository<AppDbContext, Domain.Muscle, DAL.App.DTO.Muscle>, IMuscleRepository
    {
        public MuscleRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Muscle>> AllAsync() => (
            await RepoDbSet
                .Include(m => m.MuscleGroup)
                .ToListAsync())
            .Select(domainEntity => Mapper.Map(domainEntity)
        );

        public override async Task<DAL.App.DTO.Muscle> FindAsync(Guid id) => 
            Mapper.Map(
                await RepoDbSet
                .Include(m => m.MuscleGroup)
                .SingleOrDefaultAsync(m => m.Id == id)
            );
    }
}