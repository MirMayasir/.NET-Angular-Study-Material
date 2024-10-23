using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Problem1
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 2, 3, 4, 5, 1, 6, 4 };

            int duplicateCount = CountDuplicates(array);

            Console.WriteLine("Total number of duplicate elements: " + duplicateCount);
        }
        static int CountDuplicates(int[] array)
        {
            Dictionary<int, int> elementCounts = new Dictionary<int, int>();
            int duplicates = 0;

            foreach (int element in array)
            {
                if (elementCounts.ContainsKey(element))
                {
                    elementCounts[element]++;
                }
                else
                {
                    elementCounts[element] = 1;
                }
            }

            foreach (KeyValuePair<int, int> kvp in elementCounts)
            {
                if (kvp.Value > 1)
                {
                    duplicates++;
                }
            }

            return duplicates;
        }
    }
}
