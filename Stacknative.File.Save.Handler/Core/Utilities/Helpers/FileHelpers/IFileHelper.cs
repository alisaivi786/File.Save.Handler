using Microsoft.AspNetCore.Http;

namespace Stacknative.File.Save.Handler.Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        void Upload(IFormFile file, string root, out string filePath);
        void Delete(string filePath);
        void Update(IFormFile file, string root, out string filePath, string oldFilePath);
    }
}