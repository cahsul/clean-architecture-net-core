using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared._.Exceptions
{
    public class BadRequestException : Exception
    {
        public IEnumerable<string> ErrorsMessage { get; set; } = new List<string>();
        public BadRequestException(IEnumerable<string> errorsMessage) : base()
        {
            ErrorsMessage = errorsMessage;
        }

        public BadRequestException(string message) : base()
        {
            ErrorsMessage = new List<string> { message };
        }

    }
}
