using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayRepository : EFBaseRepository<TrainingDay, AppDbContext>, ITrainingDayRepository
    {
        public TrainingDayRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }

        public Task<TrainingDay> FindAsyncAuthorize(Guid? trainingWeekId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TrainingDay>> AllWithTrainingWeekIdAsyncAuthorize(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}