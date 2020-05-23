using System;
using System.Linq;

namespace PublicApi.DTO.V1.Mappers
{
    public class ExerciseMapper
    {
        public static Exercise MapBLLEntityToPublicDTO(BLL.App.DTO.ExerciseInTrainingDay bllEntity)
        {
            if (bllEntity.Exercise == null)
            {
                throw new ArgumentException("Mapping failed: Exercise on BLL entity was null!");
            }
            if (bllEntity.ExerciseType == null)
            {
                throw new ArgumentException("Mapping failed: ExerciseType on BLL entity was null!");
            }
            
            return new Exercise()
            {
                Name = bllEntity.Exercise.Name,
                Description = bllEntity.Exercise.Description,
                ExerciseType = ExerciseTypeMapper.MapBLLEntityToPublicDTO(bllEntity.ExerciseType),
                WarmUpSets = bllEntity.WarmUpSets.Select(ExerciseSetMapper.MapBLLEntityToPublicDTO),
                WorkSets = bllEntity.WorkSets.Select(ExerciseSetMapper.MapBLLEntityToPublicDTO)
            };
        }
    }
}