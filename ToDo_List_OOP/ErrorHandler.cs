using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_OOP
{
    class ErrorHandler
    {
        // Properties

        
        // Methods

        public static void Error(int code)
        {
            // This method gives instructions or hints to the user, if something went wrong.

            switch (code)
            {
                case 1:
                    Console.WriteLine("There is no command like that, try something from the list of commands!");
                    Program.ShortHelp();
                    break;

                case 2:
                    Console.WriteLine("You can not enter an empty value here. Please try something else.\n");
                    break;

                case 3:
                    Console.WriteLine("Your input is out of the range of possible inputs.\n");
                    break;

                case 4:
                    Console.WriteLine("You input is too long. Keep the length under the limit.\n");
                    break;

                case 5:
                    Console.WriteLine("Not enough todos for this action.\n");
                    break;

                case 6:
                    Console.WriteLine("This todo already exists.");
                    break;

                default:
                    Console.WriteLine("We don't know what went wrong.\n");
                    Program.ShortHelp();
                    break;
            }
        }
    }
}
