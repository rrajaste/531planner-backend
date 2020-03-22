using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TargetMuscleGroupRepository : BaseRepository<TargetMuscleGroup>, ITargetMuscleGroupRepository
    {
        public TargetMuscleGroupRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}