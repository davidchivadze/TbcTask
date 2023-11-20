using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;

namespace TbcTask.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseDatabase
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
