using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Repository;

namespace TbcTask.Infrastructure.Repository
{
    public class PhysicalPersonRepository:IPhysicalPersonRepository
    {
        private readonly IRepository<PhysicalPerson> _physicalPersonRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PhysicalPersonRepository(IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
           _physicalPersonRepository=unitOfWork.PhysicalPerson;
        }

        public PhysicalPerson AddPhysicalPerson(PhysicalPerson physicalPerson)
        {
            var result=_physicalPersonRepository.Add(physicalPerson);
            _unitOfWork.Save();
            return result;
        }
    }
}
