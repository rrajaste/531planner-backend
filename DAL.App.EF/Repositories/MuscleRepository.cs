using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MuscleRepository : EFBaseRepository<AppDbContext, Domain.Muscle, DAL.App.DTO.Muscle>, IMuscleRepository
    {
        public MuscleRepository(AppDbContext repoDbContext, IDALMapper<Domain.Muscle, DAL.App.DTO.Muscle> mapper) 
            : base(repoDbContext, mapper)
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Muscle>> AllAsync() => (
            await RepoDbSet
                .Include(m => m.MuscleGroup)
                .ToListAsync())
            .Select(domainEntity => Mapper.MapDomainToDAL(domainEntity)
        );

        public override async Task<DAL.App.DTO.Muscle> FindAsync(Guid id) => 
            Mapper.MapDomainToDAL(
                await RepoDbSet
                .Include(m => m.MuscleGroup)
                .SingleOrDefaultAsync(m => m.Id == id)
            );
    }
}