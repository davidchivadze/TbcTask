using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Net;
using TbcTask.Domain.Models.Resources;
using TbcTask.Domain.Models.Responses;

namespace TbcTask.Domain.Models.Responses
{
    public class Result<T> : ObjectResult
    {
        public Result(object? value,int StatusCode) :base(value)
        {
            this.StatusCode= StatusCode;
            
        }
        public static Result<T> Ok(T value)
        {
            
            return new Result<T>(new Response<T>(value),200);
        }

        public static Result<T> NotFound()
        {

            return new Result<T>(new Response<T>(HttpStatusCode.NotFound, ValidationMessages.RequiredErrorMessage), 404);
        }
        public static Result<T> ReturnCode(HttpStatusCode code, string message)
        {

            return new Result<T>(new Response<T>(code, message), (int)code);
        }
    }
}
