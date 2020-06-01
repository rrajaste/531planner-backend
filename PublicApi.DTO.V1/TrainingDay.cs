using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1
{
    public class TrainingDay
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        [DataType(DataType.Date)] public DateTime Date { get; set; }

        public IEnumerable<Exercise> MainLifts { get; set; } = default!;
        public IEnumerable<Exercise> AccessoryLifts { get; set; } = default!;
    }
}