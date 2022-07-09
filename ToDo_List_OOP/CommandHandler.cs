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

            // commands for normal mode
            if (!Editor.editingModeOn)
            {
                switch (input)
                {
                    case "help":
                        Program.HelpMenu();
                        break;

                    case "exit":
                        Program.exit = true;
                        break;

                    case "add todo":
                        Program.AddTodo();
                        break;

                    case "description":
                        Program.PrintDescription();
                        break;

                    case "rm":
                        Program.RemoveTodo();
                        break;

                    case "editor":
                        Editor.Edit();
                        break;

                    default:
                        ErrorHandler.Error(1);
                        break;
                }
            }

            // commands for edit mode only
            else if (Editor.editingModeOn)
            {
                switch (input)
                {
                    case "help":
                        Editor.EditorInstructions();
                        break;

                    case "exit":
                        Editor.editingModeOn = false;
                        break;

                    default:
                        break;
                }
            }

            // commands working in both modes
            switch (input)
            {
                case "ls":
                    Program.ListAll();
                    break;

                case "clear":
                    Console.Clear();
                    break;

                default:
                    break;
            }

        }
    }
}
