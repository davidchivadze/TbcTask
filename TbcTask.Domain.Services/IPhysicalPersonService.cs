using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Responses;

namespace TbcTask.Domain.Services
{
    public interface IPhysicalPersonService
    {
        Task<AddPhysicalPersonResponse> AddPhysicalPersonAsync(AddPhysicalPersonRequest addphysicalPersonRequest);
        Task<GetPhysicalPersonFullDataResponse> GetPhysicalPersonFullDataAsync(GetPhysicalPersonFullDataRequest request);
        Task<EditPhysicalPersonResponse> EditPhysicalPersonAsync(EditPhysicalPersonRequest editphysicalPersonRequest);
        Task<AddOrUpdatePersonImageResponse> AddOrUploadPersonImageAsync(AddOrUpdatePersonImageRequest request,string uploadFolder);
        Task<DeletePhysicalPersonResponse> DeletePhysicalPersonAsync(DeletePhysicalPersonRequest request);
        Task<AddConnectedPersonsResponse> AddConnectedPersonsAsync(AddConnectedPersonsRequest request);
        Task<RemoveConnectedPersonsResponse> RemoveConnectedPersonsAsync(RemoveConnectedPersonsRequest request);
        Task<List<SearchPhysicalPersonDataResponse>> SearchPhysicalPersonDataAsync(SearchPhysicalPersonDataRequest request);
        Task<List<PhysicalPersonConnectionReportResponse>> PhysicalPersonConnectionReportAsync();
    }
}