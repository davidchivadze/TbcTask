using Microsoft.AspNetCore.Mvc;
using TbcTask.ActionFilters.Validation;
using TbcTask.Domain.Models.Exceptions;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Responses;
using TbcTask.Domain.Services;

namespace TbcTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelFilter]

    public class PhysicalPersonController : ControllerBase
    {
        private readonly IPhysicalPersonService _PhysicalPersonService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public PhysicalPersonController(IPhysicalPersonService physicalPersonService,IWebHostEnvironment webHostEnvironment)
        {
            _PhysicalPersonService = physicalPersonService;
            _WebHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetPhysicalPersonFullData/{Id}")]
        public async Task<Result<GetPhysicalPersonFullDataResponse>> GetPhysicalPersonFullData(int Id)
        {
            try
            {
                var result =await _PhysicalPersonService.GetPhysicalPersonFullData(Id);
                return Result<GetPhysicalPersonFullDataResponse>.Ok(result);
            }
            catch (ApiException ex)
            {
                return Result<GetPhysicalPersonFullDataResponse>.ReturnCode(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("SearchPhysicalPerson/{key}")]
        public async Task<Result<List<SearchPhysicalPersonDataResponse>>> SearchPhysicalPersonData(string key)
        {
            try
            {
                var result = await _PhysicalPersonService.SearchPhysicalPersonData(key);
                return Result<List<SearchPhysicalPersonDataResponse>>.Ok(result);
            }
            catch (ApiException ex)
            {
                return Result<List<SearchPhysicalPersonDataResponse>>.ReturnCode(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("AddOrUpdateImage")]
        public async Task<Result<UploadPersonImageResponse>> AddOrUpdateImage([FromForm]UploadPersonImageRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.AddOrUploadPersonImage(request,String.IsNullOrEmpty(_WebHostEnvironment.WebRootPath)?
                    _WebHostEnvironment.ContentRootPath:_WebHostEnvironment.WebRootPath);
                return Result<UploadPersonImageResponse>.Ok(result);
            }catch(ApiException ex)
            {
                return Result<UploadPersonImageResponse>.ReturnCode(ex);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("DeletePhysicalPerson")]
        public async Task<Result<GetPhysicalPersonFullDataResponse>> DeletePhysicalPerson(int Id)
        {
            try
            {
                var result = await _PhysicalPersonService.DeletePhysicalPerson(Id);
                return Result<GetPhysicalPersonFullDataResponse>.Ok(result);
            }catch(ApiException ex)
            {
                return Result<GetPhysicalPersonFullDataResponse>.ReturnCode(ex);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("DeleteConnection")]
        public async Task<Result<RemoveConnectedPersonsResponse>> RemoveConnectedPersons(RemoveConnectedPersonsRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.RemoveConnectedPersons(request);
                return Result<RemoveConnectedPersonsResponse>.Ok(result);
            }
            catch (ApiException ex)
            {
                return Result<RemoveConnectedPersonsResponse>.ReturnCode(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("AddConnectedPersons")]
        public async Task<Result<AddConnectedPersonsResponse>> AddConnectedPersons(AddConnectedPersonsRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.AddConnectedPersons(request);
                return Result<AddConnectedPersonsResponse>.Ok(result);
            }
            catch (ApiException ex)
            {
                return Result<AddConnectedPersonsResponse>.ReturnCode(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("AddPhysicalPerson")]
        public async Task<Result<AddPhysicalPersonResponse>> AddPhysicalPerson([FromBody] AddPhysicalPersonRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.AddPhysicalPerson(request);
                return Result<AddPhysicalPersonResponse>.Ok(result);
            }
            catch (ApiException ex)
            {
                return Result<AddPhysicalPersonResponse>.ReturnCode(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPatch("EditPhysicalPerson")]
        public async Task<Result<EditPhysicalPersonResponse>> EditPhysicalPerson([FromBody] EditPhysicalPersonRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.EditPhysicalPerson(request);
                return Result<EditPhysicalPersonResponse>.Ok(result);
            }
            catch (ApiException ex)
            {
                return Result<EditPhysicalPersonResponse>.ReturnCode(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
