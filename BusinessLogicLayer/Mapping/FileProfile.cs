using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;
using AutoMapper;

namespace BusinessLogicLayer.Mapping
{
    public class FileProfile : Profile
    {
        public FileEntityModel mapToEM(FileDtoModel fileDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FileDtoModel, FileEntityModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.FileName, y => y.MapFrom(x => x.FileName))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.Category, y => y.MapFrom(x => x.Category))
                    .ForMember(x => x.StackTechnologyId, y => y.MapFrom(x => x.StackTechnologyId)));
            var mapper = new Mapper(config);

            FileEntityModel file = mapper.Map<FileDtoModel, FileEntityModel>(fileDto);
            return file;
        }

        public FileDtoModel mapToDto(FileEntityModel fileEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FileEntityModel, FileDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.FileName, y => y.MapFrom(x => x.FileName))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.Category, y => y.MapFrom(x => x.Category))
                    .ForMember(x => x.StackTechnologyId, y => y.MapFrom(x => x.StackTechnologyId)));
            var mapper = new Mapper(config);

            FileDtoModel file = mapper.Map<FileEntityModel, FileDtoModel>(fileEM);
            return file;
        }

        public IEnumerable<FileDtoModel> mapListToDto(IEnumerable<FileEntityModel> filesEM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FileEntityModel, FileDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.FileName, y => y.MapFrom(x => x.FileName))
                    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                    .ForMember(x => x.Category, y => y.MapFrom(x => x.Category))
                    .ForMember(x => x.StackTechnologyId, y => y.MapFrom(x => x.StackTechnologyId)));
            var mapper = new Mapper(config);


            IList<FileDtoModel> fileDtoList = new List<FileDtoModel>()
            {
                mapper.Map<FileEntityModel, FileDtoModel>(filesEM.FirstOrDefault())
            };
            int i = 0;
            foreach (var fl in filesEM)
            {
                if (i != 0)
                {
                    FileDtoModel file = mapper.Map<FileEntityModel, FileDtoModel>(fl);
                    fileDtoList.Add(file);
                }
                i++;
            }
            return fileDtoList;
        }
    }
}
