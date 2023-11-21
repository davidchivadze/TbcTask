using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Resources;
using TbcTask.Domain.Models.Responses;

namespace TbcTask.Domain.Models.Requests
{
    public class SearchPhysicalPersonDataRequest
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Key { get; set; }
        [Range(1,int.MaxValue,ErrorMessageResourceType =typeof(ValidationMessages),ErrorMessageResourceName ="Range")]
        public int Page { get; set; } = 1;
        [Range(1,20, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "Range")]
        public int CountPerPage { get; set; } = 5;


    }
}
