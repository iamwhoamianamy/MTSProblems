using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        //... custom application code
    }

    static void TransformToElephant()
    {
        Console.Write("Слон");

        Thread currentThread = Thread.CurrentThread;
        Thread newThread = new(() =>
            {
                try
                {
                    currentThread.Join();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Пиво");
                }
            });

        newThread.Start();
        newThread.Join();

        Console.SetOut(null);
    }

    static int Help()
    {
        return 0;
    }
}