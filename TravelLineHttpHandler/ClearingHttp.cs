using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private string ClearUrl(string urlString)
        {
            Uri url = StringToUri(urlString);
            string urlCleared = $"{url.Scheme}://{url.DnsSafeHost}";
            string clearPass = url.PathAndQuery;

            bool nowName = false;
            foreach (string segment in clearPass.Split('/'))
            {
                string tempSegment = segment;

                // clear name
                if (nowName)
                {
                    tempSegment = tempSegment.Replace(tempSegment,
                        String.Concat(Enumerable.Repeat("X", tempSegment.Length)));
                    nowName = false;
                }

                // clear pass
                if (segment.Contains("pass="))
                {
                    int passStart = tempSegment.IndexOf('=') + 1;
                    int passEnd = tempSegment.Length;

                    if (segment.Contains('&')) passEnd = tempSegment.IndexOf('&');

                    for (int i = passStart; i < passEnd; i++)
                        tempSegment = tempSegment.Replace(tempSegment[i], 'X');
                }

                if (segment.Contains("user")) nowName = true;

                urlCleared += $"{tempSegment}/";
            }
            return urlCleared.Remove(urlCleared.Length - 1);
        }

        private string ClearGet(string getString)
        {
            Uri getUri = StringToUri(getString);
            string getCleared = $"{getUri.Scheme}://{getUri.DnsSafeHost}";

            // clear pass and user
            string clearPass = getUri.Query;

            foreach (string segment in clearPass.Split('&'))
            {
                string tempSegment = segment;

                if (segment.Contains("pass=") || segment.Contains("user="))
                {
                    int passStart = tempSegment.IndexOf('=') + 1;
                    int passEnd = tempSegment.Length;

                    for (int i = passStart; i < passEnd; i++)
                        tempSegment = tempSegment.Replace(tempSegment[i], 'X');

                }


                getCleared += $"{tempSegment}&";
            }
            return getCleared.Remove(getCleared.Length - 1);
        }

    }
}
