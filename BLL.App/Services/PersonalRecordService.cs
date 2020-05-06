using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using BLL.App.DTO;

namespace BLL.Services
{
    public class PersonalRecordService : BaseEntityService<IPersonalRecordRepository, IAppUnitOfWork, 
        DAL.App.DTO.PersonalRecord, BLL.App.DTO.PersonalRecord>, IPersonalRecordService 
    {
        public PersonalRecordService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.PersonalRecord, PersonalRecord> mapper) 
            : base(unitOfWork, mapper, unitOfWork.PersonalRecords)
        {
        }
    }
}