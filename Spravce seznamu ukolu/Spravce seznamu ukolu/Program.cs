using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Spravce_seznamu_ukolu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Task> ukol = LoadTasksFromFile("tasks.csv");

            while (true)
            {
                Console.WriteLine("Správce seznamu úkolů");
                Console.WriteLine("1. Přidat úkol");
                Console.WriteLine("2. Zobrazit úkoly");
                Console.WriteLine("3. Zobrazit nevyřízené úkoly");
                Console.WriteLine("4. Označit úkol jako dokončený");
                Console.WriteLine("5. Ukončit program");
                Console.Write("Zvolte akci: ");

                string vyber = Console.ReadLine();

                switch (vyber)
                {
                    case "1":
                        Console.Write("Zadejte název úkolu: ");
                        string taskName = Console.ReadLine();
                        ukol.Add(new Task(taskName));
                        break;

                    case "2":
                        ShowTasks(ukol);
                        break;

                    case "3":
                        ShowIncompleteTasks(ukol); 
                        break;

                    case "4":
                        Console.Write("Zadejte ID úkolu k označení jako dokončený: ");
                        if (int.TryParse(Console.ReadLine(), out int taskId))
                        {
                            MarkTaskAsCompleted(ukol, taskId);
                        }
                        else
                        {
                            Console.WriteLine("Neplatný vstup. Zadejte číslo.");
                        }
                        break;

                    case "5":
                        SaveTasksToFile("tasks.csv", ukol);
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Neplatná volba. Zvolte platnou akci.");
                        break;
                }
            }
        }

        static List<Task> LoadTasksFromFile(string filename)
        {
            List<Task> tasks = new List<Task>();
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        bool isCompleted = bool.Parse(parts[2]);
                        tasks.Add(new Task(id, name, isCompleted));
                    }
                }
            }
            return tasks;
        }

        static void SaveTasksToFile(string filename, List<Task> tasks)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Task task in tasks)
                {
                    writer.WriteLine($"{task.Id},{task.Name},{task.IsCompleted}");
                }
            }
        }

        static void ShowTasks(List<Task> tasks)
        {
            Console.WriteLine("Seznam všech úkolů:");
            foreach (Task task in tasks)
            {
                Console.WriteLine($"{task.Id}. [{(task.IsCompleted ? "x" : " ")}] {task.Name}");
            }
        }

        static void ShowIncompleteTasks(List<Task> tasks)
        {
            Console.WriteLine("Seznam nevyřízených úkolů:");
            foreach (Task task in tasks)
            {
                if (!task.IsCompleted)
                {
                    Console.WriteLine($"{task.Id}. [{(task.IsCompleted ? "x" : " ")}] {task.Name}");
                }
            }
        }

        static void MarkTaskAsCompleted(List<Task> tasks, int taskId)
        {
            Task task = tasks.Find(t => t.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
            }
            else
            {
                Console.WriteLine("Úkol nebyl nalezen.");
            }
        }
    }

    class Task
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        private static int nextId = 1;

        public Task(string name)
        {
            Id = nextId++;
            Name = name;
            IsCompleted = false;
        }

        public Task(int id, string name, bool isCompleted)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
            if (id >= nextId)
            {
                nextId = id + 1;
            }
        }
    }
}
