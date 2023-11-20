using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbcTask.Domain.Models.Database
{
    public class PhysicalPerson:BaseDatabase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string FirstName { get;set; }
        [StringLength(50)]
        [Required]
        public string LastName { get;set; }
        [ForeignKey("Gender")]
        [Required]
        public int GenderID { get; set; }
        [Required]
        public string PrivateNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("City")]
        public int CityID { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Phone> PhoneNumbers { get; set; }
        public string? ImageAddress { get; set; }
        public  ICollection<ConnectedPersons> ConnectedPersons { get;set; }
        public virtual Gender Gender { get; set; }
        public virtual City City { get; set; }
 
        
    }
}
