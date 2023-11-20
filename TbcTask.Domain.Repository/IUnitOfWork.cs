﻿using TbcTask.Domain.Models.Database;

namespace TbcTask.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPhysicalPersonRepository physicalPersonRepository { get; }
        IPhoneNumberRepository phoneNumberRepository { get; }
        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }


}