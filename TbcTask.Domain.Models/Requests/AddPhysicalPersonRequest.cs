﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;

namespace TbcTask.Domain.Models.Requests
{
    public class AddPhysicalPersonRequest
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int GenderID { get; set; }
        public string PrivateNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityID { get; set; }
        public ICollection<AddHysicalPersonPhoneRequestItem> PhoneNumbers { get; set; }
    }
}
