using System;
using System.ComponentModel;
using System.Data.Common;
using System.Reflection.Metadata;

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
            ReadFile();
        }

        private const string fileName = "todo.json";
        private List<TaskItem> tasks = new();

        int id;
        public void Add (string desc){
            id = tasks.Count != 0 ? tasks.Max(tasks => tasks.Id) : 1;
            if (desc == "null"){
                Console.WriteLine("No description Provied, Createing New Empty Task");
                tasks.Add(new TaskItem { Id = id });
            }else{
                //Console.WriteLine("task = " + desc);
                tasks.Add(new TaskItem {Id = id , Desc = desc});
            }
            WriteFile();
            Console.WriteLine("Task added successfully.");
        }

        public void Done (int id) {
            foreach (var item in tasks)
            {
                if (item.Id == id){
                    if (item.IsDone == true){
                        Console.WriteLine("The Task is already marked as Done!");
                    }else
                    {
                        item.IsDone = true;
                        WriteFile();
                        Console.WriteLine("Item has been marked Done.");
                    }
                }
            }
        }
        public void List () {
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
        public void Delete (int id) {
            tasks.RemoveAll(t => t.Id == id);
            WriteFile();
        }

        private void ReadFile () {}
        private void WriteFile () {}
    }

    class Program
    {
        static public void Main(string[] args){
            var taskmanager = new TaskManager();
            if (args.Length == 0){
                Console.WriteLine("ToDo app\nUsage: list , add , done , delete");
            }else{
            switch (args[0].ToLower())
            {
                case "add":
                    Console.Write("Enter the description of the task : ");
                    string desc = Console.ReadLine() ?? "";
                    desc = string.IsNullOrEmpty(desc) ? "null" : desc;
                    //Console.WriteLine(desc);
                    taskmanager.Add(desc);
                    break;
                
                case "list":
                    taskmanager.List();
                    break;

                case "done":
                    Console.Write("Enter the Id of the completed task : ");
                    int done_id = Convert.ToInt32(Console.ReadLine());
                    taskmanager.Done(done_id);
                    break;

                case "delete":
                    Console.Write("Enter the Id of the task to be deleted : ");
                    int del_id = Convert.ToInt32(Console.ReadLine());
                    taskmanager.Delete(del_id);
                    break;
                
                default:
                    Console.WriteLine("Unknown Comand");
                    break;
            }
            }

        }
    }
}
