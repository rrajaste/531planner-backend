using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingCycleRepository :
        EFBaseRepository<AppDbContext, Domain.TrainingCycle, DAL.App.DTO.TrainingCycle>,
        ITrainingCycleRepository
    {
        public TrainingCycleRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}