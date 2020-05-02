using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class RoutineTypeService : BaseEntityService<IRoutineTypeRepository, IAppUnitOfWork,
        DAL.App.DTO.RoutineType, BLL.App.DTO.RoutineType>, IRoutineTypeService 
    {
        
        protected IEnumerable<RoutineType> TypeCache = new List<RoutineType>();
        
        public RoutineTypeService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.RoutineType, BLL.App.DTO.RoutineType>(), unitOfWork.RoutineTypes)
        {
        }
        
        public override async Task<IEnumerable<RoutineType>> AllAsync()
        {
            TypeCache = await base.AllAsync();;
            return TypeCache;
        }
        
        public async Task<IEnumerable<RoutineType>> GetTypeTreeLeafsAsync()
        {
            if (!TypeCache.Any())
            {
                TypeCache = await AllAsync();
            }
            var collector = new List<RoutineType>();
            foreach (var type in TypeCache)
            {
                CollectTypeTreeChildren(type, collector, t => !t.SubTypes.Any());
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