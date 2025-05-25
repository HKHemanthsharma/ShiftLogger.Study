using ShiftsLoggerUI.Model;
using System.Collections.Generic;
using System.Text.Json;

namespace ShiftsLoggerUI.Repository
{
    public interface IShiftRepository
    {
        public  Task<ResponseDto<List<Shift>>> GetAllShifts();
        public Task<ResponseDto<Shift>> GetSingleShift();
        public Task<ResponseDto<Shift>> CreateShift();
        public Task<ResponseDto<Shift>> DeleteShift();
        public Task<ResponseDto<Shift>> UpdateShift();
    }
    public class ShiftRepostory : IShiftRepository
    {
        private readonly IMyHttpClient client;
        public ShiftRepostory(IMyHttpClient _client)
        {
            client = _client;
        }
        public async Task<ResponseDto<Shift>> CreateShift()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<Shift>> DeleteShift()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<Shift>>> GetAllShifts()
        {
            try
            {
                HttpClient ShiftClient = client.GetClient();
                string ShiftUrl = client.GetBaseUrl() + "Shifts";
                using (Stream stream = await ShiftClient.GetStreamAsync(ShiftUrl))
                {
                    var objectresponse = JsonSerializer.Deserialize<ResponseDto<List<Shift>>>(stream);
                    return objectresponse;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<ResponseDto<Shift>> GetSingleShift()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<Shift>> UpdateShift()
        {
            throw new NotImplementedException();
        }
    }
}
