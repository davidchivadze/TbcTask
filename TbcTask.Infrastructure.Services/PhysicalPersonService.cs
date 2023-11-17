using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Responses;
using TbcTask.Domain.Repository;
using TbcTask.Domain.Services;
using TbcTask.Infrastructure.Services.Helper;

namespace TbcTask.Infrastructure.Services
{
    public class PhysicalPersonService : IPhysicalPersonService
    {
        private readonly IPhysicalPersonRepository _physicalPersonRepository;
        public PhysicalPersonService(IPhysicalPersonRepository physicalPersonRepository)
        {
            _physicalPersonRepository = physicalPersonRepository;
        } 
        public AddPhysicalPersonResponse AddPhysicalPerson(AddPhysicalPersonRequest addphysicalPersonRequest)
        {
            var result= _physicalPersonRepository.AddPhysicalPerson(addphysicalPersonRequest.AsDatabaseModel());
            return result.AsViewModel();
        }
    }
}