using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Enums;

namespace Shared.X.Responses
{
    public class ResponseBuilder<TEntity>
    {
        public bool IsError { get; set; } = false;
        public ErrorType? ErrorType { get; set; }
        public List<string> ErrorsMessage { get; set; } = new List<string>();
        public string Message { get; set; }
        public TEntity Data { get; set; }

    }
}
