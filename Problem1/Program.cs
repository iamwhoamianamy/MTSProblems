using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess(2);
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
                var processes = Process.GetProcessesByName("Problem1");
                foreach (var process in processes)
                {
                    process.Kill();
                    process.Dispose();
                }
                break;
            }
            case 2:
            {
                var currentProcess = Process.GetProcessById(Process.GetCurrentProcess().Id);
                currentProcess.Kill();
                currentProcess.Dispose();
                break;
            }
            default:
            {
                break;
            }
        }

    }
}