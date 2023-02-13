
using TravelLineHttpHandler.ClearingHttp;


namespace TravelLineHttpHandler
{
    public class HttpCleanerFactory
    {
        private ICleaner _cleaner;

        private ICleaner GetCleaner(string http)
        {

            // if XML
            if (http.Contains("</") && http.Contains('>'))
            {
                return new CleanerXML();
            }

            // if JSON
            if (http.Contains('{') && http.Contains('}') && http.Contains(':'))
            {
                return new CleanerJSON();
            }

            // if Web
            return new CleanerWeb();
        }

        public string SecureDataClear(string httpString, params string[] secureParam)
        {
            _cleaner = GetCleaner(httpString);
            return _cleaner.Clean(httpString, secureParam);
        }


    }
}
