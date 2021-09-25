using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared._.Responses
{
    public class ResponseBuilder<TEntity>
    {
        public bool IsError { get; set; } = false;
        public List<string> ErrorsMessage { get; set; } = new List<string>();
        public TEntity Data { get; set; }

    }
}
