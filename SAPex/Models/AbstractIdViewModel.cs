using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public abstract class AbstractIdViewModel
    {
        public AbstractIdViewModel()
        {
            Id = null;
        }

        public AbstractIdViewModel(Guid id)
        {
            Id = id;
        }

        public Guid? Id { get; set; }
    }
}
