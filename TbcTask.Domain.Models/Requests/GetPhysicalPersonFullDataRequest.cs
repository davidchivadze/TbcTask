using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Resources;

namespace TbcTask.Domain.Models.Requests
{
    public class GetPhysicalPersonFullDataRequest
    {
        [Range(1,int.MaxValue,ErrorMessageResourceName =("Range"),ErrorMessageResourceType =typeof(ValidationMessages))]
        public int Id { get; set; }
    }
}
