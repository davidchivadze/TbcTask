using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Database
{
    public class PhysicalPerson: BaseDatabase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get;set; }
        [StringLength(50)]
        public string LastName { get;set; }
        [ForeignKey("Gender")]
        public int GenderID { get; set; }
        public string PrivateNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityID { get; set; }
        public ICollection<Phone> PhoneNumbers { get; set; }
        public string ImageAddress { get; set; }
        public ICollection<ConnectedPerson> ConnectedPersons { get;set; }
        public virtual Gender Gender { get; set; }

    }
}
