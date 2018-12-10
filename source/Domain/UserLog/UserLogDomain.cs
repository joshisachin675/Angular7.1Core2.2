using DotNetCore.Mapping;
using IDCardScanning.Database;
using IDCardScanning.Model.Entities;
using IDCardScanning.Model.Models;

namespace IDCardScanning.Domain
{
    public sealed class UserLogDomain : IUserLogDomain
    {
        public UserLogDomain(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserLogRepository userLogRepository)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            UserLogRepository = userLogRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IUserLogRepository UserLogRepository { get; }

        public void Save(UserLogModel userLogModel)
        {
            var userLogEntity = userLogModel.Map<UserLogEntity>();
            UserLogRepository.Add(userLogEntity);
            DatabaseUnitOfWork.SaveChanges();
        }
    }
}
