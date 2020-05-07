using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RoutineTypeRepository : EFBaseRepository<AppDbContext, RoutineType, DTO.RoutineType>,
        IRoutineTypeRepository
    {
        public RoutineTypeRepository(AppDbContext dbContext, IDALMapper<RoutineType, DTO.RoutineType> mapper)
            : base(dbContext, mapper)
        {

        }
        public override async Task<IEnumerable<DTO.RoutineType>> AllAsync()
        {
            var items = await RepoDbSet.Where(entity => entity.ParentTypeId == null)
                .Include(entity => entity.SubTypes)
                .ToListAsync();
            return items.Select(Mapper.MapDomainToDAL);
        }
    }
}