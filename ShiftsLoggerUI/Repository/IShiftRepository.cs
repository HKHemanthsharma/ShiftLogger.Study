using ShiftsLoggerUI.Model;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;

namespace ShiftsLoggerUI.Repository
{
    public interface IShiftRepository
    {
        public  Task<ResponseDto<List<Shift>>> GetAllShifts();
        public Task<ResponseDto<List<Shift>>> GetSingleShift(int Id);
        public Task<ResponseDto<Shift>> CreateShift(Shift Newshift);
        public Task<ResponseDto<Shift>> DeleteShift();
        public Task<ResponseDto<Shift>> UpdateShift(Shift UpdatedShift);
    }
    public class ShiftRepostory : IShiftRepository
    {
        private readonly IMyHttpClient client;
        public ShiftRepostory(IMyHttpClient _client)
        {
            client = _client;
        }
        public async Task<ResponseDto<Shift>> CreateShift(Shift Newshift)
        {
            try
            {
                HttpClient ShiftClient = client.GetClient();
                string ShiftUrl = client.GetBaseUrl() + "Shifts";
                var objectresponse = await ShiftClient.PostAsJsonAsync(ShiftUrl, Newshift);
                var ResponseStream = await objectresponse.Content.ReadAsStreamAsync();
                ResponseDto<Shift> CreatedResponse=await JsonSerializer.DeserializeAsync<ResponseDto<Shift>>(ResponseStream);
                return CreatedResponse;      
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
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
                    var objectresponse = await JsonSerializer.DeserializeAsync<ResponseDto<List<Shift>>>(stream);
                    return objectresponse;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<ResponseDto<List<Shift>>> GetSingleShift(int Id)
        {
            try
            {
                HttpClient ShiftClient = client.GetClient();
                string ShiftUrl = client.GetBaseUrl() + $"Shifts/{Id}";
                using (Stream stream = await ShiftClient.GetStreamAsync(ShiftUrl))
                {
                    var objectresponse = JsonSerializer.Deserialize<ResponseDto<List<Shift>>>(stream);
                    return objectresponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<ResponseDto<Shift>> UpdateShift(Shift UpdatedShift)
        {
            try
            {
                HttpClient ShiftClient = client.GetClient();
                string ShiftUrl = client.GetBaseUrl() + $"Shifts/{UpdatedShift.shiftId}";
                var ObjectResponse = await ShiftClient.PutAsJsonAsync(ShiftUrl, new ShiftDto
                {
                    workerId = UpdatedShift.workerId,
                    shiftStartTime = UpdatedShift.shiftStartTime,
                    shiftEndTime = UpdatedShift.shiftEndTime,
                    shiftDate= UpdatedShift.shiftDate
                });
                var ResponseStream=await ObjectResponse.Content.ReadAsStreamAsync();
                ResponseDto<Shift> UpdatedResponse = await JsonSerializer.DeserializeAsync < ResponseDto<Shift>>(ResponseStream);
                return UpdatedResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
