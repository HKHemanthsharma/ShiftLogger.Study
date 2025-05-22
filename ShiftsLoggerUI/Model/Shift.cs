using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsLoggerUI.Model
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public int WorkerId { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }
        public double ShiftDuration { get; set; }
        public DateTime? ShiftDate { get; set; }
    }
}
