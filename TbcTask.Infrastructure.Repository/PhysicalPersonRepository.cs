using Microsoft.EntityFrameworkCore;
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
    public class PhysicalPersonRepository : BaseRepository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(PersonDbContext context) : base(context)
        {
        }


        public PhysicalPerson AddPhysicalPerson(PhysicalPerson physicalPerson)
        {
            var result = Add(physicalPerson);

            return result;
        }

        public PhysicalPerson EditPhysicalPerson(PhysicalPerson physicalPerson)
        {
            var result = _DbSet.Include(m => m.PhoneNumbers).Where(m => m.Id == physicalPerson.Id).FirstOrDefault();
            if (result != null)
            {
                result.GenderID = physicalPerson.GenderID == 0 ? result.GenderID : physicalPerson.GenderID;
                result.CityID = physicalPerson.CityID == 0 ? result.CityID : physicalPerson.CityID;
                result.FirstName = String.IsNullOrEmpty(physicalPerson.FirstName) ? result.FirstName : physicalPerson.FirstName;

                result.LastName = String.IsNullOrEmpty(physicalPerson.LastName) ? result.LastName : physicalPerson.LastName;
                result.PrivateNumber = String.IsNullOrEmpty(physicalPerson.PrivateNumber) ? result.PrivateNumber : physicalPerson.PrivateNumber;
                result.DateOfBirth = physicalPerson.DateOfBirth == default(DateTime) ? result.DateOfBirth : physicalPerson.DateOfBirth;
                Update(result);
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Data not Found");
            }
        }


        public PhysicalPerson GetPhysicalPersonFullData(int Id)
        {
            var result = _DbSet.
                 Where(m => m.Id == Id)
                 .Include(m => m.Gender)
                 .Include(m => m.City)
                 .Include(m => m.PhoneNumbers).ThenInclude(m => m.PhoneType).
                Include(m => m.ConnectedPersons).ThenInclude(m => m.PersonConnectionType)
                .Include(m => m.ConnectedPersons).ThenInclude(m => m.PhysicialPerson).ThenInclude(m => m.Gender)
                 .Include(m => m.ConnectedPersons).ThenInclude(m => m.PhysicialPerson).ThenInclude(m => m.City)
                  .Include(m => m.ConnectedPersons).ThenInclude(m => m.PhysicialPerson).ThenInclude(m => m.PhoneNumbers)
                   .Include(m => m.ConnectedPersons).ThenInclude(m => m.PhysicialPerson).ThenInclude(m => m.PhoneNumbers).ThenInclude(m=>m.PhoneType)
                .FirstOrDefault();
            return result;
        }

        public void UpdatePersonImageAddress(int Id, string address)
        {
            var person = _DbSet.Where(m => m.Id == Id).First();
            person.ImageAddress = address;
            Update(person);
            Save();
        }
    }
}
