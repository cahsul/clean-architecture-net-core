using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.X.Exceptions
{
    public class UnauthenticatedException : Exception
    {
        public IEnumerable<string> ErrorsMessage { get; set; } = new List<string>();
        public UnauthenticatedException(IEnumerable<string> errorsMessage) : base()
        {
            ErrorsMessage = errorsMessage;
        }

        public UnauthenticatedException(string message) : base()
        {
            ErrorsMessage = new List<string> { message };
        }

        public UnauthenticatedException() : base()
        {
            ErrorsMessage = new List<string> { };
        }
    }
}
