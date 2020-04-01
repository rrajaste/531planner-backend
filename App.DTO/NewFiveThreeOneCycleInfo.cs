using System;
using System.Collections.Generic;
using Domain;
using Domain.Enums;

namespace App.DTO
{
    public class NewFiveThreeOneCycleInfo
    {
        public int NumberOfDaysPerWeek { get; set; }
        public ICollection<Exercise>? PullDayAccessories { get; set; }
        public ICollection<Exercise>? PushDayAccessories { get; set; }
        public ICollection<Exercise>? SquatDayAccessories { get; set; }
        public ICollection<Exercise>? DeadliftDayAccessories { get; set; }
        public FiveThreeOneWendlerMaxesDto WendlerMaxes { get; set; }
        public bool AddDeloadWeek { get; set; }
        public DownSetTypes DownSetType { get; set; }
        public MainLiftsProgramming MainLiftsProgramming { get; set; }
    }
}