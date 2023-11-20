using Microsoft.AspNetCore.Http;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Responses;

namespace TbcTask.Domain.Services
{
    public interface IPhysicalPersonService
    {
        Task<AddPhysicalPersonResponse> AddPhysicalPerson(AddPhysicalPersonRequest addphysicalPersonRequest);
        Task<GetPhysicalPersonFullDataResponse> GetPhysicalPersonFullData(int id);
        Task<EditPhysicalPersonResponse> EditPhysicalPerson(EditPhysicalPersonRequest editphysicalPersonRequest);
        Task<UploadPersonImageResponse> AddOrUploadPersonImage(UploadPersonImageRequest request,string uploadFolder);
        Task<GetPhysicalPersonFullDataResponse> DeletePhysicalPerson(int Id);
        Task<AddConnectedPersonsResponse> AddConnectedPersons(AddConnectedPersonsRequest request);
        Task<RemoveConnectedPersonsResponse> RemoveConnectedPersons(RemoveConnectedPersonsRequest request);
    }
}