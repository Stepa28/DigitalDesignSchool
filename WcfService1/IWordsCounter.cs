using System.Collections.Generic;
using System.ServiceModel;

namespace WcfService1
{
    [ServiceContract]
    public interface IWordsCounter
    {
        [OperationContract]
        Dictionary<string, int> GetData(string allText);
    }
}
