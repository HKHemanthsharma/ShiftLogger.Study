﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShiftsLoggerUI.Model
{
    public class Worker
    {
        [property:JsonPropertyName("workerId")]
        public int WorkerId { get; set; }
        [property: JsonPropertyName("name")]
        public string Name { get; set; }
        [property: JsonPropertyName("shifts")]
        public List<Shift> Shifts { get; set; }
    }
}
