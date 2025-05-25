using ShiftsLoggerUI.Model;
using ShiftsLoggerUI.Services;
using Spectre.Console;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ShiftsLoggerUI
{
    public class UserInterface
    {
        private readonly IShiftService Shiftservice;
        public UserInterface(IShiftService _service)
        {
            Shiftservice = _service;
        }
        public void MainMenu()
        {
            var userOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Please select an option")
                .AddChoices(["Manage Shifts", "Manage Workers"])
                );

            switch (userOption)
            {
                case "Manage Shifts":
                    ShiftServiceMenu();
                    break;
                case "Manage Workers":
                    break;
            }
        }
        public void ShiftServiceMenu()
        {
            var userOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Please select an option")
                .AddChoices(["ViewAllShifts", "View a single Shift", "Delete a shift", "Create a new Shift", "Update a Shift"])
                );

            switch (userOption)
            {
                case "ViewAllShifts":
                    Shiftservice.GetAllShifts();
                    break;
                case "View a single Shift":
                    break;
                case "Delete a shift":
                    break;
                case "Create a new Shift":
                    break;
                case "Update a Shift":
                    break;
            }
        }
        public static void ShowResponse<T>(ResponseDto<T> response)
        {
            if (response.IsSuccess)
            {
                Panel Messagepanel = new Panel($"[aqua] {response.Message}[/]");
                Messagepanel.Header = new PanelHeader("[green3_1] Response Message:[/]");
                Messagepanel.Border = BoxBorder.Double;
                Messagepanel.Padding = new Padding(2, 2, 2, 2);
                AnsiConsole.Write(Messagepanel);
                Messagepanel.Expand = true;
                ICollection ResponseObjects = (ICollection)response.Data;
                if(ResponseObjects.Count==0)
                {
                    Panel EmptyMessagepanel = new Panel($"[darkseagreen1]No Data To Show!!![/]");
                    return;
                }
                Table ResponseTable = new();
                PropertyInfo[] props = null;
                Type ElementType = GetElementType(typeof(T));
                if (ElementType == typeof(Shift))
                {
                    props = typeof(Shift).GetProperties();
                }
                if (ElementType == typeof(Worker))
                {
                    props = typeof(Worker).GetProperties();
                }
                var columnValues = new List<string>();
                foreach(var prop in props)
                {
                    columnValues.Add(prop.Name.ToString());
                }
                ResponseTable.AddColumns(columnValues.ToArray());
                foreach (var obj in ResponseObjects)
                {
                    var RowValues = new List<string>();
                    foreach (var prop in props)
                    {
                        RowValues.Add(prop.GetValue(obj).ToString());
                    }
                    ResponseTable.AddRow(RowValues.ToArray());
                }
                ResponseTable.Title = new TableTitle("[orange3] Here is the Retrieved Data[/]");
                ResponseTable.Border(TableBorder.AsciiDoubleHead);
                AnsiConsole.Write(ResponseTable);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Not Implemented Yet!!!");
                Console.ReadLine();
            }
        }
        public static Type GetElementType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                return type.GetGenericArguments()[0];
            }

            // Case 2: T is an array (e.g., Shift[])
            if (type.IsArray)
            {
                return type.GetElementType();
            }

            // Case 3: T is already the element type (e.g., T = Shift)
            return type;
        }
    }
}
