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
        public int Page { get; set; } = 1;
        public int CountPerPage { get; set; } = 5;

    }
}
