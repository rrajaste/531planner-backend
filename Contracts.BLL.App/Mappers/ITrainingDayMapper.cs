using BLL.App.DTO;
using DALTrainingDay = DAL.App.DTO.TrainingDay;

namespace Contracts.BLL.App.Mappers
{
    public interface ITrainingDayMapper : IBLLMapper<DALTrainingDay, BaseTrainingDay>
    {
        UserTrainingDay MapDALToUserTrainingDay(DALTrainingDay dalEntity);
        DALTrainingDay MapUserTrainingDayToDALEntity(UserTrainingDay userTrainingDay);
    }
}