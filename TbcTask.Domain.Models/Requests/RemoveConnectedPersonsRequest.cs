using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Requests
{
    public class RemoveConnectedPersonsRequest
    {
        public int? ConnectedPersonID { get; set; }
        public int? PhysicalPersonID { get; set; }
        public int? ConnectionTypeID { get; set; }
    }
}
