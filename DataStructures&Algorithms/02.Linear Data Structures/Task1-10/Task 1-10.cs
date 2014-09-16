using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    class Homeworks1
    {
        public static Random rnd = new Random();

        public static List<int> GetUserInput(int count, int min, int max)
        {
            string inputString;
            int inputInt;
            List<int> inputs = new List<int>();

            Console.WriteLine("Enter 'random' for autogeneration of values");
            while (true)
            {
                Console.Write("Enter a integer number (hit 'Enter' for end): ");
                inputString = Console.ReadLine();
                if (inputString == "random")
                {
                    Console.WriteLine("Input array:");
                    int generatedNumber;
                    for (int i = 1; i < count; i++)
                    {
                        generatedNumber = rnd.Next(min, max);
                        Console.Write(generatedNumber + ", ");
                        inputs.Add(generatedNumber);
                    }

                    Console.WriteLine();
                    break;
                }

                if (String.IsNullOrWhiteSpace(inputString))
                {
                    break;
                }

                if (int.TryParse(inputString, out inputInt))
                {
                    inputs.Add(inputInt);
                }
            }

            return inputs;
        }

        // Method for Task 4
        static List<int> FindLongestSubsequence(List<int> inputList)
        {
            if (inputList == null || inputList.Count == 0)
            {
                return new List<int>();
            }

            int longestSubsequenceSoFar = 1;
            int LongestSubsequenceStart = 0;
            int currentSubsequenceLenght = 1;
            int currentSubsequenceStart = 0;

            for (int i = 1; i < inputList.Count; i++)
            {
                if (inputList[i] == inputList[currentSubsequenceStart])
                {
                    currentSubsequenceLenght++;
                }
                else
                {
                    if (currentSubsequenceLenght > longestSubsequenceSoFar)
                    {
                        longestSubsequenceSoFar = currentSubsequenceLenght;
                        LongestSubsequenceStart = currentSubsequenceStart;
                    }
                    currentSubsequenceStart = i;
                    currentSubsequenceLenght = 1;
                }
            }
            if (currentSubsequenceLenght > longestSubsequenceSoFar)
            {
                longestSubsequenceSoFar = currentSubsequenceLenght;
                LongestSubsequenceStart = currentSubsequenceStart;
            }
            List<int> result = inputList.GetRange(LongestSubsequenceStart, longestSubsequenceSoFar);
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Task 1: Write a program that reads from the console a sequence of positive integer numbers. " +
            "The sequence ends when empty line is entered. Calculate and print the sum and average of the " +
            "elements of the sequence. Keep the sequence in List<int>.");

            List<int> inputs = GetUserInput(20, 0, 100);

            Console.WriteLine("Sum of element in list is {0}", inputs.Sum());
            if (inputs.Count > 0)
            {
                Console.WriteLine("Average of elements is {0}", inputs.Average());
            }

            Console.WriteLine();
            Console.WriteLine("Task 1 complete. Press 'Enter' to proceed to task 2");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Task 2: Write a program that reads N integers from the console and reverses them using a stack. " +
                "Use the Stack<int> class.");
            Stack<int> theStack = new Stack<int>(GetUserInput(20, 0, 100));

            Console.WriteLine("Elements in reversed order:");
            while (theStack.Count > 0)
            {
                Console.Write(theStack.Pop() + ", ");
            }

            Console.WriteLine();
            Console.WriteLine("Task 2 complete. Press 'Enter' to proceed to task 3");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Task 3: Write a program that reads a sequence of integers (List<int>) ending with an empty line " +
                "and sorts them in an increasing order. ");

            inputs = GetUserInput(20, 0, 100);
            int currentElement;
            Console.WriteLine("Processing:");
            for (int i = 1; i < inputs.Count; i++)
            {
                currentElement = i - 1;
                if (inputs[i] < inputs[currentElement])
                {
                    while (currentElement >= 0 && inputs[i] < inputs[currentElement])
                    {
                        currentElement--;
                    }
                    for (int j = 0; j <= i; j++)
                    {
                        if (j == currentElement + 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\\/ ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (j == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        Console.Write(inputs[j] + ", ");
                    }
                    Console.WriteLine();

                    inputs.Insert(currentElement + 1, inputs[i]);
                    inputs.RemoveAt(i + 1);
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("List sorted by increasing order: ");
            Console.WriteLine(String.Join(", ", inputs));

            Console.WriteLine();
            Console.WriteLine("Task 3 complete. Press 'Enter' to proceed to task 4");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Task 4: Write a method that finds the longest subsequence of equal numbers in given List<int> " +
                "and returns the result as new List<int>. Write a program to test whether the method works correctly.");

            inputs = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("Testing method with list of nonrepeating symbols (must return 1): ");
            Console.WriteLine("Return result = 1? {0}", FindLongestSubsequence(inputs).Count == 1);
            Console.WriteLine();

            inputs = new List<int>(new int[] { 1, 1, 1, 2, 3, 4, 5 });
            Console.WriteLine("Testing method with repeating symbols at start(must return 3): ");
            Console.WriteLine("Return result = 3? {0}", FindLongestSubsequence(inputs).Count == 3);
            Console.WriteLine();

            inputs = new List<int>(new int[] { 1, 2, 3, 4, 5, 5, 5, 5 });
            Console.WriteLine("Testing method with repeating symbols at end(must return 4): ");
            Console.WriteLine("Return result = 4? {0}", FindLongestSubsequence(inputs).Count == 4);
            Console.WriteLine();

            inputs = new List<int>(new int[] { 1, 2, 3, 3, 3, 4, 5 });
            Console.WriteLine("Testing method with repeating symbols at middle(must return 3): ");
            Console.WriteLine("Return result = 3? {0}", FindLongestSubsequence(inputs).Count == 3);
            Console.WriteLine();

            inputs = new List<int>();
            Console.WriteLine("Testing method with empty list: ");
            Console.WriteLine("Return result = 0? {0}", FindLongestSubsequence(inputs).Count == 0);
            Console.WriteLine();

            inputs = null;
            Console.WriteLine("Testing method with null as list: ");
            Console.WriteLine("Return result = 0? {0}", FindLongestSubsequence(inputs).Count == 0);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Task 4 complete. Press 'Enter' to proceed to task 5");
            Console.ReadLine();
            Console.Clear();
            // Yes, I know that I must create test unit, but ... no time for this. Sorry.

            Console.WriteLine("Task 5: Write a program that removes from given sequence all negative numbers.");

            inputs = GetUserInput(20, -50, 50);
            Console.WriteLine();

            // using delegate function
            inputs.RemoveAll(
                delegate(int item)
                {
                    return item < 0;
                }
                );

            Console.WriteLine("List with negative elements removed: ");
            Console.WriteLine(String.Join(", ", inputs));
            Console.WriteLine();
            Console.WriteLine("Task 5 complete. Press 'Enter' to proceed to task 6");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Task 6: Write a program that removes from given sequence all numbers that occur odd number of times.");
            inputs = GetUserInput(20, 0, 10);

            Console.WriteLine();
            Console.WriteLine("Removed items: ");
            for (int i = 0; i < inputs.Count; i++)
            {
                // let's this time make finding with lambda expression
                if (inputs.FindAll(item => item == inputs[i]).Count % 2 == 1)
                {
                    int valueToRemove = inputs[i];
                    Console.Write(valueToRemove + " - ");
                    int removedItems = inputs.RemoveAll(item => item == valueToRemove);
                    Console.WriteLine(removedItems + " times");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Result: ");
            Console.WriteLine(String.Join(", ", inputs));
            Console.WriteLine();
            Console.WriteLine("Task 6 complete. Press 'Enter' to proceed to task 7");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Task 7: Write a program that finds in given array of integers " +
                "(all belonging to the range [0..1000]) how many times each of them occurs.");
            inputs = GetUserInput(10000, 0, 1000);
            int[] counters = new int[1000];

            for (int i = 0; i < inputs.Count; i++)
            {
                counters[inputs[i]]++;
            }
            for (int i = 0; i < counters.Length; i++)
            {
                if (counters[i] > 0)
                {
                    Console.WriteLine("Number {0} is found {1} times.", i, counters[i]);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Task 7 complete. Press 'Enter' to proceed to task 8");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Task 8: * The majorant of an array of size N is a value " +
                "that occurs in it at least N/2 + 1 times. Write a program to find the majorant of given array (if exists). ");
            inputs = new List<int>(new int[] { 1, 5, 2, 5, 5, 5, 1, 3, 4, 5, 5, 5, 7, 5, 5 });
            counters = new int[10];
            Console.WriteLine("Input array: ");
            Console.WriteLine(String.Join(", ", inputs));
            for (int i = 0; i < inputs.Count; i++)
            {
                counters[inputs[i]]++;
            }
            bool majorantExist = false;
            for (int i = 0; i < counters.Length; i++)
            {
                if (counters[i] > inputs.Count / 2)
                {
                    majorantExist = true;
                    Console.WriteLine("Majornat found - {0}. Occured {1} times.", i, counters[i]);
                    break;
                }
            }
            if (!majorantExist)
            {
                Console.WriteLine("Majorant not found.");
            }

            Console.WriteLine();
            Console.WriteLine("Task 8 complete. Press 'Enter' to proceed to task 9");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Task 9: We are given the following sequence: \nS1 = N;\nS2 = S1 + 1;\nS3 = 2*S1 + 1;\nS4 = S1 + 2;" +
                "\nS5 = S2 + 1;\nS6 = 2*S2 + 1;\nS7 = S2 + 2;\n...\nUsing the Queue<T> class write a program to print its first 50 members for given N." +
                "Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...");

            Queue<int> queue = new Queue<int>();
            Console.Write("Enter first element in queue (integer number): ");
            string inputString = Console.ReadLine();
            int queueElement;
            if (!int.TryParse(inputString, out queueElement))
            {
                queueElement = 2;
            }
            queue.Enqueue(queueElement);
            int printedElements = 0;
            while (printedElements < 50)
            {
                queueElement = queue.Dequeue();
                Console.Write(queueElement + ", ");
                queue.Enqueue(queueElement + 1);
                queue.Enqueue(2 * queueElement + 1);
                queue.Enqueue(queueElement + 2);
                printedElements++;
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Task 9 complete. Press 'Enter' to proceed to task 10");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Task 10:  We are given numbers N and M and the following operations:\nN = N+1\n" +
                "N = N+2\nN = N*2\nWrite a program that finds the shortest sequence of operations from the list " +
                "above that starts from N and finishes in M. Hint: use a queue.\nExample: N = 5, M = 16\n" +
                "Sequence: 5  7  8  16");

            Console.Write("Enter N: ");
            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Assuming N = 2");
                n = 2;
            }
            Console.Write("Enter M: ");
            int m;
            if (!int.TryParse(Console.ReadLine(), out m))
            {
                Console.WriteLine("Assuming M = 199");
                m = 199;
            }
            Console.WriteLine("Please be patient, this can take a while.");
            Queue<List<int>> listQueue = new Queue<List<int>>();
            List<int> queueNode = new List<int>();
            queueNode.Add(n);
            long counter = 0;
            listQueue.Enqueue(queueNode);
            List<int> newNode;
            while (true)
            {
                counter++;
                // 137 is a "magic number" - if I print all numbers this will take too long, so I print 1 time on every 37 
                // calculations. This make a illusion that every single calculation is printed. 
                // U can use "100" for example, but ... that's not so cool :) U can remove this output at all to increase speed
                if (counter % 137 == 0)
                {
                    Console.Write("\r"+counter + " combinations checked");
                }
                queueNode = listQueue.Dequeue();
                int result = queueNode.Last();
                if (result + 1 == m)
                {
                    newNode = new List<int>(queueNode);
                    newNode.Add(result + 1);
//                    Console.WriteLine(String.Join(", ", newNode));
                    break;
                }
                else if (result + 1 < m)
                {
                    newNode = new List<int>(queueNode);
                    newNode.Add(result + 1);
                    listQueue.Enqueue(newNode);
                }

                if (result + 2 == m)
                {
                    newNode = new List<int>(queueNode);
                    newNode.Add(result + 2);
//                    Console.WriteLine(String.Join(", ", newNode));
                    break;
                }
                else if (result + 2 < m)
                {
                    newNode = new List<int>(queueNode);
                    newNode.Add(result + 2);
                    listQueue.Enqueue(newNode);
                }

                if (result * 2 == m)
                {
                    newNode = new List<int>(queueNode);
                    newNode.Add(result * 2);
//                    Console.WriteLine(String.Join(", ", newNode));
                    break;
                }
                else if (result * 2 < m)
                {
                    newNode = new List<int>(queueNode);
                    newNode.Add(result * 2);
                    listQueue.Enqueue(newNode);
                }
            }
            Console.WriteLine();
            Console.Write("Shortest sequence: ");
            Console.WriteLine(String.Join(", ", newNode));

            Console.WriteLine();
            Console.WriteLine("Task 10 complete.");
        }
    }
}
