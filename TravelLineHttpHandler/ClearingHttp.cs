using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using static System.Net.WebRequestMethods;


namespace TravelLineHttpHandler
{
    public class ClearingHttp
    {

        public string ClearUrl(string urlString)
        {
            Uri url = new Uri(urlString);
            string urlCleared = $"{url.Scheme}://{url.DnsSafeHost}";
            string clearSecure = url.PathAndQuery;

            // clear name
            string secureData;
            int idxSecuStart = clearSecure.IndexOf('/', clearSecure.IndexOf("user")) + 1;
            int idxSecuEnd = clearSecure.IndexOf('/', idxSecuStart);

            secureData = clearSecure.Remove(idxSecuEnd);
            secureData = secureData.Remove(0, idxSecuStart);
            clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));

            // clear pass
            idxSecuStart = clearSecure.IndexOf('=', clearSecure.IndexOf("pass")) + 1;
            idxSecuEnd = clearSecure.Length;

            if (clearSecure.Remove(0, clearSecure.IndexOf("pass")).Contains('&'))
                idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("pass"));

            secureData = clearSecure.Remove(idxSecuEnd);
            secureData = secureData.Remove(0, idxSecuStart);
            clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));

            return $"{urlCleared}{clearSecure}";
        }

        public string ClearGet(string getString)
        {
            Uri getUri = new Uri(getString); ;
            string getCleared = $"{getUri.Scheme}://{getUri.DnsSafeHost}";
            string clearSecure = getUri.Query;

            // clear name 
            string secureData;
            int idxSecuStart = clearSecure.IndexOf('=', clearSecure.IndexOf("user")) + 1;
            int idxSecuEnd = clearSecure.Length;

            if (clearSecure.Contains('&')) idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("user"));

            secureData = clearSecure.Remove(idxSecuEnd);
            secureData = secureData.Remove(0, idxSecuStart);
            clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));

            // clear pass
            idxSecuStart = clearSecure.IndexOf('=', clearSecure.IndexOf("pass")) + 1;
            idxSecuEnd = clearSecure.Length;

            if (clearSecure.Remove(0, clearSecure.IndexOf("pass")).Contains('&')) 
                idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("pass"));

            secureData = clearSecure.Remove(idxSecuEnd);
            secureData = secureData.Remove(0, idxSecuStart);
            clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));

            return $"{getCleared}{clearSecure}";
        }

        public string ClearXMLUrl(string xmlString)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            XmlNode root = xmlDoc.DocumentElement;

            string clearSecure;
            int idxSecuStart;
            int idxSecuEnd;
            int idxKeyword;

            foreach (XmlNode node in root.ChildNodes)
            {
                // clear name
                if (node.Name == "PATH")
                {
                    clearSecure = node.InnerText;
                    idxKeyword = clearSecure.IndexOf("user");
                    string secureData;

                    if (idxKeyword >= 0)
                    {
                        idxSecuStart = clearSecure.IndexOf('/', idxKeyword) + 1;
                        idxSecuEnd = clearSecure.IndexOf('/', idxSecuStart);

                        secureData = clearSecure.Remove(idxSecuEnd);
                        secureData = secureData.Remove(0, idxSecuStart);
                        clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));

                    }
                    node.InnerText = clearSecure;
                }

                // clear pass
                if (node.Name == "QUERE")
                {
                    clearSecure = node.InnerText;
                    idxKeyword = clearSecure.IndexOf("pass");
                    string secureData;

                    if (idxKeyword >= 0)
                    {
                        idxSecuStart = clearSecure.IndexOf('=', idxKeyword) + 1;
                        idxSecuEnd = clearSecure.Length;

                        if (clearSecure.Remove(0, clearSecure.IndexOf("pass")).Contains('&'))
                            idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("pass"));

                        secureData = clearSecure.Remove(idxSecuEnd);
                        secureData = secureData.Remove(0, idxSecuStart);
                        clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));
                    }

                    node.InnerText = clearSecure;
                }
            }
            return xmlDoc.OuterXml;
        }

        public string ClearXMLGet(string xmlString)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            XmlNode root = xmlDoc.DocumentElement;

            string clearSecure;
            int idxSecuStart;
            int idxSecuEnd;
            int idxKeyword;

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "QUERE")
                {
                    //clear name
                    clearSecure = node.InnerText;
                    idxKeyword = clearSecure.IndexOf("user");
                    string secureData;

                    if (idxKeyword >= 0)
                    {
                        idxSecuStart = clearSecure.IndexOf('=', idxKeyword) + 1;
                        idxSecuEnd = clearSecure.Length;

                        if (clearSecure.Remove(0, clearSecure.IndexOf("user")).Contains('&'))
                            idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("user"));

                        secureData = clearSecure.Remove(idxSecuEnd);
                        secureData = secureData.Remove(0, idxSecuStart);
                        clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));
                    }
                    node.InnerText = clearSecure;

                    // clear pass
                    clearSecure = node.InnerText;
                    idxKeyword = clearSecure.IndexOf("pass");

                    if (idxKeyword >= 0)
                    {
                        idxSecuStart = clearSecure.IndexOf('=', idxKeyword) + 1;
                        idxSecuEnd = clearSecure.Length;

                        if (clearSecure.Remove(0, clearSecure.IndexOf("pass")).Contains('&'))
                            idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("pass"));

                        secureData = clearSecure.Remove(idxSecuEnd);
                        secureData = secureData.Remove(0, idxSecuStart);
                        clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));
                    }
                    node.InnerText = clearSecure;
                }
            }
            return xmlDoc.OuterXml;
        }

        public string ClearJSONUrl(string jsonString)
        {
            JObject jsonDoc = JObject.Parse(jsonString);

            string clearSecure;
            int idxSecuStart;
            int idxSecuEnd;
            int idxKeyword;

            foreach (JToken node in jsonDoc.Root)
            {
                // clear name
                if (node.Path == "PATH")
                {
                    clearSecure = ((string)node);
                    idxKeyword = clearSecure.IndexOf("user");
                    string secureData;

                    if (idxKeyword >= 0)
                    {
                        idxSecuStart = clearSecure.IndexOf('/', idxKeyword) + 1;
                        idxSecuEnd = clearSecure.IndexOf('/', idxSecuStart);

                        secureData = clearSecure.Remove(idxSecuEnd);
                        secureData = secureData.Remove(0, idxSecuStart);
                        clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));

                    }
                    jsonDoc["PATH"] = clearSecure;
                }

                // clear pass
                if (node.Path == "QUERE")
                {
                    clearSecure = ((string)node);
                    idxKeyword = clearSecure.IndexOf("pass");
                    string secureData;

                    if (idxKeyword >= 0)
                    {
                        idxSecuStart = clearSecure.IndexOf('=', idxKeyword) + 1;
                        idxSecuEnd = clearSecure.Length;

                        if (clearSecure.Remove(0, clearSecure.IndexOf("pass")).Contains('&'))
                            idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("pass"));

                        secureData = clearSecure.Remove(idxSecuEnd);
                        secureData = secureData.Remove(0, idxSecuStart);
                        clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));
                    }
                    jsonDoc["QUERE"] = clearSecure;
                }

            }

            return JsonConvert.SerializeObject(jsonDoc); 
        }

        public string ClearJSONGet(string jsonString)
        {
            JObject jsonDoc = JObject.Parse(jsonString);

            string clearSecure;
            int idxSecuStart;
            int idxSecuEnd;
            int idxKeyword;

            foreach (JToken node in jsonDoc.Root)
            {
                if (node.Path == "QUERE")
                {
                    //clear name
                    clearSecure = ((string)node);
                    idxKeyword = clearSecure.IndexOf("user");
                    string secureData;

                    if (idxKeyword >= 0)
                    {
                        idxSecuStart = clearSecure.IndexOf('=', idxKeyword) + 1;
                        idxSecuEnd = clearSecure.Length;

                        if (clearSecure.Remove(0, clearSecure.IndexOf("user")).Contains('&'))
                            idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("user"));

                        secureData = clearSecure.Remove(idxSecuEnd);
                        secureData = secureData.Remove(0, idxSecuStart);
                        clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));
                    }
                    jsonDoc["QUERE"] = clearSecure;

                    // clear pass
                    clearSecure = ((string)node);
                    idxKeyword = clearSecure.IndexOf("pass");

                    if (idxKeyword >= 0)
                    {
                        idxSecuStart = clearSecure.IndexOf('=', idxKeyword) + 1;
                        idxSecuEnd = clearSecure.Length;

                        if (clearSecure.Remove(0, clearSecure.IndexOf("pass")).Contains('&'))
                            idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("pass"));

                        secureData = clearSecure.Remove(idxSecuEnd);
                        secureData = secureData.Remove(0, idxSecuStart);
                        clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));
                    }
                    jsonDoc["QUERE"] = clearSecure;
                }

            }

            return JsonConvert.SerializeObject(jsonDoc);
        }
    }
}
