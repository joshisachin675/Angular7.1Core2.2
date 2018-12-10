using IDCardScanning.Model.Models;

namespace IDCardScanning.Domain
{
    public interface IUserLogDomain
    {
        void Save(UserLogModel userLogModel);
    }
}
