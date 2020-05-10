using BLL.App.DTO;
using DALExerciseSet = global::DAL.App.DTO.ExerciseSet;
namespace Contracts.BLL.App.Mappers
{
    public interface IExerciseSetMapper : IBLLMapper<DALExerciseSet, ExerciseSet>
    {
        public BaseLiftSet MapDALToBaseLiftSet(DALExerciseSet dalEntity);
        public DALExerciseSet MapBaseLiftSetToDALEntity(BaseLiftSet baseLiftSet);
        public UserLiftSet MapDALToUserLiftSet(DALExerciseSet dalEntity);
        public DALExerciseSet MapUserLiftSetToDALEntity(UserLiftSet userLiftSet);
    }
}