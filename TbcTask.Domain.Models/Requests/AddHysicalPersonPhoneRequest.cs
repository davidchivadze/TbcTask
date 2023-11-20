using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Requests
{
    public class AddHysicalPersonPhoneRequestItem
    {
        public int TypeID { get;set; }
        public string PhoneNumber { get;set; }
    }
}
