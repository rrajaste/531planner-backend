using PublicApi.DTO.V1.BaseDTOs.BaseDictionaryTypeDto;
using PublicApi.DTO.V1.MuscleGroups;

namespace PublicApi.DTO.V1.Muscle
{
    public class MuscleDto : BaseDto
    {
        public MuscleGroupDto MuscleGroup { get; set; }
    }
}