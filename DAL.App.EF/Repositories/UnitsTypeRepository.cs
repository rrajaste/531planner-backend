using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.V1;

namespace DAL.App.EF.Repositories
{
    public class UnitTypesRepository : EFBaseRepository<UnitType, AppDbContext>, IUnitTypesRepository
    {
        public UnitTypesRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}