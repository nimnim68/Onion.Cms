using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Onion.Cms.Framework.Common.File;

namespace Onion.Cms.Framework.Common.Interfaces
{
    public interface IFileHandler
    {
        UploadDto UploadFile(IFormFile file, string pathFolder);
        Task<UploadDto> UploadFileAsync(IFormFile file, string pathFolder);
        Task<List<UploadDto>> UploadFile(List<IFormFile> files, string pathFolder);
    }
}