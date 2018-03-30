using System;
using System.Diagnostics;
using System.Threading;


namespace portugol_runtime
{
    class Program
    {

        private static void portugolrun(String filepath)
        {
            Console.WriteLine("Iniciando Portugol...");
            Process proc = new Process();  
            ProcessStartInfo startInfo = new ProcessStartInfo();  
            //startInfo.Arguments = @"-cp C:\ Test C:\test.txt";  
            startInfo.FileName = "python";  
            proc.StartInfo = startInfo;
            new Thread(() => 
            {
                Thread.CurrentThread.IsBackground = true; 
                Thread.Sleep(1000);
                if(!proc.WaitForExit(5000))
                { 
                    proc.Kill();
                    Console.WriteLine("\nERRO >> Você demorou demais para responder (timeout)");
                    Thread.CurrentThread.Interrupt();
                }
            }).Start();
            proc.Start();
            proc.WaitForExit();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Portugol Runtime...");
            while (true)
            {
                var comando = Console.ReadLine();
                if (comando.Contains("~|^!+RUNTIME+!^|~"))
                {
                    Console.WriteLine("~|^!+START+!^|~");
                    portugolrun(comando.Replace("~|^!+START+!^|~", ""));
                    Console.WriteLine("~|^!+END+!^|~");
                }
            }
        }
    }
}
