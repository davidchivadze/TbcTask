using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;

namespace TbcTask.Domain.Repository
{
    public interface IPhoneNumberRepository:IBaseRepository<Phone>
    {
        void UpdatePhoneNumber(Phone phone);
    }
}
