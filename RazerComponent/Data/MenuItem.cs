using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazerComponent
{
    public class MenuItem
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string Icon { get; set; }

        public bool IsExpandSubMenu { get; set; } = true;

        public List<MenuItem> Children { get; set; } = null;

    }
}
