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
    public class PhoneNumberRepository:BaseRepository<Phone>,IPhoneNumberRepository
    {
        public PhoneNumberRepository(PersonDbContext context) : base(context) { 
        
        
        }

        public void UpdatePhoneNumber(Phone phone)
        {
            var entity=_DbSet.Where(m=>m.Id == phone.Id).FirstOrDefault();
            if(entity != null)
            {
                entity.PhoneNumber = phone.PhoneNumber;
                entity.PhoneTypeID= phone.PhoneTypeID;
                entity.PhysicalPersonID = phone.PhysicalPersonID;
                Update(entity);
            }
            else
            {
                throw new KeyNotFoundException("Phone Number Not Found");
            }

        }
    }
}
