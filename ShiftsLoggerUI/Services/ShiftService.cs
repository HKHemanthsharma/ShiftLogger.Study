using ShiftsLoggerUI.Model;
using ShiftsLoggerUI.Repository;

namespace ShiftsLoggerUI.Services
{
    public interface IShiftService
    {
        public void GetAllShifts();
        public void GetSingleShift();
        public void DeleteShift();
        public void CreateShift();
        public void UpdateShift();


    }
    public class ShiftService:IShiftService
    {
        private readonly IShiftRepository repository;

        public ShiftService(IShiftRepository _repo)
        {
            repository = _repo;
            
        }
        public void CreateShift()
        {
            throw new NotImplementedException();
        }

        public void DeleteShift()
        {
            throw new NotImplementedException();
        }

        public void GetAllShifts()
        {
            ResponseDto<List<Shift>> Shiftresponse = repository.GetAllShifts().GetAwaiter().GetResult();
            UserInterface.ShowResponse(Shiftresponse);
        }

        public void GetSingleShift()
        {
            throw new NotImplementedException();
        }

        public void UpdateShift()
        {
            throw new NotImplementedException();
        }
    }
}
