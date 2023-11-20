using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Responses.Base
{
    public enum ResponseStatus
    {
        Success,
        InternalServerError=500,
        BadRequest
         
    }
}
