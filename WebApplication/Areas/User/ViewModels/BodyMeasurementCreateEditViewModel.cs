using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.ViewModels
{
    public class BodyMeasurementCreateEditViewModel
    {
        public BodyMeasurement BodyMeasurement { get; set; }
        public SelectList? UnitTypeSelectList { get; set; }
    }
}