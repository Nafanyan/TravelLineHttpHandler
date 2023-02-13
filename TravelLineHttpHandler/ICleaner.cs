
namespace TravelLineHttpHandler
{
    internal interface ICleaner
    {
        public string Clean (string requestString, params string[] secureParam);
    }
}
