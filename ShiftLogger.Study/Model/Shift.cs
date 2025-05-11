namespace ShiftLogger.Study.Model
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public int WorkerId { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }  
        public TimeSpan ShiftDuration { get; set; }
        public DateTime ShiftDate { get; set; }
    }
}
