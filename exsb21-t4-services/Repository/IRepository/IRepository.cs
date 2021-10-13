using System;
using System.Collections.Generic;

namespace exsb21_t4_services.Repository.IRepository
{
    public interface IRepository<T,E>
    {
        public T Add(T item);
        public T FindById(E id);
        public List<T> FindAll();
    }
}
