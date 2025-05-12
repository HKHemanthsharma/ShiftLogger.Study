using Microsoft.EntityFrameworkCore;
using ShiftLogger.Study.Model;
using ShiftLogger.Study.Model.Dto;

namespace ShiftLogger.Study.Services
{
    public interface IShiftRepository
    {
         Task<List<Shift>> GetAllShiftsAsync();
         Task<Shift> GetShiftByIdAsync(int Id);
        Task<Shift> CreateShift(ShiftDto shift);
    }
    public class ShiftRepository:IShiftRepository
    {
        private readonly ShiftDbContext _context;
        public ShiftRepository(ShiftDbContext context)
        {
            _context = context;
        }
        public async Task<List<Shift>> GetAllShiftsAsync()
        {
            return await _context.Shifts.ToListAsync();
        }
        public async Task<Shift> GetShiftByIdAsync(int Id)
        {
            return await _context.Shifts.FirstOrDefaultAsync(x => x.ShiftId == Id);
        }
        public async Task<Shift> CreateShift(ShiftDto shift)
        {
            Shift NewShift = new Shift
            {
                ShiftDate = shift.ShiftDate,
                ShiftStartTime= shift.ShiftStartTime,
                ShiftEndTime=shift.ShiftEndTime,
                WorkerId=shift.WorkerId
            };
            var AddedEntity= await _context.Shifts.AddAsync(NewShift);
            await _context.SaveChangesAsync();
            return AddedEntity.Entity;
        }
    }
}
