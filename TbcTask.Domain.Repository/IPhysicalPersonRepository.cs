﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Models.Database.Reports;

namespace TbcTask.Domain.Repository
{
    public interface IPhysicalPersonRepository:IBaseRepository<PhysicalPerson>
    {
        PhysicalPerson AddPhysicalPerson(PhysicalPerson physicalPerson);
        PhysicalPerson GetPhysicalPersonFullData(int Id);
        PhysicalPerson EditPhysicalPerson(PhysicalPerson physicalPerson);
        void UpdatePersonImageAddress(int Id, string address);
        List<PhysicalPerson> SearchPhysicalPersonData(string key,int skip,int take);
        PhysicalPersonConnectionReport PhysicalPersonConnectionReport();
    }
}
