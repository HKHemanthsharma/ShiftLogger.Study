using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsLoggerUI
{
    public class UserInputs
    {
        public static int InputId()
        {
           int UserInput=AnsiConsole.Ask<int>("[paleturquoise1]Please enter the Id[/]");
            return UserInput;
        }
    }
}
