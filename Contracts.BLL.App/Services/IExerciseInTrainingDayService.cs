using System;
using Contracts.BLL.Base.Services;
using BLL.App.DTO;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IExerciseInTrainingDayService : IExerciseInTrainingDayRepository<Guid, ExerciseInTrainingDay>,
        IBaseEntityService<ExerciseInTrainingDay>
    {
        
    }
}