using TravelLineHttpHandler.Interfaces;
using TravelLineHttpHandler.ConcreteCleaner;

namespace TravelLineHttpHandler.ConcreteFactories
{
    public class CleanerFactory : ICleanerFactory
    {
        public ICleaner GetCleaner(string requestString)
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
    }
}
