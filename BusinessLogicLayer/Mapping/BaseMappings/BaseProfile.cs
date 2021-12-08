using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;

namespace BusinessLogicLayer.Mapping.BaseMappings
{
    public abstract class BaseProfile<T, E>
    {
        protected abstract Mapper DtoModelToEntityModelMapper();
        protected abstract Mapper EntityModelToDtoModelMapper();

        public E mapToEM(T value)
        {
            var mapper = DtoModelToEntityModelMapper();
            return mapper.Map<T, E>(value);
        }

        public T mapToDto(E value)
        {
            var mapper = EntityModelToDtoModelMapper();
            return mapper.Map<E, T>(value);
        }

        public IEnumerable<T> mapListToDto(IEnumerable<E> values)
        {
            var mapper = EntityModelToDtoModelMapper();

            IList<T> listDto = new List<T>() { };

            int i = 0;
            foreach (var avail in values)
            {
                T dto = mapper.Map<E, T>(avail);
                listDto.Add(dto);
            }
            return listDto;
        }

        public IEnumerable<T> mapListToEM(IEnumerable<E> values)
        {
            var mapper = DtoModelToEntityModelMapper();

            IList<T> listEM = new List<T>() { };

            foreach (var avail in values)
            {
                T em = mapper.Map<E, T>(avail);
                listEM.Add(em);
            }
            return listEM;
        }

        public IEnumerable<E> mapDtoListToEM(IEnumerable<T> values)
        {
            var mapper = DtoModelToEntityModelMapper();

            IList<E> listEM = new List<E>() { };

            int i = 0;
            foreach (var avail in values)
            {
                E em = mapper.Map<T, E>(avail);
                listEM.Add(em);
            }
            return listEM;
        }
    }
}
