using ShiftsLoggerUI.Model;
using ShiftsLoggerUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsLoggerUI.Services
{
    public interface IWorkerService
    {
        public void GetAllWorkers();
        public void GetSingleWorker();
        public void CreateWorker();
        public void DeleteWorker();
        public void UpdateWorker();

    }
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository repository;
        private readonly UserInputs Uinp;
        public WorkerService(IWorkerRepository _repository, UserInputs ui)
        {
            repository = _repository;
            Uinp = ui;
        }
        public void CreateWorker()
        {
            throw new NotImplementedException();
        }

        public void DeleteWorker()
        {
            throw new NotImplementedException();
        }

        public void GetAllWorkers()
        {
            ResponseDto<List<Worker>> workers = repository.GetAllWorker().GetAwaiter().GetResult();
            UserInterface.ShowResponse(workers);
        }

        public void GetSingleWorker()
        {
            throw new NotImplementedException();
        }

        public void UpdateWorker()
        {
            throw new NotImplementedException();
        }
    }
}
