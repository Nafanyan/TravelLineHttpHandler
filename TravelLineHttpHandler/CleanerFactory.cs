
using TravelLineHttpHandler.ClearingHttp;



namespace TravelLineHttpHandler
{
    public class CleanerFactory : ICleanerFactory
    {
        private readonly ICleaner _cleaner;

        ICleaner ICleanerFactory.GetCleaner(string requestString)
        {
            // if XML
            if (requestString.Contains("</") && requestString.Contains('>'))
            {
                return new CleanerXML();
            }

            // if JSON
            if (requestString.Contains('{') && requestString.Contains('}') && requestString.Contains(':'))
            {
                return new CleanerJSON();
            }

            // if Web
            return new CleanerWeb();
        }

        public string SecureDataClear(string requestString, params string[] secureParam)
        {
            //_cleaner = Get
            ICleaner _cleaner = ((ICleanerFactory)this).GetCleaner(requestString);
            return _cleaner.Clean(requestString, secureParam);
        }

    }
}
