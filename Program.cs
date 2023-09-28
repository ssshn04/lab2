using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    class lab2
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("\nChoose the task (1-10 || 0 - for exit): ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye!");
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine("-------Task 1-------");
                        Task1();
                        break;
                    case 2:
                        Console.WriteLine("-------Task 2-------");
                        Task2();
                        break;
                    case 3:
                        Console.WriteLine("-------Task 3-------");
                        Task3();
                        break;
                    case 4:
                        Console.WriteLine("-------Task 4-------");
                        Task4();
                        break;
                    case 5:
                        Console.WriteLine("-------Task 5-------");
                        Task5();
                        break;
                    case 6:
                        Console.WriteLine("-------Task 6-------");
                        Task6();
                        break;
                    case 7:
                        Console.WriteLine("-------Task 7-------");
                        Task7();
                        break;
                    case 8:
                        Console.WriteLine("-------Task 8-------");
                        Task8();
                        break;
                    case 9:
                        Console.WriteLine("-------Task 9-------");
                        Task9();
                        break;
                    case 10:
                        Console.WriteLine("-------Task 10-------");
                        Task10();
                        break;
                    default:
                        Console.WriteLine("Wrong command. Try again.");
                        break;
                }
            }
        }
        static void Task1()
        {
            Console.Write("Enter the first string of words: ");
            string input1 = Console.ReadLine();

            Console.Write("Enter the second string of words: ");
            string input2 = Console.ReadLine();

            string[] words1 = input1.Split(' ');
            string[] words2 = input2.Split(' ');

            int maxLength = Math.Min(words1.Length, words2.Length);
            int commonStartLength = 0;
            int commonEndLength = 0;

            for (int i = 0; i < maxLength; i++)
            {
                if (words1[i] == words2[i])
                {
                    commonStartLength++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= maxLength; i++)
            {
                if (words1[words1.Length - i] == words2[words2.Length - i])
                {
                    commonEndLength++;
                }
                else
                {
                    break;
                }
            }

            int commonLength = commonStartLength + commonEndLength;

            Console.WriteLine("Length of the largest common substring: " + commonLength);
        }

        static void Task2()
        {
            Console.Write("Enter the array of integers (space-separated): ");
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Console.Write("Enter the number of right rotations (k): ");
            int k = int.Parse(Console.ReadLine());

            int n = numbers.Length;
            int[] sum = new int[n];

            for (int r = 1; r <= k; r++)
            {
                int[] rotated = new int[n];

                for (int i = 0; i < n; i++)
                {
                    int newPosition = (i + 1) % n;
                    rotated[newPosition] = numbers[i];
                }

                numbers = rotated;

                Console.Write("After " + r + " rotation(s): ");
                foreach (int num in rotated)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();

                for (int i = 0; i < n; i++)
                {
                    sum[i] += rotated[i];
                }
            }

            Console.WriteLine("Sum of obtained arrays after each rotation:");
            foreach (int s in sum)
            {
                Console.Write(s + " ");
            }
        }
        static void Task3()
        {
            Console.Write("Enter 4*k integers: ");
            string[] numbers = Console.ReadLine().Split(' ');

            int k = numbers.Length / 4;

            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                array[i] = int.Parse(numbers[i]);
            }

            int[] foldedArray = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                foldedArray[i] = array[k - i - 1] + array[k + i];
                foldedArray[k + i] = array[3 * k - i - 1] + array[3 * k + i];
            }

            Console.WriteLine("Folded and summed array:");
            Console.WriteLine(string.Join(" ", foldedArray));
        }
        static void Task4()
        {
            Console.Write("Enter the value of n: ");
            int n = int.Parse(Console.ReadLine());

            bool[] primes = new bool[n + 1];

            for (int i = 2; i <= n; i++)
            {
                primes[i] = true;
            }

            for (int p = 2; p * p <= n; p++)
            {
                if (primes[p])
                {
                    for (int i = p * p; i <= n; i += p)
                    {
                        primes[i] = false;
                    }
                }
            }


            for (int i = 2; i <= n; i++)
            {
                if (primes[i])
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Task5()
        {
            Console.Write("Enter the first char array: ");
            char[] array1 = Console.ReadLine().ToCharArray();

            Console.Write("Enter the second char array: ");
            char[] array2 = Console.ReadLine().ToCharArray();

            int minLength = Math.Min(array1.Length, array2.Length);

            Console.Write("Alphabetical Order: ");

            for (int i = 0; i < minLength; i++)
            {
                if (array1[i] != array2[i])
                {
                    Console.WriteLine(array1[i] < array2[i] ? array1 : array2);
                    Console.WriteLine(array1[i] < array2[i] ? array2 : array1);
                    return;
                }
            }

            if (array1.Length != array2.Length)
            {
                Console.WriteLine(array1.Length < array2.Length ? array1 : array2);
                Console.WriteLine(array1.Length < array2.Length ? array2 : array1);
            }
            else
            {
                Console.WriteLine("Both arrays are equal.");
            }
        }

        static void Task6()
        {
            Console.Write("Enter integers separated by spaces: ");
            string input = Console.ReadLine();
            string[] inputArray = input.Split(' ');

            int start = 0;
            int len = 1;
            int bestStart = 0;
            int bestLen = 1;

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] == inputArray[i - 1])
                {
                    len++;

                    if (len > bestLen)
                    {
                        bestLen = len;
                        bestStart = start;
                    }
                }
                else
                {
                    start = i;
                    len = 1;
                }
            }

            string[] longestSequence = new string[bestLen];
            Array.Copy(inputArray, bestStart, longestSequence, 0, bestLen);
            Console.WriteLine($"Longest sequence: {string.Join(" ", longestSequence)}");
        }
        static void Task7()
        {
            Console.Write("Enter integers separated by spaces: ");
            string input = Console.ReadLine();
            string[] inputArray = input.Split(' ');

            int start = 0;
            int len = 1;
            int bestStart = 0;
            int bestLen = 1;

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] == inputArray[i - 1])
                {
                    len++;

                    if (len > bestLen)
                    {
                        bestLen = len;
                        bestStart = start;
                    }
                }
                else
                {
                    start = i;
                    len = 1;
                }
            }

            for (int i = bestStart; i < bestStart + bestLen; i++)
                Console.Write(inputArray[i] + " ");
        }

        static void Task8()
        {
            Console.Write("Enter a sequence of numbers separated by spaces: ");
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            int mostFrequentNumber = numbers[0];
            int maxFrequency = 1;

            foreach (int number in numbers)
            {
                if (frequencyMap.TryGetValue(number, out int frequency))
                {
                    frequencyMap[number] = ++frequency;
                }
                else
                {
                    frequencyMap[number] = 1;
                }

                if (frequency > maxFrequency || (frequency == maxFrequency && number < mostFrequentNumber))
                {
                    mostFrequentNumber = number;
                    maxFrequency = frequency;
                }
            }

            Console.WriteLine($"Most frequent number: {mostFrequentNumber}");
        }

        static void Task9()
        {
            char[] alphabet = new char[26];
            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = (char)('a' + i);
            }

            Console.Write("Enter a lowercase word: ");
            string word = Console.ReadLine();

            Console.WriteLine("Indices of letters in the alphabet:");
            foreach (char letter in word)
            {
                int index = Array.IndexOf(alphabet, letter);
                Console.WriteLine($"{letter} -> {index}");
            }
        }

        static void Task10()
        {
            Console.Write("Enter the sequence of numbers separated by spaces: ");
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.Write("Enter the difference: ");
            int difference = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (Math.Abs(numbers[i] - numbers[j]) == difference)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine($"Number of pairs with a difference of {difference}: {count}");
        }
    }
}
