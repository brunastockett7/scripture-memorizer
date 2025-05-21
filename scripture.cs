using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string scriptureText)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] wordArray = scriptureText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
        }

        public void Display()
        {
            Console.WriteLine(_reference.ToString());
            Console.WriteLine();

            string displayedText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            Console.WriteLine(displayedText);
        }

        public void HideWords(int count)
        {
            Random rnd = new Random();

            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            int toHide = Math.Min(count, visibleWords.Count);

            for (int i = 0; i < toHide; i++)
            {
                int index = rnd.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        public bool IsFullyHidden()
        {
            return _words.All(w => w.IsHidden());
        }

        public int TotalWords()
        {
            return _words.Count;
        }

        public int HiddenWordsCount()
        {
            return _words.Count(w => w.IsHidden());
        }
    }
}
