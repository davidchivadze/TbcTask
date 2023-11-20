using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TbcTask.ActionFilters.Validation;
using TbcTask.Domain.Models.Exceptions;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Responses;
using TbcTask.Domain.Models.Responses.Base;
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
        [HttpPost("AddPhysicalPersons")]
        public async Task<Result<GetPhysicalPersonFullDataResponse>> AddPhysicalPersons(int Id)
        {
            try
            {
                var result = await _PhysicalPersonService.GetPhysicalPersonFullData(Id);
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
        [HttpGet("{Id}")]
        public async Task<Result<GetPhysicalPersonFullDataResponse>> Get(int Id)
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

        [HttpPatch("EditPhysicalPerson")]
        public async Task<Result<EditPhysicalPersonResponse>> EditPhysicalPerson([FromBody] EditPhysicalPersonRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.EditPhysicalPerson(request);
                return Result<EditPhysicalPersonResponse>.Ok(result);
            }
            catch(ApiException ex)
            {
                return Result<EditPhysicalPersonResponse>.ReturnCode(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("AddOrUpdateImage")]
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
        [HttpPost("AddConnectedPersons")]
        public async Task<Result<AddOrRemoveConnectedPersonsResponse>> AddConnectedPersons(AddOrRemoveConnectedPersonsRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.AddOrRemoveConnectedPersons(request);
                return Result<AddOrRemoveConnectedPersonsResponse>.Ok(result);
            }
            catch (ApiException ex)
            {
                return Result<AddOrRemoveConnectedPersonsResponse>.ReturnCode(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
