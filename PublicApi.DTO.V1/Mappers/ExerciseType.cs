namespace PublicApi.DTO.V1.Mappers
{
    public class ExerciseTypeMapper
    {
        public static ExerciseType MapBLLEntityToPublicDTO(BLL.App.DTO.ExerciseType bllEntity)
        {
            return new ExerciseType()
            {
                Name = bllEntity.Name,
                Description = bllEntity.Description
            };
        }
    }
}
