using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.X.Interfaces.Library
{
    public interface ICryptography
    {
        public string AES_Encrypt(string text);
        public string AES_Decrypt(string text);
    }
}
