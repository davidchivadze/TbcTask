using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Responses
{
    public class PhysicalPersonConnectionReportResponse
    {
        public int PhysicalPersonID { get; set; }
        public string ConnectionType { get; set; }
        public int CountOfConnections { get; set; }
    }
}
