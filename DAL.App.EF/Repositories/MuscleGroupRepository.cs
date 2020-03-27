using Contracts.DAL.App;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MuscleGroupRepository : EFBaseRepository<MuscleGroup, AppDbContext>, IMuscleGroupRepository
    {
        public MuscleGroupRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}