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
    public class PersonalRecordService : BaseEntityService<IPersonalRecordRepository, IAppUnitOfWork, PersonalRecord, PersonalRecord>, IPersonalRecordService 
    {
        public PersonalRecordService(AppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<PersonalRecord, PersonalRecord>(), unitOfWork.PersonalRecords)
        {
        }
    }
}