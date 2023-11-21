using Microsoft.AspNetCore.Http;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Responses;

namespace TbcTask.Domain.Services
{
    public interface IPhysicalPersonService
    {
        Task<AddPhysicalPersonResponse> AddPhysicalPerson(AddPhysicalPersonRequest addphysicalPersonRequest);
        Task<GetPhysicalPersonFullDataResponse> GetPhysicalPersonFullData(GetPhysicalPersonFullDataRequest request);
        Task<EditPhysicalPersonResponse> EditPhysicalPerson(EditPhysicalPersonRequest editphysicalPersonRequest);
        Task<AddOrUpdatePersonImageResponse> AddOrUploadPersonImage(AddOrUpdatePersonImageRequest request,string uploadFolder);
        Task<DeletePhysicalPersonResponse> DeletePhysicalPerson(DeletePhysicalPersonRequest request);
        Task<AddConnectedPersonsResponse> AddConnectedPersons(AddConnectedPersonsRequest request);
        Task<RemoveConnectedPersonsResponse> RemoveConnectedPersons(RemoveConnectedPersonsRequest request);
        Task<List<SearchPhysicalPersonDataResponse>> SearchPhysicalPersonData(SearchPhysicalPersonDataRequest request);
    }
}