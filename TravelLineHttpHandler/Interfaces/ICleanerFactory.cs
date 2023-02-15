namespace TravelLineHttpHandler.Interfaces
{
    public interface ICleanerFactory
    {
        public ICleaner GetCleaner(string requestString);

    }
}
