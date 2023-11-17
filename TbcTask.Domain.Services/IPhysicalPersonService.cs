using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Responses;

namespace TbcTask.Domain.Services
{
    public interface IPhysicalPersonService
    {
        public AddPhysicalPersonResponse AddPhysicalPerson(AddPhysicalPersonRequest addphysicalPersonRequest);
    }
}