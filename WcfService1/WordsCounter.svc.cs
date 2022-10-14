using System.Collections.Generic;
using Library;

namespace WcfService1
{
    public class WordsCounter : IWordsCounter
    {
        public Dictionary<string, int> GetData(string allText)
        {
            return new WordsCounterBusiness().WordsCounterFromPathFileParallel(allText);
        }
    }
}
