using BusinessLogicLayer.DtoModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class LocationDtoModel: ItemDtoModel
    {
        public LocationDtoModel()
        {
        }
        public LocationDtoModel(string locationName)
        {
            this.Name = locationName;
            this.Id = Guid.NewGuid();
        }
    }
}
