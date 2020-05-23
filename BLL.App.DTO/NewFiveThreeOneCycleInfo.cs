using System.Collections.Generic;
using App.DTO;
using Domain.App.Enums;

namespace BLL.App.DTO
{
    public class NewFiveThreeOneCycleInfo
    {
        public FiveThreeOneWendlerMaxesDto WendlerMaxes { get; set; }
        public bool AddDeloadWeek { get; set; }
        public DownSetTypes DownSetType { get; set; }
    }
}