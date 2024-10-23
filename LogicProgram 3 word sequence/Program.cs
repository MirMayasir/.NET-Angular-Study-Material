
using System;
using System.Collections.Generic;
using System.IO;
namespace LogicProgram3
{
    public class StringMatcher
    {
        private string[] _words;
        private int _wordLength;
        private int _concatLength;

        // Constructor to initialize the StringMatcher with a list of words
        public StringMatcher(string[] words)
        {
            _words = words;
            if (words.Length > 0)
            {
                _wordLength = words[0].Length;
                _concatLength = _wordLength * words.Length;
            }
            else
            {
                _wordLength = 0;
                _concatLength = 0;
            }
        }

        // Method to find starting indices of concatenated sequences in the string
        public List<int> FindConcatenatedSequences(string s)
        {
            var result = new List<int>();

            if (s.Length == 0 || _words.Length == 0 || s.Length < _concatLength)
                return result;

            var wordCount = new Dictionary<string, int>();
            foreach (var word in _words)
            {
                if (!wordCount.ContainsKey(word))
                    wordCount[word] = 0;
                wordCount[word]++;
            }

            for (int i = 0; i <= s.Length - _concatLength; i++)
            {
                var seenWords = new Dictionary<string, int>();
                int j = 0;

                while (j < _words.Length)
                {
                    int wordStart = i + j * _wordLength;
                    string word = s.Substring(wordStart, _wordLength);

                    if (!wordCount.ContainsKey(word))
                        break;

                    if (!seenWords.ContainsKey(word))
                        seenWords[word] = 0;
                    seenWords[word]++;

                    if (seenWords[word] > wordCount[word])
                        break;

                    j++;
                }

                if (j == _words.Length)
                    result.Add(i);
            }

            return result;
        }

        // Method to save the word list to a file
        public void SaveWordListToFile(string filePath)
        {
            try
            {
                File.WriteAllLines(filePath, _words);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving word list: " + ex.Message);
            }
        }

        // Method to load the word list from a file
        public void LoadWordListFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    _words = File.ReadAllLines(filePath);
                    _wordLength = _words.Length > 0 ? _words[0].Length : 0;
                    _concatLength = _wordLength * _words.Length;
                }
                else
                {
                    throw new FileNotFoundException("The specified file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading word list: " + ex.Message);
            }
        }

        // Method to check if a string is a valid concatenated string
        public bool IsConcatenatedString(string s)
        {
            return s.Length == _concatLength && FindConcatenatedSequences(s).Count > 0;
        }
    }
}