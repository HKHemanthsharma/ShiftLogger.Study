﻿using Microsoft.Extensions.Configuration;
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
        private readonly IWorkerRepository Workerrepository;
        private readonly IShiftRepository  Shiftrepository;

        public UserInputs(IWorkerRepository repo, IShiftRepository Shiftrepo)
        {
            Workerrepository = repo;
            Shiftrepository = Shiftrepo;
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

            string shiftDate = AnsiConsole.Ask<string>("Enter the Date of shift in 'dd-MM-yyyy' format or leave it empty for today's Date:");
            if (!string.IsNullOrEmpty(shiftDate))
            {
                while (!validations.validateDate(shiftDate))
                {
                    shiftDate = AnsiConsole.Ask<string>("Wrong input!!! Enter the Date of shift in 'dd-MM-yyyy' format or leave it empty for today's Date:");
                }
            }

            var workersResponse = await Workerrepository.GetAllWorker();
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
        public async Task<Shift> SelectShift()
        {
            var ShiftResponse = await Shiftrepository.GetAllShifts();
            List<Shift> Shifts = (List<Shift>)ShiftResponse.Data;
            List<string> ShiftNames = Shifts.Select(x => $"{x.shiftId}:{x.workerId}:{x.shiftDate}:{x.shiftStartTime}:{x.shiftEndTime}").ToList();
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select the Worker")
                    .AddChoices(ShiftNames));
            int SelectedShiftId = int.Parse(userChoice.Split(":")[0]);
            return Shifts.Where(x => x.shiftId == SelectedShiftId).FirstOrDefault();
        }
        public async Task<Shift> GetUpdateShift(Shift updatedShift)
        {
            UserInterface.ShowShift(updatedShift);
            var confirm= AnsiConsole.Prompt( new ConfirmationPrompt("Do you want to Change WorkerId"));
            if(confirm)
            {
                var workersResponse = await Workerrepository.GetAllWorker();
                List<Worker> workers = workersResponse.Data.ToList();
                List<string> workerNames = workers.Select(x => x.Name).ToList();

                var userChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Please select the Worker")
                        .AddChoices(workerNames));

                var chosenWorkerId = workers.First(x => x.Name == userChoice).WorkerId;
            }
            confirm = AnsiConsole.Prompt(new ConfirmationPrompt("Do you want to Change StartTime of Shift?"));
            if(confirm)
            {
                string startTime = AnsiConsole.Ask<string>("Enter the StartTime of shift in 'HH:mm format'");
                while (!validations.validateTime(startTime))
                {
                    startTime = AnsiConsole.Ask<string>("Wrong format!!! Enter the StartTime of shift in 'HH:mm format'");
                }
                updatedShift.shiftStartTime = startTime;
            }
            updatedShift.shiftStartTime=DateTime.Parse(updatedShift.shiftStartTime).ToString("HH:mm");
            confirm = AnsiConsole.Prompt(new ConfirmationPrompt("Do you want to Change EndTime of Shift?"));
            if (confirm)
            {
                string EndTime = AnsiConsole.Ask<string>("Enter the EndTime of shift in 'HH:mm format'");
                while (!validations.validateTime(EndTime))
                {
                    EndTime = AnsiConsole.Ask<string>("Wrong format!!! Enter the EndTime of shift in 'HH:mm format'");
                }
                updatedShift.shiftEndTime = EndTime;
            }
            updatedShift.shiftEndTime = DateTime.Parse(updatedShift.shiftEndTime).ToString("HH:mm");
            confirm = AnsiConsole.Prompt(new ConfirmationPrompt("Do you want to Change Date of Shift?"));
            if (confirm)
            {
                string shiftDate = AnsiConsole.Ask<string>("Enter the Date of shift in 'dd-MM-yyyy' format or leave it empty for today's Date:");
                if (!string.IsNullOrEmpty(shiftDate))
                {
                    while (!validations.validateDate(shiftDate))
                    {
                        shiftDate = AnsiConsole.Ask<string>("Wrong input!!! Enter the Date of shift in 'dd-MM-yyyy' format or leave it empty for today's Date:");
                    }
                }
                updatedShift.shiftDate = shiftDate;
            }
            updatedShift.shiftDate = DateTime.Parse(updatedShift.shiftDate).ToString("dd-MM-yyyy");
            return updatedShift;
        }
    }
}
