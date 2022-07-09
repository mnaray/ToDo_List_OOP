using System;
using System.Linq;

namespace ToDo_List_OOP
{
    class Program
    {
        // Public variables
        public static TodoList todoList = new TodoList();
        public static bool exit = false;
        public static string version = "0.1.0";
        static void Main(string[] args)
        {
            // Local variables

            // Main application

            //for (int i = 0; i < 3; i++)
            //{
            //    TodoItem todoItem = new TodoItem();

            //    todoItem.title = $"title {i}";
            //    todoItem.priority = 0;
            //    todoItem.description = $"This is a rather short description for {todoItem.title}.";

            //    todoList.todoItemsList.Add(todoItem);
            //}

            Introduction();

            while (!exit)
            {
                // Commandhandler checks for input and processes it
                Console.Write("Enter command: ");
                CommandHandler.Listen();
            }
        }


        // Methods and Functions

        public static bool ConfirmMinLength(TodoList todoList)
        {
            if (todoList.todoItemsList.Count() < 1)
            {
                ErrorHandler.Error(5);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckIfTitleExists(TodoList todoList, string titleToCheck)
        {
            foreach (TodoItem item in todoList.todoItemsList)
            {
                if (item.title == titleToCheck)
                {
                    return true;
                }
            }

            return false;
        }

        public static void Introduction()
        {
            Console.WriteLine("This application is to manage your list of things to do. " +
                "It should help you manage to keep an eye over it, without having to worry " +
                "about forgetting anything important.\n");
            ShortHelp();
        }

        public static void ShortHelp()
        {
            Console.WriteLine("\n*** To get a list of commands you can use, type \"help\" into the command line. ***\n");
        }

        public static void HelpMenu()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine($"These are all the commands you can use in version {version} of the application:\n");
            Console.WriteLine("exit                     to close the application");
            Console.WriteLine("clear                    clear the console, remove all text");
            Console.WriteLine("add todo                 add a new todo");
            Console.WriteLine("ls                       list all of your active todos, with ascending priority");
            Console.WriteLine("description              display the description of a todo");
            Console.WriteLine("rm                       remove a todo from the list (without archiving)");
            Console.WriteLine("edit                     display the editing menu");
            Console.WriteLine("-----------\nCommands coming soon:");
            Console.WriteLine("archive                  archive a todo after you're done with it");
            Console.WriteLine("ls archive               list all archived todos");
            Console.WriteLine("save                     save the current state of your todo list locally");
            Console.WriteLine("---------------------------------------------------------------------------------------\n");
        }

        public static void AddTodo()
        {
            TodoItem todoItem = new TodoItem();

            while (true)
            {
                int errorCode = 0;

                try
                {
                    Console.Write($"Enter the title (max. {TodoItem.maxTitleLength} characters) of new todo here: ");
                    todoItem.title = Console.ReadLine();

                    if (todoItem.title.Length > TodoItem.maxTitleLength)
                    {
                        errorCode = 4;
                        throw new Exception();
                    }
                    else if (CheckIfTitleExists(todoList, todoItem.title))
                    {
                        errorCode = 6;
                        throw new Exception();
                    }
                    else if (todoItem.title == "")
                    {
                        errorCode = 2;
                        throw new Exception();
                    }

                    break;
                }
                catch (Exception)
                {
                    ErrorHandler.Error(errorCode);
                }
            }

            Console.WriteLine("Enter the priority of your todo:\n");
            while (true)
            {
                try
                {
                    int i = 0;
                    foreach (var item in Enum.GetValues(typeof(TodoItem.priorityEnum)))
                    {
                        Console.WriteLine(i + ") " + item.ToString());
                        i++;
                    }

                    Console.Write("\nEnter the number of the priority here: ");
                    todoItem.priority = Convert.ToInt32(Console.ReadLine());
                    if (!Enum.IsDefined(typeof(TodoItem.priorityEnum), todoItem.priority))
                    {
                        throw new Exception();
                    }

                    break;
                }
                catch (Exception)
                {
                    ErrorHandler.Error(3);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write($"Enter the description (max. {TodoItem.maxDescLength} characters) of your new todo: ");

                    todoItem.description = Console.ReadLine();

                    if (todoItem.description.Length > TodoItem.maxDescLength)
                    {
                        throw new Exception();
                    }

                    break;
                }
                catch (Exception)
                {
                    ErrorHandler.Error(4);
                }
            }

            // Adds new todo item to the list of todos
            Program.todoList.todoItemsList.Add(todoItem);
            Console.WriteLine("Successfully added new todo.\n");
        }

        public static void ListAll()
        {
            string line = "\n-----------------------------------------------------------------\n";
            foreach (TodoItem item in todoList.todoItemsList)
            {
                Console.WriteLine(line);
                Console.WriteLine($"Title:          {item.title}");
                Console.WriteLine($"Priority:       {Enum.GetName(typeof(TodoItem.priorityEnum), item.priority)}");
                Console.WriteLine($"Description:    {item.description}");
            }
            Console.WriteLine(line);
        }

        public static void PrintDescription()
        {
            while (ConfirmMinLength(todoList))
            {
                string input = "";
                bool foundTodo = false;
                try
                {
                    Console.Write("Enter the name of the todo you would like to see the descrption of: ");
                    input = Console.ReadLine();

                    TodoItem selectedTodo = new TodoItem();

                    foreach (TodoItem item in todoList.todoItemsList)
                    {
                        if (item.title == input)
                        {
                            selectedTodo = item;
                            foundTodo = true;
                        }
                    }

                    if (foundTodo == false)
                    {
                        throw new Exception();
                    }

                    Console.WriteLine($"\nTitle: {selectedTodo.title}");
                    Console.WriteLine($"Description:\n{selectedTodo.description}\n");

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

        public static void RemoveTodo()
        {
            while (ConfirmMinLength(todoList))
            {
                string input = "";
                bool foundTodo = false;
                try
                {
                    Console.Write("Enter the title of the todo you would like to remove here: ");
                    input = Console.ReadLine();

                    TodoItem selectedTodo = new TodoItem();

                    foreach (TodoItem item in todoList.todoItemsList)
                    {
                        if (item.title == input)
                        {
                            selectedTodo = item;
                            foundTodo = true;
                        }
                    }

                    if (foundTodo == false)
                    {
                        throw new Exception();
                    }

                    Console.Write("Are you sure you want to delete this todo forever? [y|n] : ");
                    string confirmInput = Console.ReadLine();
                    while (true)
                    {
                        try
                        {
                            switch (confirmInput)
                            {
                                case "y":
                                case "yes":
                                    todoList.todoItemsList.Remove(selectedTodo);
                                    Console.WriteLine("Successfully removed todo.\n");
                                    break;

                                case "n":
                                case "no":
                                    Console.WriteLine("Did not remove todo.\n");
                                    break;

                                default:
                                    throw new Exception();
                            }

                            break;
                        }
                        catch (Exception)
                        {
                            ErrorHandler.Error(3);
                        }
                    }

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
    }
}
