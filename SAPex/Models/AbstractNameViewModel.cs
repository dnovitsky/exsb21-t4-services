using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public abstract class AbstractNameViewModel: AbstractIdViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
