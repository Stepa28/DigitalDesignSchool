using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class WordsCounterBusiness
    {
        public Dictionary<string, int> WordsCounterFromPathFileParallel(string allText)
        {
            try
            {
                var words = new ConcurrentDictionary<string, int>();
    
                char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '"', '(', ')', '[', ']', '!' }; // разделители слов
                string[] enumerableWords = allText.Split(chars, StringSplitOptions.RemoveEmptyEntries);    //Получение массива списка слов
    
                Parallel.ForEach(enumerableWords, word => words.AddOrUpdate(word.ToLower(), 1, (_, i) => ++i));
                return words.ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            catch (Exception e) //Т.к. задача учебная обработчик всех возможных ошибок не делал
            {
                Console.WriteLine($"Во время работы приложения возникло исключение :\n{e}");
                throw;
            }
        }
    }
}