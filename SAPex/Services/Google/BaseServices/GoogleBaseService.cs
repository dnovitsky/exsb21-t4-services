using System;
using System.Collections.Generic;

namespace SAPex.Services.Google.BaseServices
{
    public interface GoogleBaseService<T,E>
    {
        public List<T> Get(string email);
        public T Get(string email, E id);
        public bool Add(string email, T item);
        public bool Update(string email, T item);
        public bool Delete(string email, E id);   
    }
}
