using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Requests.CustomValidations;
using TbcTask.Domain.Models.Resources;

namespace TbcTask.Domain.Models.Requests
{
    public class AddOrUpdatePersonImageRequest
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType =typeof(ValidationMessages))]
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(ValidationMessages))]
        [AllowedFileFormat("jpg","png")]
        public IFormFile PhysicalPersonImage { get; set; }
    }
}
