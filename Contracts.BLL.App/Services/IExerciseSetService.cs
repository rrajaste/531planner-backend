using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IExerciseSetService : IBaseEntityService<ExerciseSet>, 
        IExerciseSetRepository<Guid, ExerciseSet>
    {
        Task<BaseLiftSet> Add(BaseLiftSet baseSet);
        Task<BaseLiftSet> UpdateAsync(BaseLiftSet baseLiftSet);
        Task<BaseLiftSet> RemoveAsync(BaseLiftSet baseLiftSet);
        Task<BaseLiftSet> FindBaseLiftSetAsync(Guid setId);
        Task<IEnumerable<BaseLiftSet>> AllBaseLiftSetsWithTrainingDayIdAsync(Guid id);
    }
}