using App.DTO;
using Domain;

namespace Contracts.BLL.App
{
    public interface IFiveThreeOneRoutineGenerator : IBaseRoutineGenerator
    {
        public TrainingCycle GenerateNewCycle(TrainingCycle cycle);
    }
}