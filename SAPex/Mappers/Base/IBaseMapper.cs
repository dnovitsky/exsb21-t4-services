using System;
using System.Collections.Generic;

namespace SAPex.Mappers.Base
{
    public interface IBaseMapper<T, E>
    {
        public T ViewToDto(E view);

        public IEnumerable<T> ListViewToListDto(IEnumerable<E> dtos);

        public E DtoToView(T dto);

        public IEnumerable<E> ListDtoToListView(IEnumerable<T> views);
    }
}
