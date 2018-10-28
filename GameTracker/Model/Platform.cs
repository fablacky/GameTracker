using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Model
{
    public class Platform
    {
        public string Name { get; set; }
        public ConsoleType Type { get; set; }
    }

    public enum ConsoleType
    {
        Home,
        Handheld,
        Hybrid
    }
}
