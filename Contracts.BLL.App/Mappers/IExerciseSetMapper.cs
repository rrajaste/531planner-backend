using BLL.App.DTO;
using DALExerciseSet = DAL.App.DTO.ExerciseSet;

namespace Contracts.BLL.App.Mappers
{
    public interface IExerciseSetMapper : IBLLMapper<DALExerciseSet, ExerciseSet>
    {
        BaseLiftSet MapDALToBaseLiftSet(DALExerciseSet dalEntity);
        DALExerciseSet MapBaseLiftSetToDALEntity(BaseLiftSet baseLiftSet);
        UserLiftSet MapDALToUserLiftSet(DALExerciseSet dalEntity);
        DALExerciseSet MapUserLiftSetToDALEntity(UserLiftSet userLiftSet);
    }
}