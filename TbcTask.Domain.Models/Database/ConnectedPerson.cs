using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TbcTask.Domain.Models.Database
{
    public class ConnectedPersons: BaseDatabase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PersonConnectionTypeID { get; set; }
        public int PhysicialPersonId { get;set; }
        public int ConnectedPersonId {  get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual PersonConnectionType PersonConnectionType { get; set; }

        public virtual PhysicalPerson PhysicialPerson { get; set; }

        public virtual PhysicalPerson ConnectedPerson { get; set; }
    }
}