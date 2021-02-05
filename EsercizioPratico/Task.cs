using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EsercizioPratico
{
    public class Task
    {
        public string Descrizione { get; set; }
        public string DataScadenza { get; set; }
        public string LivelloImportanza { get; set; }

        
        enum Livello
        {
            Basso,
            Medio,
            Alto
        }


        public static string path { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Task.txt");

        //Creazione File
        public static void CreazioneTesto()
        {
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "EsercizioTask"));

            directory.Create();
            Console.WriteLine("Directory creata correttamente");
            //Creazione file
            string path = Path.Combine(directory.FullName, "Task.txt");
            using (StreamWriter file = File.CreateText(path))
            {
                file.WriteLine("Descrizione, DataScadenza, LivelloImportanza");
            }
        }


        //Lettura dei task inseriti nel file
            public static Task[] LetturaTask()
        {

            int totalLine = File.ReadLines(path).Count();
            string line;
            Task[] tasks = new Task[totalLine - 1];

            // Lettura File
            using (StreamReader reader = File.OpenText(path))
            {
                // salvo la riga di intestazione
                string header = reader.ReadLine();

                for (int i = 0; i < totalLine - 1; i++)
                {
                    line = reader.ReadLine();
                    string[] dataTask = line.Split(",");

                    Task task = new Task
                    {
                        Descrizione = dataTask[0],
                        DataScadenza = dataTask[1],
                        LivelloImportanza = dataTask[2]
                    };

                    tasks[i] = task;
                }
            }

            return tasks;

        }

        //Vedere i task inseriti a console
        public static void VedereTaskInseriti()
        {
            Task[] taskInseriti = Task.LetturaTask();

            foreach (Task t in taskInseriti)
            {
                Console.WriteLine(t.Descrizione + " " + t.DataScadenza + " " + t.LivelloImportanza);
            }

        }

        public static void AgguingereTask()
        {
            try
            {
                Task[] tasks = Task.LetturaTask();
                string[] taskList = new string[3];

                Console.WriteLine("Aggiungi una nuova task:");
                Console.WriteLine("Descrizione:");
                taskList[0] = Console.ReadLine();
                Console.WriteLine("DataScadenza: giorno/mese/anno");
                taskList[1] = Console.ReadLine();
                Console.WriteLine("Livello importanza: 1 basso, 2 medio o 3 alto");
                char a = Console.ReadKey().KeyChar;

                switch (a)
                {
                    case '1':
                        Livello x = Livello.Basso;
                        taskList[2] = Convert.ToString(x);
                        break;
                    case '2':
                        Livello y = Livello.Medio;
                        taskList[2] = Convert.ToString(y);
                        break;
                    case '3':
                        Livello z = Livello.Alto;
                        taskList[2] = Convert.ToString(z);
                        break;
                    default:
                        Console.WriteLine("Non è disponibile!");
                        break;
                }
                //taskList[2] = Console.ReadLine();

                Task nuovaTask = new Task
                {
                    Descrizione = taskList[0],
                    DataScadenza = taskList[1],
                    LivelloImportanza = taskList[2]
                };

                using (StreamWriter writer = File.AppendText(path)) //scrive alla fine del file
                        {
                            writer.Write("\n");
                            writer.WriteLine(nuovaTask.Descrizione + "," + nuovaTask.DataScadenza + "," + nuovaTask.LivelloImportanza);
                        }
                        Console.WriteLine("Task registrata correttamente");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }


        public static void EliminareTask(Task task)
        {
            Task[] tasks = Task.LetturaTask();
            ArrayList taskList = new ArrayList();

            foreach (Task t in tasks)
            {
                if (t.Descrizione != task.Descrizione)
                {
                    taskList.Add(t);
                }
            }

            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("Descrizione, DataScadenza, LivelloImportanza");
                    foreach (Task t in taskList)
                    {
                        writer.WriteLine(t.Descrizione + "," + t.DataScadenza + "," + t.LivelloImportanza);
                    }

                }
                Console.WriteLine("Task eliminata correttamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void FiltrareTaskImportanza()
        {
            Task[] taskInseriti = Task.LetturaTask();
            ArrayList taskList = new ArrayList();

            foreach (Task t in taskInseriti)
            {
                if (t.LivelloImportanza == "alto")
                {
                    taskList.Add(t);
                }
            }

            foreach (Task t in taskInseriti)
            {
                if (t.LivelloImportanza == "medio")
                {
                    taskList.Add(t);
                }
            }

            foreach (Task t in taskInseriti)
            {
                if (t.LivelloImportanza == "basso")
                {
                    taskList.Add(t);
                }
            }


            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("Descrizione, DataScadenza, LivelloImportanza");
                    foreach (Task t in taskList)
                    {
                        writer.WriteLine(t.Descrizione + "," + t.DataScadenza + "," + t.LivelloImportanza);
                    }

                }
                Console.WriteLine("Task eliminata correttamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public static void ScritturaFile(Task [] taskList)
        {
            CreazioneTesto();
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("Descrizione, DataScadenza, LivelloImportanza");
                    foreach (Task t in taskList)
                    {
                        writer.WriteLine(t.Descrizione + "," + t.DataScadenza + "," + t.LivelloImportanza);
                    }

                }
                Console.WriteLine("Task inserita correttamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static Task [] CreazioneTask(int n)
        {
            Task[] task = new Task[] { };

            for (int i = 0; i < n; i++)
            {
                string[] taskList = new string[3];
                Console.WriteLine("Descrizione:");
                taskList[0] = Console.ReadLine();
                Console.WriteLine("DataScadenza: giorno/mese/anno");
                taskList[1] = Console.ReadLine();
                Console.WriteLine("Livello importanza: 1 basso, 2 medio o 3 alto");
                char a = Console.ReadKey().KeyChar;

                switch (a)
                {
                    case '1':
                        Livello x = Livello.Basso;
                        taskList[2] = Convert.ToString(x);
                        break;
                    case '2':
                        Livello y = Livello.Medio;
                        taskList[2] = Convert.ToString(y);
                        break;
                    case '3':
                        Livello z = Livello.Alto;
                        taskList[2] = Convert.ToString(z);
                        break;
                    default:
                        Console.WriteLine("Non è disponibile!");
                        break;

                }
                Task nuovaTask = new Task
                {
                    Descrizione = taskList[0],
                    DataScadenza = taskList[1],
                    LivelloImportanza = taskList[2]
                };
                task[i] = nuovaTask;
            }

            return task;
            

        }
    }
}
