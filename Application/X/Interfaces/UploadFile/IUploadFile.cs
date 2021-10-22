using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.X.Interfaces.UploadFile
{
    public interface IUploadFile
    {
        string ToFolder(IFormFile file);
    }
}
