using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShiftsLoggerUI.Repository;
using ShiftsLoggerUI.Services;

namespace ShiftsLoggerUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddScoped<UserInterface>();
                    services.AddScoped<IShiftService, ShiftService>();
                    services.AddScoped<IShiftRepository, ShiftRepostory>();
                    services.AddScoped<IMyHttpClient, MyHttpClient>();
                    services.AddScoped<IWorkerService, WorkerService>();
                    services.AddScoped<IWorkerRepository, WorkerRepository>();
                    services.AddScoped<UserInputs>();
                }).Build();
            var scope = host.Services.CreateScope();
            var serviceprovider = scope.ServiceProvider;
            var ui = serviceprovider.GetRequiredService<UserInterface>();
            ui.MainMenu();
        }
    }
}
