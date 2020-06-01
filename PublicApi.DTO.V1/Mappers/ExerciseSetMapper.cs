using System;
using Domain.App.Enums;

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

            if (bllEntity.SetType == null)
            {
                throw new ArgumentException("Mapping failed: SetType on BLL entity was null!");
            }
            
            return new ExerciseSet()
            {
                Id = bllEntity.Id,
                NrOfReps = (int) bllEntity.NrOfReps,
                Weight = bllEntity.Weight < 0.1 ? null : bllEntity.Weight,
                TypeName = bllEntity.SetType.Name,
                TypeDescription = bllEntity.SetType.Description
            };
        }
    }
}