using TbcTask.Domain.Models.Database;

namespace TbcTask.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<PhysicalPerson> PhysicalPerson { get; }

        void Save();
    }


}