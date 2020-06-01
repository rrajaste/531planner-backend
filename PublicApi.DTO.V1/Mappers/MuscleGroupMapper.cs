using System.Linq;

namespace PublicApi.DTO.V1.Mappers
{
    public static class MuscleGroupMapper
    {
        public static MuscleGroup MapBLLEntityToPublicDTO(BLL.App.DTO.MuscleGroup bllEntity)
        {
            return new MuscleGroup
            {
                Id = bllEntity.Id.ToString(),
                Name = bllEntity.Name,
                Description = bllEntity.Description,
                Muscles = bllEntity.Muscles.Select(MuscleMapper.MapBLLEntityToPublicDTO)
            };
        }
    }
}