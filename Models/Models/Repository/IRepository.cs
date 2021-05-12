using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public interface IRepository<T>  where T: Entity  //реализация репозитория
    {
        IEnumerable<T> GetObjectsList();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetSpecificEntity(int id);
    }
}
