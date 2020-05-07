namespace PublicApi.DTO.V1.Mappers
{
    public static class MuscleMapper
    {
        public static Muscle MapBLLEntityToPublicDTO(BLL.App.DTO.Muscle bllEntity)
        {
            return new Muscle()
            {
                Id = bllEntity.Id.ToString(),
                MuscleGroupId = bllEntity.MuscleGroupId.ToString(),
                Name = bllEntity.Name,
                Description = bllEntity.Description
            };
        }
    }
}
