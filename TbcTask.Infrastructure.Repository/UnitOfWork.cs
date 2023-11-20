using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Repository;
using TbcTask.Infrastructure.Store;

namespace TbcTask.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonDbContext _context;
        private IDbContextTransaction _transaction;


        private IPhysicalPersonRepository _physicalPersonRepository;
        private IPhoneNumberRepository _phoneNumberRepository;
        private IConnectedPersonRepository _connectedPersonRepository;

        public UnitOfWork(PersonDbContext context) { 
            _context =context ;
        }

        public IPhysicalPersonRepository physicalPersonRepository
        {
            get { return _physicalPersonRepository =_physicalPersonRepository??new PhysicalPersonRepository(_context); }
        }
        public IPhoneNumberRepository phoneNumberRepository
        {
            get { return _phoneNumberRepository = _phoneNumberRepository ?? new PhoneNumberRepository(_context); }
        }
        public IConnectedPersonRepository connectedPersonRepository
        {
            get { return _connectedPersonRepository = _connectedPersonRepository ?? new ConnectedPersonRepository(_context); }
        }
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }
        

        public void CommitTransaction()
        {
            _transaction?.Commit();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
        }

        public void Save()
        {

           _context.SaveChanges();
        }
    }
}
