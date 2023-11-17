using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Database
{
    public class Gender: BaseDatabase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PhysicalPerson> PhysicalPersons { get; set;}
    }
}
