namespace ShiftLogger.Study.Model.Dto
{
    public class ShiftDto
    {
        public int WorkerId { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }
        public DateTime? ShiftDate { get; set; }
    }
}
