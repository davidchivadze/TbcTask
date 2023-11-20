using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TbcTask.ActionFilters.Validation;
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
            catch (Exception ex)
            {
                return Result<GetPhysicalPersonFullDataResponse>.ReturnCode(HttpStatusCode.InternalServerError,ex.Message);
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
            catch (Exception ex)
            {
                return Result<AddPhysicalPersonResponse>.ReturnCode(HttpStatusCode.InternalServerError,ex.Message);
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
            catch (Exception ex)
            {
                return Result <GetPhysicalPersonFullDataResponse>.ReturnCode(HttpStatusCode.InternalServerError,ex.Message);
            }
        }

        [HttpPost("EditPhysicalPerson")]
        public async Task<Result<EditPhysicalPersonResponse>> EditPhysicalPerson([FromBody] EditPhysicalPersonRequest request)
        {
            try
            {
                var result = await _PhysicalPersonService.EditPhysicalPerson(request);
                return Result<EditPhysicalPersonResponse>.Ok(result);
            }
            catch (Exception ex)
            {
                return Result<EditPhysicalPersonResponse>.ReturnCode(HttpStatusCode.InternalServerError, ex.Message);
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
            }catch(Exception ex)
            {
                return Result<UploadPersonImageResponse>.ReturnCode(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
