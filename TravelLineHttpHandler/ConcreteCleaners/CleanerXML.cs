using System.Xml;
using TravelLineHttpHandler.Interfaces;

namespace TravelLineHttpHandler.ConcreteCleaner
{
    public class CleanerXML : ICleaner
    {
        string ICleaner.Clean(string xmlString, params string[] secureParams)
        {
            XmlDocument? xmlDoc = new XmlDocument();

            if (xmlDoc is not null)
            {
                xmlDoc.LoadXml(xmlString);
                XmlNode? root = xmlDoc.DocumentElement;
                XmlNodeList? secureNods;

                string secureData;
                foreach (string secureElement in secureParams)
                {
                    secureNods = root.SelectNodes($"//{secureElement}");

                    if (secureNods is not null)
                    {
                        foreach (XmlNode secureNode in secureNods)
                        {
                            secureData = secureNode.InnerText;
                            secureData = secureData.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));
                            secureNode.InnerText = secureData;
                        }
                    }

                }
                return xmlDoc.OuterXml;
            }
            return xmlString;
        }
    }
}
