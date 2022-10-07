try
{
    var words = new Dictionary<string, int>();
    var allText = File.ReadAllText("C:\\Project\\DigitalDesignSchool\\Text.txt"); //Чтение текстового файла

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

    File.WriteAllText(@"WordsInText.txt", //Запись получившегося результата
        string.Join("\r\n",
            words.OrderByDescending(x => x.Value)
                 .Select(word => $"{word.Key}\t{word.Value}"))); //Склейка полученных результатов, каждый с новой строки

}
catch (Exception e) //Т.к. задача учебная обработчик всех возможных ошибок не делал
{
    Console.WriteLine($"Во время работы приложения возникло исключение :\n{e}");
    throw;
}