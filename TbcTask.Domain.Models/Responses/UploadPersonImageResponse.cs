using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Responses
{
    public class UploadPersonImageResponse
    {
        public int PhysicalPersonID { get; set; }
        public string ImageAddress { get; set; }
    }
}
