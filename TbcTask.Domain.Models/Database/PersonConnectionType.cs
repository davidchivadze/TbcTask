using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TbcTask.Domain.Models.Database
{
    public class PersonConnectionType: BaseDatabase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ConnectedPerson> ConnectedPerson { get; set; }
    }
}