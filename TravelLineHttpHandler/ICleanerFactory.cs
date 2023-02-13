
namespace TravelLineHttpHandler
{
    internal interface ICleanerFactory
    {
        public ICleaner GetCleaner(string requestString);

        public string SecureDataClear(string requestString, params string[] secureParam);
    }
}
