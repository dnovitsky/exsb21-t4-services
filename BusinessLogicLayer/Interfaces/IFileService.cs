﻿using BusinessLogicLayer.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IFileService
    {
        Task<bool> AddFileAsync(FileDtoModel fileDto);
        Task<IEnumerable<FileDtoModel>> GetAllFilesAsync();
        Task<FileDtoModel> FindFileByIdAsync(Guid id);

        bool UpdateFileCategory(FileDtoModel fileDto);
        void DeleteFileById(Guid id);

    }
}
