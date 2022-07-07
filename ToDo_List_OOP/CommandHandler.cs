using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_OOP
{
    class CommandHandler
    {
        // Properties


        // Methods

        public static void Listen()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "help":
                    Program.HelpMenu();
                    break;

                case "exit":
                    Program.exit = true;
                    break;

                case "clear":
                    Console.Clear();
                    break;

                case "add todo":
                    Program.AddTodo();
                    break;

                case "ls":
                    Program.ListAll();
                    break;

                case "description":
                    Program.PrintDescription();
                    break;

                default:
                    ErrorHandler.Error(1);
                    break;
            }
        }
    }
}
