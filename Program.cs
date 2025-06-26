using System;
using System.ComponentModel;
using System.Data.Common;

namespace HelloWorld
{
    class TaskItem
    {
        public int Id {get; set;}
        public string Desc {get; set;} = "New Empty Task";
        public bool IsDone {get; set;} = false;
    }

    class TaskManager
    {
        public TaskManager()
        {
            read();
        }

        private const string fileName = "todo.json";
        private List<TaskItem> tasks = new();

        int id;
        public void add (string desc){
            id = tasks.Count != 0 ? tasks.Max(tasks => tasks.Id) : 1;
            tasks.Add(new TaskItem {Id = id , Desc = desc});
            write();
        }

        public void done () {}
        public void list () {
            if (tasks.Count == 0){
                Console.WriteLine("The ToDo is empty!");
            }else
            {
                Console.WriteLine("Id\tIsDone\tDescription");
                foreach (var t in tasks){
                    Console.WriteLine(t.Id + "\t" + t.IsDone + "\t" + t.Desc);
                } 
            }
        }
        public void delete (int id) {
            tasks.RemoveAll(t => t.Id == id);
            write();
        }

        private void read () {}
        private void write () {}
    }
}
