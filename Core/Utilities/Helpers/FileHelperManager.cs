using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string root)
        {
            throw new NotImplementedException();
        }

        public string Update(IFormFile file, string filepath, string root)
        {
            throw new NotImplementedException();
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetFileName(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filepath = guid + extension;

                using(FileStream fileStream = File.Create(root + filepath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filepath;
                }

            }
            return null;

            
        }
    }
}
