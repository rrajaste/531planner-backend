using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class RoutineTypeService : BaseEntityService<IRoutineTypeRepository, IAppUnitOfWork,
        DAL.App.DTO.RoutineType, BLL.App.DTO.RoutineType>, IRoutineTypeService 
    {
        
        protected IEnumerable<RoutineType>? TypeCache;
        
        public RoutineTypeService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.RoutineType, RoutineType> mapper) 
            : base(unitOfWork, mapper, unitOfWork.RoutineTypes)
        {
        }
        
        public override async Task<IEnumerable<RoutineType>> AllAsync()
        {
            TypeCache = await base.AllAsync();;
            return TypeCache;
        }
        
        public async Task<IEnumerable<RoutineType>> GetTypeTreeLeafsAsync()
        {
            TypeCache ??= await AllAsync();
            var collector = new List<RoutineType>();
            foreach (var type in TypeCache)
            {
                CollectTypeTreeChildren(type, collector, t => t.SubTypes == null);
            }
            return collector;
        }

        protected static void CollectTypeTreeChildren(RoutineType node, List<RoutineType> collector, Func<RoutineType, bool> collectionPredicate)
        {
            if (collectionPredicate(node))
            {
                collector.Add(node);
            }
            else if (node.SubTypes != null)
            {
                foreach (var subType in node.SubTypes)
                {
                    CollectTypeTreeChildren(subType, collector, collectionPredicate);
                }   
            }
        }
    }
}