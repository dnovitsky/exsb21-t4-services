using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using AutoMapper;
using BusinessLogicLayer.Mapping;

namespace BusinessLogicLayer.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly FileProfile profile = new();

        public FileService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddFileAsync(FileDtoModel fileDto)
        {
            try
            {
                FileEntityModel file = profile.mapToEM(fileDto);
                await unitOfWork.Files.CreateAsync(file);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<FileDtoModel>> GetAllFilesAsync()
        {
            IEnumerable<FileEntityModel> fileList = await unitOfWork.Files.GetAllAsync();
            
            return profile.mapListToDto(fileList);
        }

        public async Task<FileDtoModel> FindFileByIdAsync(Guid id)
        {
            FileEntityModel fileEM = await unitOfWork.Files.FindByIdAsync(id);
            FileDtoModel fileDto = profile.mapToDto(fileEM);
            return fileDto;
        }

        public void DeleteFileById(Guid id)
        {
            unitOfWork.Files.Delete(id);
        }
    }
}
