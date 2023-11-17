using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TbcTask.Domain.Models.Database
{
    public class Phone: BaseDatabase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [ForeignKey("PhoneType")]
        public int PhoneTypeID { get;set; }
        public string PhoneNumber { get;set;}
        [ForeignKey("PhysicalPerson")]
        public int PhysicalPersonID { get; set; }
        public virtual PhoneType PhoneType { get; set; }
        public virtual PhysicalPerson PhysicalPerson { get; set; }
    }
}