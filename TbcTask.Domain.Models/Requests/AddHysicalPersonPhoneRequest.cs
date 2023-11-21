using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Resources;

namespace TbcTask.Domain.Models.Requests
{
    public class AddHysicalPersonPhoneRequestItem
    {
        [Range(1, 3, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "PhoneTypeRange")]
        public int TypeID { get;set; }
        [Range(4, 50, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(ValidationMessages))]
        [RegularExpression("^[0-9]+$")]
        public string PhoneNumber { get;set; }
    }
}
