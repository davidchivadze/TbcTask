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
    public class EditPhysicalPersonRequest
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Id")]
        public int? Id { get; set; }
        [MinLength(2, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(ValidationMessages))]
        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "MaxLength")]
        public string FirstName { get; set; }
        [MinLength(2, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(ValidationMessages))]
        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "MaxLength")]
        public string LastName { get; set; }
        [Range(1, 2, ErrorMessageResourceName = "GenderMinMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        public int GenderID { get; set; }
        [RegularExpression("^[0-9]{11}$", ErrorMessageResourceName = "PrivateNumberNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string PrivateNumber { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(ValidationMessages))]
        [AgeValidation(ErrorMessageResourceType =typeof(ValidationMessages),ErrorMessageResourceName = "PersonAgeValidation")]
        public DateTime DateOfBirth { get; set; }
        [Range(1,int.MaxValue,ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType =typeof(ValidationMessages))]
        public int CityID { get; set; }
        public ICollection<EditPhoneNumberRequest> PhoneNumbers { get; set; }

    }
}
