using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Exceptions
{
    public class DatabaseValidationException:ApiException
    {
        public DatabaseValidationException(string message) : base(message) { }
        public DatabaseValidationException(string message,Exception innerException) : base(message, innerException) { }
    }
}
