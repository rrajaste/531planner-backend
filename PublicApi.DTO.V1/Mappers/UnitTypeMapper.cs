namespace PublicApi.DTO.V1.Mappers
{
    public static class UnitTypeMapper
    {
        public static UnitType MapBLLEntityToPublicDTO(BLL.App.DTO.UnitType bllEntity)
        {
            return new UnitType()
            {
                Id = bllEntity.Id.ToString(),
                Name = bllEntity.Name,
                Description = bllEntity.Description
            };
        }
    }
}