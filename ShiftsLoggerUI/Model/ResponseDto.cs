using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsLoggerUI.Model
{
    public class ResponseDto<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; }
        public DateTime ResponseTime { get; set; }
    }
}
