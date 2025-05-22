using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsLoggerUI.Model
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}
