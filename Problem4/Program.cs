class Program
{
    /// <summary>
    /// Возвращает отсортированный по возрастанию поток чисел
    /// </summary>
    /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
    /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
    /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
    /// <returns>Отсортированный по возрастанию поток чисел.</returns>
    /// <remarks>Известно, что потребители метода зачастую не будут вычитывать данные до конца</remarks>
    static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();

        foreach (var number in inputStream)
        {
            if(counts.ContainsKey(number))
            {
                counts[number]++;
            }
            else
            {
                counts.Add(number, 1);
            }

            for (int i = 0; i < number - sortFactor; i++)
            {
                if(counts.ContainsKey(i))
                {
                    while (counts[i] != 0)
                    {
                        counts[i]--;
                        yield return i;
                    }

                    counts.Remove(i);
                }

            }
        }

        maxValue++;
        for (int i = maxValue - sortFactor - 1; i < maxValue; i++)
        {
            if (counts.ContainsKey(i))
            {
                while (counts[i] != 0)
                {
                    counts[i]--;
                    yield return i;
                }

                counts.Remove(i);
            }
        }
    }

    static void Main(string[] args)
    {
        //var list = new List<int>() { 2, 4, 3, 3, 7, 6, 8, 7 };
        var list = new List<int>() { 2, 4, 1, 2, 7, 5, 8, 5 };

        foreach (var number in Sort(list, 3, list.Max()))
        {
            if(number < 50)
            {
                Console.Write(number + " ");
            }
            else
            {
                break;
            }
        }
    }
}