﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Responses
{
    public class RemoveConnectedPersonsResponse
    {
        public bool Success { get; set; }
        public int ConnectedPersonID { get; set; }
        public int PhysicalPersonID { get; set; }
    }
}
