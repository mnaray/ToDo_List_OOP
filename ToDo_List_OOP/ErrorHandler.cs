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
                    Program.HelpMenu();
                    break;

                case 2:
                    Console.WriteLine("You can not enter an empty value here. Please try something else.");
                    break;

                default:
                    Console.WriteLine("We don't know what went wrong.");
                    Program.ShortHelp();
                    break;
            }
        }
    }
}
