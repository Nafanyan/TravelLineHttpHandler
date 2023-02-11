using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TravelLineHttpHandler
{
    public class ClearingHttp
    {
        public string Url { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }

        public ClearingHttp(string url, string requestBody, string responseBody)
        {
            Url = ClearUrl (url);
            RequestBody = ClearGet (requestBody);
            ResponseBody = ClearGet (responseBody);
        }


        private Uri StringToUri(string http)
        {
            Uri siteUri = new Uri(http);
            return siteUri;
        }

        public string ClearUrl(string urlString)
        {
            Uri url = StringToUri(urlString);
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

            if (clearSecure.Contains('&')) idxSecuEnd = clearSecure.IndexOf('&', clearSecure.IndexOf("pass")) + 1;

            secureData = clearSecure.Remove(idxSecuEnd);
            secureData = secureData.Remove(0, idxSecuStart);
            clearSecure = clearSecure.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));

            return $"{urlCleared}{clearSecure}";
        }

        private string ClearGet(string getString)
        {
            Uri getUri = StringToUri(getString);
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

        public string ClearXML(string getString)
        {
            return getString;
        }

    }
}
