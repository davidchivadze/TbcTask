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
        public IRepository<PhysicalPerson> PhysicalPerson { get;}
        public UnitOfWork(PersonDbContext personDbContext) { 
            _context = personDbContext;
            PhysicalPerson=new Repository<PhysicalPerson>(personDbContext);
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
