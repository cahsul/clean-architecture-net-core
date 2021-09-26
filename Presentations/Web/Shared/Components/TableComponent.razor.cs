using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Web.Shared.Components
{
    public partial class TableComponent<TItem>
    {
        [Parameter] public RenderFragment<TItem> ChildContent { get; set; }
        [Parameter] public IEnumerable<TItem> DataSource { get; set; }

        //  [Parameter] public RenderFragment<TItem> RowTemplate { get; set; }
    }
}
