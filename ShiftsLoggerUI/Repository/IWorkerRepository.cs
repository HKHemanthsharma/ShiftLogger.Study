using ShiftsLoggerUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShiftsLoggerUI.Repository
{
    public interface IWorkerRepository
    {
        public Task<ResponseDto<List<Worker>>> GetAllWorker();
        public Task<ResponseDto<List<Worker>>> GetSingleWorker(int Id);
        public Task<ResponseDto<Worker>> CreateWorker(Worker NewsWorker);
        public Task<ResponseDto<Worker>> DeleteWorker(int Id);
        public Task<ResponseDto<Worker>> UpdateWorker(int Id, Worker worker);
    }
    public class WorkerRepository : IWorkerRepository
    {
        private readonly IMyHttpClient client;
        public WorkerRepository(IMyHttpClient _client)
        {
            client = _client;
        }
        public async Task<ResponseDto<Worker>> CreateWorker(Worker NewsWorker)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<Worker>> DeleteWorker(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<Worker>>> GetAllWorker()
        {
            try
            {
                HttpClient WorkerClient = client.GetClient();
                string BaseUrl = client.GetBaseUrl() + "Worker";
                using (Stream stream = await WorkerClient.GetStreamAsync(BaseUrl))
                {
                    ResponseDto<List<Worker>> ObjectResponse = await JsonSerializer.DeserializeAsync<ResponseDto<List<Worker>>>(stream);
                    return ObjectResponse;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<ResponseDto<List<Worker>>> GetSingleWorker(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<Worker>> UpdateWorker(int Id, Worker worker)
        {
            throw new NotImplementedException();
        }
    }
}
