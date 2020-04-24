using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;
using Domain;

namespace BLL.Services
{
    public class PersonalRecordService : BaseEntityService<IPersonalRecordRepository, IAppUnitOfWork, 
        DAL.App.DTO.PersonalRecord, BLL.App.DTO.PersonalRecord>, IPersonalRecordService 
    {
        public PersonalRecordService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.PersonalRecord, BLL.App.DTO.PersonalRecord>(),
                unitOfWork.PersonalRecords)
        {
        }
    }
}