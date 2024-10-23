using System;
using System.Linq;

public class LexicographicalSorter
{
    
    public string[] SortLexicographically(int[] arr)
    {
        
        return arr.Select(x => x.ToString())
                  .OrderBy(x => x)
                  .ToArray();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        LexicographicalSorter sorter = new LexicographicalSorter();

        // Test case 1
        int[] arr1 = { 1, 15, 4 };
        Console.WriteLine("Test Case 1 Input: [1, 15, 4]");
        string[] sortedArr1 = sorter.SortLexicographically(arr1);
        Console.WriteLine("Expected Output: [1, 15, 4]");
        Console.WriteLine("Actual Output: " + string.Join(", ", sortedArr1));
        Console.WriteLine();

        // Test case 2
        int[] arr2 = { 10, 2, 5 };
        Console.WriteLine("Test Case 2 Input: [10, 2, 5]");
        string[] sortedArr2 = sorter.SortLexicographically(arr2);
        Console.WriteLine("Expected Output: [10, 2, 5]");
        Console.WriteLine("Actual Output: " + string.Join(", ", sortedArr2));
        Console.WriteLine();

        // Test case 3
        int[] arr3 = { 12, 32, 5, 21 };
        Console.WriteLine("Test Case 3 Input: [12, 32, 5, 21]");
        string[] sortedArr3 = sorter.SortLexicographically(arr3);
        Console.WriteLine("Expected Output: [12, 21, 32, 5]");
        Console.WriteLine("Actual Output: " + string.Join(", ", sortedArr3));
        Console.WriteLine();

        // Taking user input
        Console.WriteLine("Now enter your own numbers separated by spaces:");
        string input = Console.ReadLine();

        // Convert input string to an integer array
        int[] userArr = input.Split(' ').Select(int.Parse).ToArray();

        // Sort the user input lexicographically
        string[] sortedUserArr = sorter.SortLexicographically(userArr);

        // Display the sorted result
        Console.WriteLine("Lexicographically sorted array:");
        Console.WriteLine(string.Join(", ", sortedUserArr));
    }
}
