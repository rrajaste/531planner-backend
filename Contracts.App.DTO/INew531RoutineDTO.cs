using System.Collections;
using System.Collections.Generic;
using Domain;

namespace Contracts.App.DTO
{
    public interface INew531RoutineDTO : IBaseRoutineDTO
    {
        public IEnumerable<Exercise>? PullAccessories { get; set; }
        public IEnumerable<Exercise>? PushAccessories { get; set; }
        public IEnumerable<Exercise>? LegAccessories { get; set; }  
    }
}