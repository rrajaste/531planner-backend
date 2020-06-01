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
    public class MuscleRepository : EFBaseRepository<AppDbContext, Muscle, DTO.Muscle>, IMuscleRepository
    {
        public MuscleRepository(AppDbContext repoDbContext, IDALMapper<Muscle, DTO.Muscle> mapper)
            : base(repoDbContext, mapper)
        {
        }

        public override async Task<IEnumerable<DTO.Muscle>> AllAsync()
        {
            return (
                    await RepoDbSet
                        .Include(m => m.MuscleGroup)
                        .ToListAsync())
                .Select(domainEntity => Mapper.MapDomainToDAL(domainEntity)
                );
        }

        public override async Task<DTO.Muscle> FindAsync(Guid id)
        {
            return Mapper.MapDomainToDAL(
                await RepoDbSet
                    .Include(m => m.MuscleGroup)
                    .SingleOrDefaultAsync(m => m.Id == id)
            );
        }
    }
}