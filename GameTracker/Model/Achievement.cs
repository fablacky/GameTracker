using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Model
{
    public abstract class Achievement
    {
        public string Name { get; set; }
        public DateTime DateObtainment { get; set; }
    }
}
