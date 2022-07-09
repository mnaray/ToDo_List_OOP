using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_OOP
{
    class Editor
    {
        // Properties
        public static bool editingModeOn = false;

        // Methods

        public static void Edit()
        {
            editingModeOn = true;
            EditorInstructions();

            while (editingModeOn)
            {
                Console.Write("Enter editor command: ");
                CommandHandler.Listen();
            }
        }

        public static void EditorInstructions()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine($"These are all the commands you can use in the editor:\n");
            Console.WriteLine("exit                     exit the editor");
            Console.WriteLine("clear                    clear the console, remove all text");
            Console.WriteLine("edit                     edit a todo");
            Console.WriteLine("ls                       list all of your active todos, with descending priority");
            Console.WriteLine("help                     display the editing commands");
            Console.WriteLine("---------------------------------------------------------------------------------------\n");
        }
    }
}
