using System;
using System.Collections.Generic;

namespace SAPex.Repositories.Google.BaseRepositories
{
    public interface GoogleBaseRepository<T,E>
    {
        public List<T> FindAll();
        public T FindById(E id);
        public T Add(T item);
        public T Update(T item);
        public bool Delete(T item);
    }
}
