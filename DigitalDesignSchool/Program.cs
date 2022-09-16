using System.Text.RegularExpressions;

Console.WriteLine("Введите путь до текстового файла");
var filePath = Console.ReadLine(); //Получение пути до текстового файла

try
{
    var allText = File.ReadAllText(filePath);                          //Чтение текстового файла
    var enumerableWords = Regex.Matches(allText, @"\b\w+[\'\-\w*]*\b") //Получение списка слов
                               .GroupBy(x => x.Value.ToLower())        //Группировка по отдельным словам + игнорирование регистра
                               .OrderByDescending(x => x.Count())      //Сортировка по убыванию
                               .Select(x => $"{x.Key}\t{x.Count()}");  //Форма записи

    File.WriteAllText(@"WordsInText.txt",      //Запись получившегося результата
        string.Join("\r\n", enumerableWords)); //Склейка полученных результатов, каждый с новой строки


    Console.WriteLine("Приложение закончило свою работу успешно");
}
catch (Exception e) //Т.к. задача учебная обработчик всех возможных ошибок не делал
{
    Console.WriteLine($"Во время работы приложения возникло исключение :\n{e}");
    throw;
}