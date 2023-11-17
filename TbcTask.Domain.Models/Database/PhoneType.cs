using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TbcTask.Domain.Models.Database
{
    public class PhoneType : BaseDatabase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Phone> Phones { get; set;}

    }
}