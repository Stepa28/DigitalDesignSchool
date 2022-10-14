using System.Collections.Concurrent;

namespace PrivateLibrary;

public class WordsCounter
{
    public ConcurrentDictionary<string, int> WordsCounterFromPathFileParallel(string path)
    {
        try
        {
            var words = new ConcurrentDictionary<string, int>();
            var allText = File.ReadAllText(path); //Чтение текстового файла

            char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '"', '(', ')', '[', ']', '!' }; // разделители слов
            string[] enumerableWords = allText.Split(chars, StringSplitOptions.RemoveEmptyEntries);    //Получение массива списка слов

            Parallel.ForEach(enumerableWords, word => words.AddOrUpdate(word.ToLower(), 1, (_, i) => ++i));
            return words;
        }
        catch (Exception e) //Т.к. задача учебная обработчик всех возможных ошибок не делал
        {
            Console.WriteLine($"Во время работы приложения возникло исключение :\n{e}");
            throw;
        }
    }
    
    private Dictionary<string, int> WordsCounterFromPathFile(string path)
    {
        try
        {
            var words = new Dictionary<string, int>();
            var allText = File.ReadAllText(path); //Чтение текстового файла

            char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '"', '(', ')', '[', ']', '!' }; // разделители слов
            string[] enumerableWords = allText.Split(chars, StringSplitOptions.RemoveEmptyEntries);    //Получение массива списка слов

            foreach (string word in enumerableWords)
            {
                string w = word.ToLower(); //все слова в нижнем регистре

                if (!words.ContainsKey(w))
                    words.Add(w, 1); //если слова нет в словаре, то добавляем
                else
                    words[w] += 1; //если слово есть в словаре, добавляем счётчику 1
            }
            return words;
        }
        catch (Exception e) //Т.к. задача учебная обработчик всех возможных ошибок не делал
        {
            Console.WriteLine($"Во время работы приложения возникло исключение :\n{e}");
            throw;
        }
    }
}