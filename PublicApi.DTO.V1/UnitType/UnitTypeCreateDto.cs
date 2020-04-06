using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1.UnitType
{
    public class UnitTypeCreateDto
    {
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}