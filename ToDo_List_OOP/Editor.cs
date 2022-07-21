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

        public static void EditTodo()
        {
            while (Program.ConfirmMinLength(Program.todoList))
            {
                string input = "";
                TodoItem selectedTodo = new TodoItem();
                try
                {
                    Console.Write("Enter title of todo you would like to edit: ");
                    input = Console.ReadLine();

                    // todo: optimize this section!
                    // don't make it loop twice, looking
                    // for the same thing in the same list

                    if (!Program.CheckTitleExistance(Program.todoList, input))
                    {
                        throw new Exception();
                    }

                    foreach (TodoItem item in Program.todoList.todoItemsList)
                    {
                        if (item.title == input)
                        {
                            selectedTodo = item;
                        }
                    }

                    EditTitle(selectedTodo);
                    EditPriority(selectedTodo);
                    EditDescription(selectedTodo);

                    break;
                }
                catch (Exception)
                {
                    if (input == "")
                    {
                        ErrorHandler.Error(2);
                    }
                    else
                    {
                        ErrorHandler.Error(3);
                    }
                }
            }
        }
        static void EditTitle(TodoItem selectedTodo)
        {
            while (true)
            {
                string input = "";
                try
                {
                    Console.Write($"\nCurrent title:  {selectedTodo.title}\n");
                    Console.Write($"New title:      ");
                    input = Console.ReadLine();

                    if (input == "")
                    {
                        throw new Exception();
                    }

                    selectedTodo.title = input;

                    Console.WriteLine("Successfully changed title.\n");

                    break;
                }
                catch (Exception)
                {
                    if (input == "")
                    {
                        ErrorHandler.Error(2);
                    }
                    else
                    {
                        ErrorHandler.Error(6);
                    }
                }
            }
        }

        static void EditPriority(TodoItem selectedTodo)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"\nCurrent priority:  {selectedTodo.priority}\n");

                    int i = 0;
                    foreach (var item in Enum.GetValues(typeof(TodoItem.priorityEnum)))
                    {
                        Console.WriteLine(i + ") " + item.ToString());
                        i++;
                    }

                    Console.Write("\nEnter the number of the  new priority here: ");
                    selectedTodo.priority = Convert.ToInt32(Console.ReadLine());
                    if (!Enum.IsDefined(typeof(TodoItem.priorityEnum), selectedTodo.priority))
                    {
                        throw new Exception();
                    }

                    Console.WriteLine("Successfully changed priority.\n");

                    break;
                }
                catch (Exception)
                {
                    ErrorHandler.Error(3);
                }
            }
        }

        static void EditDescription(TodoItem selectedTodo)
        {
            while (true)
            {
                string input = "";
                try
                {
                    Console.Write($"\nCurrent description:\n{selectedTodo.description}\n");
                    Console.Write($"\nNew description (leave empty to keep old one):\n");
                    input = Console.ReadLine();

                    if (input == "")
                    {
                        Console.WriteLine("Left description as it is.\n");
                        break;
                    }

                    if (input.Length > TodoItem.maxDescLength)
                    {
                        throw new Exception();
                    }

                    selectedTodo.description = input;

                    if (input != "")
                    {
                        Console.WriteLine("Successfully changed description.\n");
                    }

                    break;
                }
                catch (Exception)
                {
                    ErrorHandler.Error(4);
                }
            }
        }
    }
}
