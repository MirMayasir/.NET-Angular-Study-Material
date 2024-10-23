using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProgram3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Test case 1
            string s1 = "barfoothefoobarman";
            string[] words1 = { "foo", "bar" };
            var matcher1 = new StringMatcher(words1);
            var indices1 = matcher1.FindConcatenatedSequences(s1);
            Console.WriteLine("Test Case 1 - Starting indices: " + string.Join(", ", indices1));
            Console.WriteLine("Test Case 1 - Is 'barfoo' a concatenated string? " + matcher1.IsConcatenatedString("barfoo"));

            // Save and Load word list
            string filePath = "words.txt";
            matcher1.SaveWordListToFile(filePath);
            Console.WriteLine("Word list saved to file.");

            var matcher2 = new StringMatcher(new string[] { });
            matcher2.LoadWordListFromFile(filePath);
            Console.WriteLine("Word list loaded from file.");

            // Test case 2
            string s2 = "wordgoodgoodgoodbestword";
            string[] words2 = { "word", "good", "best", "word" };
            var matcher3 = new StringMatcher(words2);
            var indices2 = matcher3.FindConcatenatedSequences(s2);
            Console.WriteLine("Test Case 2 - Starting indices: " + string.Join(", ", indices2));

            // Test case 3
            string s3 = "barfoofoobarthefoobarman";
            string[] words3 = { "bar", "foo", "the" };
            var matcher4 = new StringMatcher(words3);
            var indices3 = matcher4.FindConcatenatedSequences(s3);
            Console.WriteLine("Test Case 3 - Starting indices: " + string.Join(", ", indices3));
        }
    }

}
