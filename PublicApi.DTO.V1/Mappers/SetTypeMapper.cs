namespace PublicApi.DTO.V1.Mappers
{
    public class SetTypeMapper
    {
        public static SetType MapBLLEntityToPublicDTO(BLL.App.DTO.SetType bllEntity)
        {
            return new SetType()
            {
                Name = bllEntity.Name,
                Description = bllEntity.Description
            };
        }
    }
}