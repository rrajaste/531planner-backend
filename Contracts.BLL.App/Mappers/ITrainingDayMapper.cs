using BLL.App.DTO;
using DALTrainingDay = global::DAL.App.DTO.TrainingDay;
namespace Contracts.BLL.App.Mappers
{
    public interface ITrainingDayMapper : IBLLMapper<DALTrainingDay, TrainingDay>
    {
        public BaseTrainingDay MapDALToBaseTrainingDay(DALTrainingDay dalEntity);
        public DALTrainingDay MapBaseTrainingDayToDALEntity(BaseTrainingDay baseTrainingDay);
    }
}