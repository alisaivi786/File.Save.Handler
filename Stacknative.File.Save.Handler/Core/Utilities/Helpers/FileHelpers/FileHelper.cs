using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Stacknative.File.Save.Handler.Core.Utilities.Helpers.FileHelpers
{
    public class FileHelper : IFileHelper
    {
        /// <summary>
        /// File Upload
        /// </summary>
        /// <param name="file"></param>
        /// <param name="root"></param>
        /// <param name="filePath"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Upload(IFormFile file, string root, out string filePath)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                    Directory.CreateDirectory(root);

                var extension = Path.GetExtension(file.FileName);
                var guid = Guid.NewGuid().ToString();
                filePath = guid + extension;

                using (FileStream fileStream = System.IO.File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            else
            {
                filePath = string.Empty;
            }
        }

        /// <summary>
        /// File Delete
        /// </summary>
        /// <param name="filePath"></param>
        public void Delete(string filePath)
        {
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        /// <summary>
        /// File Update
        /// </summary>
        /// <param name="file"></param>
        /// <param name="root"></param>
        /// <param name="filePath"></param>
        /// <param name="oldFilePath"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(IFormFile file, string root, out string filePath, string oldFilePath)
        {
            if (System.IO.File.Exists(oldFilePath))
                System.IO.File.Delete(oldFilePath);

            Upload(file, root, out filePath);
        }
    }
}

