using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShiftsLoggerUI.Model
{
    public class ShiftDto
    {
        public int workerId { get; set; }
        public string shiftStartTime { get; set; } // Treat as string
        public string shiftEndTime { get; set; } // Treat as string
        public string shiftDate { get; set; }
    }
}
