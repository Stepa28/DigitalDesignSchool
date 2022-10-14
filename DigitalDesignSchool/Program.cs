using System.Diagnostics;
using DigitalDesignSchool.WordsCounter;

string filePath = "C:\\Project\\DigitalDesignSchool\\Text.txt";

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
var allText = File.ReadAllText(filePath);

var instance = new WordsCounterClient();
var words = await instance.GetDataAsync(allText);

File.WriteAllText(@"WordsInText.txt", //Запись получившегося результата
    string.Join("\r\n",
        words.OrderByDescending(x => x.Value)
             .Select(word => $"{word.Key}\t{word.Value}"))); //Склейка полученных результатов, каждый с новой строки
             
Console.WriteLine(stopWatch.Elapsed);
