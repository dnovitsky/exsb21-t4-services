﻿using System;
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

            IList<T> listDto = new List<T>()
            {
                mapper.Map<E, T>(values.FirstOrDefault())
            };

            int i = 0;
            foreach (var avail in values)
            {
                if (i != 0)
                {
                    T dto = mapper.Map<E, T>(avail);
                    listDto.Add(dto);
                }
                i++;
            }
            return listDto;
        }
    }
}