
namespace TravelLineHttpHandler
{
    internal interface ICleaner
    {
        public string Clean (string httpString, params string[] secureParam);
    }
}
