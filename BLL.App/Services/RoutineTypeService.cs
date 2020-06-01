using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;

namespace BLL.Services
{
    public class RoutineTypeService : BaseEntityService<IRoutineTypeRepository, IAppUnitOfWork,
            RoutineType, App.DTO.RoutineType, IBLLMapper<RoutineType, App.DTO.RoutineType>>,
        IRoutineTypeService
    {
        protected IEnumerable<App.DTO.RoutineType>? TypeCache;

        public RoutineTypeService(IAppUnitOfWork unitOfWork, IBLLMapper<RoutineType, App.DTO.RoutineType> mapper)
            : base(unitOfWork, mapper, unitOfWork.RoutineTypes)
        {
        }

        public override async Task<IEnumerable<App.DTO.RoutineType>> AllAsync()
        {
            TypeCache = await base.AllAsync();
            ;
            return TypeCache;
        }

        public async Task<IEnumerable<App.DTO.RoutineType>> GetTypeTreeLeafsAsync()
        {
            TypeCache ??= await AllAsync();
            var collector = new List<App.DTO.RoutineType>();
            foreach (var type in TypeCache) CollectTypeTreeChildren(type, collector, t => t.SubTypes == null);
            return collector;
        }

        protected static void CollectTypeTreeChildren(App.DTO.RoutineType node, List<App.DTO.RoutineType> collector,
            Func<App.DTO.RoutineType, bool> collectionPredicate)
        {
            if (collectionPredicate(node))
                collector.Add(node);
            else if (node.SubTypes != null)
                foreach (var subType in node.SubTypes)
                    CollectTypeTreeChildren(subType, collector, collectionPredicate);
        }
    }
}