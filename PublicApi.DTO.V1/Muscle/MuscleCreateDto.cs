using PublicApi.DTO.V1.BaseDTOs.BaseDictionaryTypeDto;

namespace PublicApi.DTO.V1.Muscle
{
    public class MuscleCreateDto : BaseCreateDto
    {
        public string MuscleGroupId { get; set; }
    }
}