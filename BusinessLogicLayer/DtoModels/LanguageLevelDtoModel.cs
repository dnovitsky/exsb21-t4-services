using BusinessLogicLayer.DtoModels.BaseModels;

namespace BusinessLogicLayer.DtoModels
{
    public class LanguageLevelDtoModel : ItemOrderLevelDtoModel
    {        
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}