﻿using Microsoft.EntityFrameworkCore;
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
    public class ConnectedPersonRepository : BaseRepository<ConnectedPersons>,IConnectedPersonRepository
    {
        public ConnectedPersonRepository(PersonDbContext personDbContext) : base(personDbContext)
        {
        }

        public void AddConnectedPeople(ConnectedPersons connectedPersons)
        {
            _DbSet.Add(new ConnectedPersons()
            {
                ConnectedPersonId = connectedPersons.ConnectedPersonId,
                PhysicialPersonId = connectedPersons.PhysicialPersonId,
                PersonConnectionTypeID = connectedPersons.PersonConnectionTypeID,
            });
            _DbSet.Add(new ConnectedPersons()
            {
                ConnectedPersonId = connectedPersons.PhysicialPersonId,
                PhysicialPersonId = connectedPersons.ConnectedPersonId,
                PersonConnectionTypeID=connectedPersons.PersonConnectionTypeID,
            });
          
        }

        public List<ConnectedPersons> GetConnectedPersons(int id)
        {
            var result=_DbSet.Include(m=>m.ConnectedPerson)
                .Include(m => m.ConnectedPerson).Include(m=>m.ConnectedPerson.City).Include(m=>m.ConnectedPerson.Gender).Include(m=>m.ConnectedPerson)
                .Include(m => m.ConnectedPerson).ThenInclude(m => m.PhoneNumbers)
                .Include(m=>m.PhysicialPerson)
                .Include(m => m.PhysicialPerson).Include(m => m.PhysicialPerson.City).Include(m => m.PhysicialPerson.Gender).Include(m => m.PhysicialPerson)
                .Include(m => m.PhysicialPerson).ThenInclude(m => m.PhoneNumbers)
                .Where(m=>m.ConnectedPersonId == id||m.PhysicialPersonId==id)              
                .ToList();
            return result;
        }
    }
}
