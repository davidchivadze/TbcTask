using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Responses;

namespace TbcTask.Infrastructure.Services.Helper
{
    public static class PhysicalPersonMapper
    {
        public static PhysicalPerson AsDatabaseModel(this AddPhysicalPersonRequest model)
        {
            return new PhysicalPerson { };
        }
        public static AddPhysicalPersonResponse AsViewModel(this PhysicalPerson model)
        {
            return new AddPhysicalPersonResponse() { };
        }
    }
}
