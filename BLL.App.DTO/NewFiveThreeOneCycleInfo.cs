using System;
using System.Collections.Generic;
using Domain.App.Enums;

namespace BLL.App.DTO
{
    public class NewFiveThreeOneCycleInfo
    {
        public float SquatMax { get; set; }
        public float DeadliftMax { get; set; }
        public float BenchPressMax { get; set; }
        public float OverHeadPressMax { get; set; }
        public bool AddDeloadWeek { get; set; }
        public Guid UnitTypeId { get; set; }
    }
}