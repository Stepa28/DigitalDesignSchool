using System.Collections.Concurrent;

namespace PrivateLibrary;

public class WordsCounter
{
    public Dictionary<string, int> WordsCounterFromPathFileParallel(string[] allText)
    {
        try
        {
            var words = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(allText, word => words.AddOrUpdate(word.ToLower(), 1, (_, i) => ++i));
            return words.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        catch (Exception e) //Т.к. задача учебная обработчик всех возможных ошибок не делал
        {
            Console.WriteLine($"Во время работы приложения возникло исключение :\n{e}");
            throw;
        }
    }
}