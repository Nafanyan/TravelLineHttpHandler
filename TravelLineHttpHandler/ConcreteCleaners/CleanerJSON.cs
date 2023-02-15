using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TravelLineHttpHandler.Interfaces;

namespace TravelLineHttpHandler.ConcreteCleaner
{
    public class CleanerJSON : ICleaner
    {
        string ICleaner.Clean(string jsonString, params string[] secureParams)
        {
            JObject jsonDoc = JObject.Parse(jsonString);


            if (jsonDoc is not null)
            {
                string jsonPath;
                string secureData;

                foreach (string secureElement in secureParams)
                {
                    jsonPath = secureElement.Remove(secureElement.LastIndexOf('.'));

                    foreach (JToken secureNode in jsonDoc.SelectTokens(jsonPath))
                    {
                        jsonPath = secureElement.Remove(0, secureElement.LastIndexOf('.') + 1);
                        secureData = ((string)secureNode[jsonPath]);
                        secureData = secureData.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));
                        secureNode[jsonPath] = secureData;
                    }
                }
                return JsonConvert.SerializeObject(jsonDoc);
            }

            return jsonString;
        }
    }
}
