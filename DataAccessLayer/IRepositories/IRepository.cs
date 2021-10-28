using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        T Search(string search);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
