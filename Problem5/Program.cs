using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        //... custom application code
        Console.WriteLine("Рыба");
        Console.WriteLine("Муха");
    }

    static void TransformToElephant()
    {
        Console.WriteLine("Слон");
        Console.SetOut(new MyConsoleWriter());
    }

    public class MyConsoleWriter : StringWriter
    {
        TextWriter consoleOut = Console.Out;
        bool writeText = false;

        public override void WriteLine(string? str)
        {
            if(writeText == false)
            {
                writeText = true;
            }
            else
            {
                Console.SetOut(consoleOut);
                Console.WriteLine(str);
            }
        }
    }
}