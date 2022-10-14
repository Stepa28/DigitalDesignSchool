using System.Diagnostics;
using RestSharp;

string filePath = "C:\\Project\\DigitalDesignSchool\\Text.txt";

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

var allText = File.ReadAllText(filePath); //Чтение текстового файла
var client = new RestClient("https://localhost:44305/WordsCouturier");
var request = new RestRequest("", Method.Post);

char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '"', '(', ')', '[', ']', '!' }; // разделители слов
string[] enumerableWords = allText.Split(chars, StringSplitOptions.RemoveEmptyEntries);    //Получение массива списка слов
request.AddBody(enumerableWords);

var response = await client.ExecuteAsync<Dictionary<string, int>>(request);
var words = response.Data;

File.WriteAllText(@"WordsInText.txt", //Запись получившегося результата
    string.Join("\r\n",
        words.OrderByDescending(x => x.Value)
             .Select(word => $"{word.Key}\t{word.Value}"))); //Склейка полученных результатов, каждый с новой строки
             
Console.WriteLine(stopWatch.Elapsed);