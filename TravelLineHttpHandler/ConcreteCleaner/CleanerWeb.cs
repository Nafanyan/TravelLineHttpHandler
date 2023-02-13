

namespace TravelLineHttpHandler.ClearingHttp
{
    internal class CleanerWeb : ICleaner
    {
        string ICleaner.Clean(string webString, params string[] secureParams)
        {

            string secureData = webString;
            int idxSecuStart;
            int idxSecuEnd;

            foreach (string secureElement in secureParams)
            {
                idxSecuStart = webString.IndexOf('/', webString.IndexOf(secureElement)) + 1;

                if (idxSecuStart == 0) idxSecuStart = webString.IndexOf('=', webString.IndexOf(secureElement)) + 1;

                idxSecuEnd = webString.IndexOf('/', idxSecuStart);

                if (idxSecuEnd == -1) 
                    idxSecuEnd = webString.IndexOf('&', webString.IndexOf(secureElement));

                if (idxSecuEnd == -1) 
                    idxSecuEnd = webString.Length;

                secureData = webString.Remove(idxSecuEnd);
                secureData = secureData.Remove(0, idxSecuStart);
                webString = webString.Replace(secureData, String.Concat(Enumerable.Repeat("X", secureData.Length)));
            }

            return webString;
        }
    }
}
