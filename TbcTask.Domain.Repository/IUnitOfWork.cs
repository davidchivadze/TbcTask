using TbcTask.Domain.Models.Database;

namespace TbcTask.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPhysicalPersonRepository physicalPersonRepository { get; }
        IPhoneNumberRepository phoneNumberRepository { get; }
        IConnectedPersonRepository connectedPersonRepository { get; }
        void Save();
        IDisposable BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }


}