using System;

namespace EsercizioPratico
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task();

          
            Console.WriteLine("Aggiungi una nuova task");
            //Task[] nuovaTask= Task.CreazioneTask(1);
            //Task.ScritturaFile(nuovaTask);

            //Task.LetturaTask();
            //Task.VedereTaskInseriti();

            Task.AgguingereTask();
            
            //Task.EliminareTask(task);
        }
    }
}
