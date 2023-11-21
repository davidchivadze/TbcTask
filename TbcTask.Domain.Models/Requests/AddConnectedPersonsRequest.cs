using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Resources;

namespace TbcTask.Domain.Models.Requests
{
    public class AddConnectedPersonsRequest
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = ("RequiredErrorMessage"), ErrorMessageResourceType = typeof(ValidationMessages))]
        public int ConnectionTypeID { get; set; }
        [Range(1, int.MaxValue, ErrorMessageResourceName = ("RequiredErrorMessage"), ErrorMessageResourceType = typeof(ValidationMessages))]
        public int PhysicalPersonID { get; set; }
        [Range(1, int.MaxValue, ErrorMessageResourceName = ("RequiredErrorMessage"), ErrorMessageResourceType = typeof(ValidationMessages))]
        public int ConnectedPersonID { get; set;}
    }
}
