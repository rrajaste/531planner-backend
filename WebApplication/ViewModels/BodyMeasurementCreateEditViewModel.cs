using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.ViewModels
{
    public class BodyMeasurementCreateEditViewModel
    {
        public BodyMeasurements BodyMeasurements { get; set; }
        public SelectList? UnitTypeSelectList { get; set; }
    }
}