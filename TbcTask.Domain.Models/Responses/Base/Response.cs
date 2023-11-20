using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Responses.Base;

namespace TbcTask.Domain.Models.Responses
{
    public partial class Response<T>
    {
        public T? Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
        public List<string> Message { get; set; }
        public Response() { }
        public Response(HttpStatusCode statusCode, string[] message)
        {
            StatusCode = statusCode;
            Message = message.ToList();
        }
        public Response(HttpStatusCode statusCode,List<string> message)
        {
            statusCode = statusCode;
             Message=message;
        }
        public Response(HttpStatusCode statusCode,string message)
        {
            statusCode = statusCode;
            Message=new List<string>() { message};
        }
        public Response(T data)
        {
            Data = data;
            this.StatusCode = HttpStatusCode.OK;
        }


    }
}
