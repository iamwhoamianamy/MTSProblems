using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess(1);
        }
        catch { }

        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    static void FailProcess(int wayToFail)
    {
        switch (wayToFail)
        {
            case 0:
            {
                Process.GetCurrentProcess().Kill();
                Process.GetCurrentProcess().Dispose();
                break;
            }
            case 1:
            {
                var workers = Process.GetProcessesByName("Problem1");
                foreach (var worker in workers)
                {
                    worker.Kill();
                    worker.Dispose();
                }
                break;
            }
            default:
            {
                break;
            }
        }

    }
}