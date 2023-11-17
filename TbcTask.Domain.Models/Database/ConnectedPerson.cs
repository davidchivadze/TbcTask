using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TbcTask.Domain.Models.Database
{
    public class ConnectedPerson: BaseDatabase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [ForeignKey("PersonConnectionType")]
        public int PersonConnectionTypeID { get; set; }
        [ForeignKey("PhysicialPerson")]
        public int PhysicalPersonID { get; set; }

        public virtual PersonConnectionType PersonConnectionType { get; set; }
        public virtual PhysicalPerson PhysicalPerson { get; set; }
    }
}