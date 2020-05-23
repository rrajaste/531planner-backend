namespace PublicApi.DTO.V1.Mappers
{
    public static class TrainingDayTypeMapper
    {
        public static TrainingDayType MapBLLEntityToPublicDTO(BLL.App.DTO.TrainingDayType bllEntity)
        {
            return new TrainingDayType()
            {
                Name = bllEntity.Name,
                Description = bllEntity.Description
            };
        }
    }
}