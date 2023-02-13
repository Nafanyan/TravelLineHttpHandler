
namespace TravelLineHttpHandler
{
    internal class RequestCleaner
    {
        private readonly ICleanerFactory _factory;

        public RequestCleaner(ICleanerFactory cleanerFactory)
        {
            _factory = cleanerFactory;
        }

        public string ClearRequest(string requestString, params string[] secureParam)
        {
            ICleaner cleaner = _factory.GetCleaner(requestString);
            return cleaner.Clean(requestString, secureParam);
        }

    }
}
