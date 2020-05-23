using System;

namespace PublicApi.DTO.V1.Mappers
{
    public class ExerciseSetMapper
    {
        public static ExerciseSet MapBLLEntityToPublicDTO(BLL.App.DTO.ExerciseSet bllEntity)
        {
            if (bllEntity.NrOfReps == null)
            {
                throw new ArgumentException("Mapping failed: NrOfReps on BLL entity was null!");
            }
            
            if (bllEntity.UnitType == null)
            {
                throw new ArgumentException("Mapping failed: UnitType on BLL entity was null!");
            }
            
            if (bllEntity.SetType == null)
            {
                throw new ArgumentException("Mapping failed: SetType on BLL entity was null!");
            }
            
            return new ExerciseSet()
            {
                Id = bllEntity.Id,
                NrOfReps = (int) bllEntity.NrOfReps,
                UnitType = bllEntity.UnitType.Name,
                SetType = SetTypeMapper.MapBLLEntityToPublicDTO(bllEntity.SetType)
            };
        }
    }
}