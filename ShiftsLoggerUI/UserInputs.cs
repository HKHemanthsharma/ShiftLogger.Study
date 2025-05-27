using ShiftsLoggerUI.Model;
using ShiftsLoggerUI.Repository;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ShiftsLoggerUI
{
    public class UserInputs
    {
        private readonly IWorkerRepository _repository;

        public UserInputs(IWorkerRepository repo)
        {
            _repository = repo;
        }

        public int InputId()
        {
            return AnsiConsole.Ask<int>("[paleturquoise1]Please enter the Id[/]");
        }

        public async Task<Shift> GetNewShift()
        {
            string startTime = AnsiConsole.Ask<string>("Enter the StartTime of shift in 'HH:mm format'");
            while (!validations.validateTime(startTime))
            {
                startTime = AnsiConsole.Ask<string>("Wrong format!!! Enter the StartTime of shift in 'HH:mm format'");
            }

            string endTime = AnsiConsole.Ask<string>("Enter the EndTime of shift in 'HH:mm format'");
            while (!validations.validateTime(endTime))
            {
                endTime = AnsiConsole.Ask<string>("Wrong format!!! Enter the EndTime of shift in 'HH:mm format'");
            }

            string shiftDate = AnsiConsole.Ask<string>("Enter the Date of shift in 'dd:MM:yyyy' format or leave it empty for today's Date:");
            if (!string.IsNullOrEmpty(shiftDate))
            {
                while (!validations.validateDate(shiftDate))
                {
                    shiftDate = AnsiConsole.Ask<string>("Wrong input!!! Enter the Date of shift in 'dd-MM-yyyy' format or leave it empty for today's Date:");
                }
            }

            var workersResponse = await _repository.GetAllWorker();
            List<Worker> workers = workersResponse.Data.ToList();
            List<string> workerNames = workers.Select(x => x.Name).ToList();

            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select the Worker")
                    .AddChoices(workerNames));

            var chosenWorkerId = workers.First(x => x.Name == userChoice).WorkerId;

            return new Shift
            {
                workerId = chosenWorkerId,  
                shiftStartTime = startTime,
                shiftEndTime = endTime,
                shiftDate = shiftDate
            };
        }
    }
}
