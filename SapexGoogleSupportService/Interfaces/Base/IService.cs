using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SapexGoogleSupportService.Interfaces.Base
{
    public interface IService<T,E>
    {
        Task<T> CreateAsync(T item);
        T Update(T item);
        T Delete(E id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindByIdAsync(E id);
    }
}
