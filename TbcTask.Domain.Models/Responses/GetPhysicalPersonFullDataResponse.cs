using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Responses
{
    public class GetPhysicalPersonFullDataResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PrivateNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public ICollection<PhoneNumberResponse> PhoneNumbers { get; set; }
        public string? ImageAddress { get; set; }
        public ICollection<ConnectedPersonResponse> ConnectedPersons { get; set; }
    }
}
