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
        private readonly UserInputs Uinp;
        public ShiftService(IShiftRepository _repo, UserInputs ui)
        {
            repository = _repo;
            Uinp = ui;
            
        }
        public void CreateShift()
        {
            Shift NewShift = Uinp.GetNewShift().GetAwaiter().GetResult();
            ResponseDto<Shift> CreateResponse = repository.CreateShift(NewShift).GetAwaiter().GetResult();
            UserInterface.ShowResponse(CreateResponse);

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
            int ShiftId = Uinp.InputId();
            ResponseDto<List<Shift>> Shiftresponse = repository.GetSingleShift(ShiftId).GetAwaiter().GetResult();
            UserInterface.ShowResponse(Shiftresponse);
        }

        public void UpdateShift()
        {
            Shift UpdatedShift = Uinp.SelectShift().GetAwaiter().GetResult();
            UpdatedShift=Uinp.GetUpdateShift(UpdatedShift).GetAwaiter().GetResult();
            ResponseDto<Shift> UpdateResponse = repository.UpdateShift(UpdatedShift).GetAwaiter().GetResult();
            UserInterface.ShowResponse(UpdateResponse);
        }
    }
}
