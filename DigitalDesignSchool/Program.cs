using System.Reflection;
using PrivateLibrary;

string filePath = "C:\\Project\\DigitalDesignSchool\\Text.txt";

var couter = new WordsCounter();
var method = couter.GetType().GetMethod("WordsCounterFromPathFile", BindingFlags.NonPublic | BindingFlags.Instance);

object[] parameters = { filePath };
var words = method.Invoke(couter, parameters) as Dictionary<string, int>;

File.WriteAllText(@"WordsInText.txt", //Запись получившегося результата
    string.Join("\r\n",
        words.OrderByDescending(x => x.Value)
             .Select(word => $"{word.Key}\t{word.Value}"))); //Склейка полученных результатов, каждый с новой строки