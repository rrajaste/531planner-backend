using BLL.App.DTO;
using DALTrainingDay = global::DAL.App.DTO.TrainingDay;
namespace Contracts.BLL.App.Mappers
{
    public interface ITrainingDayMapper : IBLLMapper<DALTrainingDay, TrainingDay>
    {
        BaseTrainingDay MapDALToBaseTrainingDay(DALTrainingDay dalEntity);
        DALTrainingDay MapBaseTrainingDayToDALEntity(BaseTrainingDay baseTrainingDay);
    }
}