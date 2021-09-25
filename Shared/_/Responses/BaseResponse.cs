using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared._.Responses
{
    public abstract class BaseResponse<TKey>
    {
        public TKey Id { get; set; }

    }

    public abstract class BaseResponse
    {
    }
}
