using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TbcTask.Domain.Models.Resources;

namespace TbcTask.Domain.Models.Requests
{
    public class EditPhysicalPersonRequest
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType =typeof(ValidationMessages))]
        [Display(Name = "Id")]
        public int? Id { get; set; }
        [MinLength(5,ErrorMessageResourceName ="MinLength",ErrorMessageResourceType =typeof(ValidationMessages))]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int GenderID { get; set; }
        public string PrivateNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityID { get; set; }
        public ICollection<AddOrEditPhoneNumberRequest> PhoneNumbers { get; set; }
    }
}
