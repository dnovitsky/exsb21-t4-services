using System;
using System.Collections.Generic;

namespace SAPex.Repository.Google.BaseRepository
{
    public interface GoogleBaseRepository<T,E>
    {
        public T Add(T item);
        public T FindById(E id);
        public List<T> FindAll();
    }
}
