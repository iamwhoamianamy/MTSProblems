using System;

public static class Problem3
{
    /// <summary>
    /// <para> Отсчитать несколько элементов с конца </para>
    /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
    /// </summary> 
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
    /// <returns></returns>
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        if (tailLength is not null)
        {
            int count = enumerable.Count();
            int i = count - 1;

            foreach (var item in enumerable)
            {
                yield return ((item, (i < tailLength) ? i : null));
                i--;
            }
        }
        else
        {
            foreach (var item in enumerable)
            {
                yield return (item, null);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var values = new List<int>() { 1, 2, 3, 4, 5, 6 };

        foreach (var item in values.EnumerateFromTail(3))
        {
            Console.WriteLine(item);
        }

        foreach (var item in values.EnumerateFromTail(null))
        {
            Console.WriteLine(item);
        }
    }
}