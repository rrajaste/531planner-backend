using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class TrainingCycleService : BaseEntityService<ITrainingCycleRepository, IAppUnitOfWork,
        DAL.App.DTO.TrainingCycle, BLL.App.DTO.TrainingCycle>, ITrainingCycleService 
    {
        public TrainingCycleService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.TrainingCycle, BLL.App.DTO.TrainingCycle>(), unitOfWork.TrainingCycles)
        {
        }

        public async Task<IEnumerable<TrainingCycle>> AllWithRoutineIdForUserWithIdAsync(Guid id, Guid? userId) => (
                await UnitOfWork.TrainingCycles.AllWithRoutineIdForUserWithIdAsync(id, userId)
            ).Select(Mapper.Map<DAL.App.DTO.TrainingCycle, BLL.App.DTO.TrainingCycle>);

        public async Task<IEnumerable<TrainingCycle>> AllWithBaseRoutineIdAsync(Guid id) => (
            await UnitOfWork.TrainingCycles.AllWithBaseRoutineIdAsync(id)
        ).Select(Mapper.Map<DAL.App.DTO.TrainingCycle, BLL.App.DTO.TrainingCycle>);

        public async Task<TrainingCycle> FindWithRoutineIdForUserWithIdAsync(Guid id, Guid? userId) =>
            Mapper.Map<DAL.App.DTO.TrainingCycle, BLL.App.DTO.TrainingCycle>(
                await UnitOfWork.TrainingCycles.FindWithRoutineIdForUserWithIdAsync(id, userId)
                );

        public async Task<TrainingCycle> FindWithBaseRoutineIdAsync(Guid id) =>
            Mapper.Map<DAL.App.DTO.TrainingCycle, BLL.App.DTO.TrainingCycle>(
                await UnitOfWork.TrainingCycles.FindWithBaseRoutineIdAsync(id)
            );
    }
}