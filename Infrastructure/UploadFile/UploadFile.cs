using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.X.Interfaces.UploadFile;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.UploadFile
{
    public class UploadFile : IUploadFile
    {
        public string ToFolder(IFormFile file)
        {

            var newFileName = $"{Path.GetFileName(file.FileName)}.{Path.GetExtension(file.FileName)}";


            // create folder if not exists
            if (!Directory.Exists("upload"))
            {
                Directory.CreateDirectory("upload");
            }

            // proses upload
            using Stream stream = new FileStream(Path.Combine("upload", newFileName), FileMode.Create);
            file.CopyTo(stream);

            return newFileName;
        }
        public void ToAws() { }
        public void ToAzure() { }
    }
}
