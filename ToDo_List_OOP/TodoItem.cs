using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_OOP
{
    [System.Serializable]
    class TodoItem
    {
        public string title
        {
            get;
            set;
        }

        // Maximal length of the title
        public static int maxTitleLength = 50;

        public int priority
        {
            get;
            set;
        }

        public enum status
        {
            None,
            In_Progress,
            Stuck,
            Finished
        }

        public string description
        {
            get;
            set;
        }

        // Maximal length of the description
        public static int maxDescLength = 200;

        // Turns true if todo gets archived
        public bool isArchived = false;
    }
}
