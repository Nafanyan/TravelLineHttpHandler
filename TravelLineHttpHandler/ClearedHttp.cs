using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelLineHttpHandler.ClearingHttp;
using TravelLineHttpHandler.ConcreteCleaner;

namespace TravelLineHttpHandler
{
    public class ClearedHttp
    {
        Cleaner _cleaner;

        private void InitCleaner(string http)
        {

            // if XML
            if (http.Contains("</") && http.Contains('>'))
            {
                _cleaner = new XMLCleaner();
                return;
            }

            // if JSON
            if (http.Contains('{') && http.Contains('}') && http.Contains(':'))
            {
                _cleaner = new JSONCleaner();
                return;
            }
            // if Web
            _cleaner = new WebCleaner();
        }

        public string SecureDataClear(string httpString, params string[] secureParam)
        {
            InitCleaner(httpString);
            return _cleaner.ProcessClearing(httpString, secureParam);
        }


    }
}
