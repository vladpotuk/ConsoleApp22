using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5, 5, 6, 6, 7, 8, 8, 9, 9, 9 };
        CountArrayElements(array);

        // Завдання 2: Підрахунок елементів у масиві, менших за введене користувачем число
        Console.WriteLine("Введіть число:");
        int threshold = int.Parse(Console.ReadLine());
        CountValuesLessThanThreshold(array, threshold);

        // Завдання 3: Підрахунок кількості разів послідовності трьох чисел у масиві
        Console.WriteLine("Введіть три числа через пробіл:");
        int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] arrayForSequence = { 7, 6, 5, 3, 4, 7, 6, 5, 8, 7, 6, 5 };
        CountSequenceOccurrences(arrayForSequence, sequence);

        // Завдання 4: Знаходження загальних елементів у двох масивах без повторень
        int[] array1 = { 1, 2, 3, 4, 5 };
        int[] array2 = { 4, 5, 6, 7, 8 };
        FindCommonElements(array1, array2);

        // Завдання 5: Пошук мінімального і максимального значення у двовимірному масиві
        int[,] twoDimArray = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        FindMinMax(twoDimArray);

        // Завдання 6: Підрахунок кількості слів у введеному реченні
        Console.WriteLine("Введіть речення:");
        string sentence = Console.ReadLine();
        CountWords(sentence);

        // Завдання 7: Перевертання кожного слова у введеному реченні
        Console.WriteLine("Введіть речення:");
        string sentenceToReverse = Console.ReadLine();
        ReverseWordsInSentence(sentenceToReverse);

        // Завдання 8: Підрахунок кількості голосних літер у реченні
        Console.WriteLine("Введіть речення:");
        string text = Console.ReadLine();
        CountVowels(text);

        // Завдання 9: Підрахунок кількості входжень підрядка в рядок
        Console.WriteLine("Введіть рядок:");
        string inputString = Console.ReadLine();
        Console.WriteLine("Введіть слово для пошуку:");
        string searchString = Console.ReadLine();
        CountSubstringOccurrences(inputString, searchString);
    }

    // Завдання 1
    static void CountArrayElements(int[] array)
    {
        int evenCount = array.Count(x => x % 2 == 0);
        int oddCount = array.Count(x => x % 2 != 0);
        int uniqueCount = array.Distinct().Count();

        Console.WriteLine($"Парних: {evenCount}, Непарних: {oddCount}, Унікальних: {uniqueCount}");
    }

    // Завдання 2
    static void CountValuesLessThanThreshold(int[] array, int threshold)
    {
        int count = array.Count(x => x < threshold);
        Console.WriteLine($"Кількість значень менших за {threshold}: {count}");
    }

    // Завдання 3
    static void CountSequenceOccurrences(int[] array, int[] sequence)
    {
        int count = 0;
        for (int i = 0; i <= array.Length - sequence.Length; i++)
        {
            if (array[i] == sequence[0] && array[i + 1] == sequence[1] && array[i + 2] == sequence[2])
                count++;
        }
        Console.WriteLine($"Кількість повторень послідовності: {count}");
    }

    // Завдання 4
    static void FindCommonElements(int[] array1, int[] array2)
    {
        var commonElements = array1.Intersect(array2).ToArray();
        Console.WriteLine("Загальні елементи у перших двох масивах:");
        foreach (var element in commonElements)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    // Завдання 5
    static void FindMinMax(int[,] array)
    {
        int min = array[0, 0];
        int max = array[0, 0];
        foreach (int element in array)
        {
            if (element < min)
                min = element;
            if (element > max)
                max = element;
        }
        Console.WriteLine($"Мінімальне значення: {min}, Максимальне значення: {max}");
    }

    // Завдання 6
    static void CountWords(string sentence)
    {
        string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine($"Кількість слів у реченні: {words.Length}");
    }

    // Завдання 7
    static void ReverseWordsInSentence(string sentence)
    {
        string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            char[] charArray = words[i].ToCharArray();
            Array.Reverse(charArray);
            words[i] = new string(charArray);
        }
        Console.WriteLine("Після перевороту:");
        Console.WriteLine(string.Join(" ", words));
    }

    // Завдання 8
    static void CountVowels(string text)
    {
        int vowelCount = text.Count(c => "aeiouAEIOU".Contains(c));
        Console.WriteLine($"Кількість голосних літер у реченні: {vowelCount}");
    }

    // Завдання 9
    static void CountSubstringOccurrences(string inputString, string searchString)
    {
        int count = 0;
        int index = inputString.IndexOf(searchString, StringComparison.OrdinalIgnoreCase);
        while (index != -1)
        {
            count++;
            index = inputString.IndexOf(searchString, index + 1, StringComparison.OrdinalIgnoreCase);
        }
        Console.WriteLine($"Кількість входжень підрядка у рядок: {count}");
    }
}
