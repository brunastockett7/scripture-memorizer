// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptures = new List<Scripture>()
            {
                new Scripture(
                    new Reference("John", 3, 16),
                    "For God so loved the world that he gave his one and only Son, " +
                    "that whoever believes in him shall not perish but have eternal life."
                ),

                new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all your heart and lean not on your own understanding; " +
                    "in all your ways submit to him, and he will make your paths straight."
                )
            };

            Random rnd = new Random();
            Scripture currentScripture = scriptures[rnd.Next(scriptures.Count)];

            while (true)
            {
                Console.Clear();
                currentScripture.Display();

                int totalWords = currentScripture.TotalWords();
                int hiddenWords = currentScripture.HiddenWordsCount();
                Console.WriteLine($"\nProgress: {hiddenWords} of {totalWords} words hidden.");

                if (currentScripture.IsFullyHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Well done!");
                    break;
                }

                Console.WriteLine("\nPress ENTER to hide more words or type 'quit' to exit:");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                    break;

                currentScripture.HideWords(3);
            }
        }
    }
}
