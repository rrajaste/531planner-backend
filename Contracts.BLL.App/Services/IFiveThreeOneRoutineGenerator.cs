using Domain;
using Domain.App;

namespace Contracts.BLL.App.Services
{
    public interface IFiveThreeOneRoutineGenerator : IBaseRoutineGenerator
    {
        TrainingCycle GenerateNewCycle(TrainingCycle cycle);
    }
}