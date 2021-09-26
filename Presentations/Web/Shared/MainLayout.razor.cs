using System;
using Microsoft.AspNetCore.Components;

namespace Web.Shared
{
    public partial class MainLayout
    {
        public bool _collapsed;

        public void Toggle()
        {
            _collapsed = !_collapsed;
        }

        public void OnCollapse(bool isCollapsed)
        {
            Console.WriteLine($"Collapsed: {isCollapsed}");
        }


    }
}
