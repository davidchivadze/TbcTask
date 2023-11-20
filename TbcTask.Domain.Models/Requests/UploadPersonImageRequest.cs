using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Resources;

namespace TbcTask.Domain.Models.Requests
{
    public class UploadPersonImageRequest
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType =typeof(ValidationMessages))]
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(ValidationMessages))]
        public IFormFile PhysicalPersonImage { get; set; }
    }
}
