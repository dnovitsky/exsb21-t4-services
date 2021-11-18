using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace SAPex.Mappers.Base
{
    public abstract class BaseMapper<T, E> : Profile, IBaseMapper<T, E>
    {
        protected abstract Mapper DtoToViewMapper();

        protected abstract Mapper ViewToDtoMapper();

        public E DtoToView(T dto)
        {
            var mapper = DtoToViewMapper();
            E view = mapper.Map<T, E>(dto);
            return view;
        }

        public IEnumerable<E> ListDtoToListView(IEnumerable<T> dtos)
        {
            var mapper = DtoToViewMapper();

            IList<E> views = new List<E>()
            {
                mapper.Map<T, E>(dtos.FirstOrDefault()),
            };
            int i = 0;
            foreach (var dto in dtos)
            {
                if (i != 0)
                {
                    E view = mapper.Map<T, E>(dto);
                    views.Add(view);
                }

                i++;
            }

            return views;
        }

        public IEnumerable<T> ListViewToListDto(IEnumerable<E> views)
        {
            var mapper = ViewToDtoMapper();

            IList<T> dtos = new List<T>()
            {
                mapper.Map<E, T>(views.FirstOrDefault()),
            };
            int i = 0;
            foreach (var view in views)
            {
                if (i != 0)
                {
                    T dto = mapper.Map<E, T>(view);
                    dtos.Add(dto);
                }

                i++;
            }

            return dtos;
        }

        public T ViewToDto(E view)
        {
            var mapper = ViewToDtoMapper();
            T dto = mapper.Map<E, T>(view);
            return dto;
        }
    }
}
