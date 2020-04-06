using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1.UnitType
{
    public class UnitTypeDto
    {
        public string Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

        public string CreatedAt { get; set; }
    }
}