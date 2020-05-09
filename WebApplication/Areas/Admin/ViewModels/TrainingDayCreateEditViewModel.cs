using System;
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class TrainingDayCreateEditViewModel
    {
        public TrainingDay TrainingDay { get; set; }
        public SelectList? TrainingDayTypes { get; set; }
    }
}