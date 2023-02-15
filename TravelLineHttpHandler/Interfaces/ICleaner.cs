namespace TravelLineHttpHandler.Interfaces
{
    public interface ICleaner
    {
        public string Clean(string requestString, params string[] secureParam);
    }
}
