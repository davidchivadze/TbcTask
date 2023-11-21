using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

        [HttpGet("GetPhysicalPersonFullDataAsync")]
        public async Task<Result<GetPhysicalPersonFullDataResponse>> GetPhysicalPersonFullDataAsync([FromQuery]GetPhysicalPersonFullDataRequest request)
        {
            try
            {
                var result =await _PhysicalPersonService.GetPhysicalPersonFullDataAsync(request);
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
        [HttpGet("SearchPhysicalPersonAsync")]
        public async Task<Result<List<SearchPhysicalPersonDataResponse>>> SearchPhysicalPersonDataAsync([FromQuery]SearchPhysicalPersonDataRequest request)
        {
            try
            {
              var result = await _PhysicalPersonService.SearchPhysicalPersonDataAsync(request);
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
        [HttpGet("GetPhysicalPersonConnectionReportAsync")]
        public async Task<Result<List<PhysicalPersonConnectionReportResponse>>> GetPhysicalPersonConnectionReportAsync()
        {
            try
            {
                var result = await _PhysicalPersonService.PhysicalPersonConnectionReportAsync();
                return Result<List<PhysicalPersonConnectionReportResponse>>.Ok(result);
            }
            catch (ApiException ex)
            {
                return Result<List<PhysicalPersonConnectionReportResponse>>.ReturnCode(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("AddOrUpdateImageAsync")]
        public async Task<Result<AddOrUpdatePersonImageResponse>> AddOrUpdateImageAsync([FromForm]AddOrUpdatePersonImageRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.AddOrUploadPersonImageAsync(request,String.IsNullOrEmpty(_WebHostEnvironment.WebRootPath)?
                    _WebHostEnvironment.ContentRootPath:_WebHostEnvironment.WebRootPath);
                return Result<AddOrUpdatePersonImageResponse>.Ok(result);
            }catch(ApiException ex)
            {
                return Result<AddOrUpdatePersonImageResponse>.ReturnCode(ex);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("DeletePhysicalPersonAsync")]
        public async Task<Result<DeletePhysicalPersonResponse>> DeletePhysicalPersonAsync(DeletePhysicalPersonRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.DeletePhysicalPersonAsync(request);
                return Result<DeletePhysicalPersonResponse>.Ok(result);
            }catch(ApiException ex)
            {
                return Result<DeletePhysicalPersonResponse>.ReturnCode(ex);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("DeleteConnectionAsync")]
        public async Task<Result<RemoveConnectedPersonsResponse>> RemoveConnectedPersonsAsync(RemoveConnectedPersonsRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.RemoveConnectedPersonsAsync(request);
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
        [HttpPost("AddConnectedPersonsAsync")]
        public async Task<Result<AddConnectedPersonsResponse>> AddConnectedPersonsAsync(AddConnectedPersonsRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.AddConnectedPersonsAsync(request);
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
        [HttpPost("AddPhysicalPersonAsync")]
        public async Task<Result<AddPhysicalPersonResponse>> AddPhysicalPersonAsync([FromBody] AddPhysicalPersonRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.AddPhysicalPersonAsync(request);
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
        [HttpPatch("EditPhysicalPersonAsync")]
        public async Task<Result<EditPhysicalPersonResponse>> EditPhysicalPersonAsync([FromBody] EditPhysicalPersonRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.EditPhysicalPersonAsync(request);
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
