using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelLineHttpHandler.ClearingHttp;
using TravelLineHttpHandler.ConcreteCleaner;

namespace TravelLineHttpHandler
{
    public class Application
    {
        Cleaner cleaner;

        private void InitCleaner(string http)
        {

            // if XML
            if (http.Contains("</") && http.Contains('>'))
            {
                this.cleaner = new XMLCleaner();
                return;
            }

            // if JSON
            if (http.Contains('{') && http.Contains('}') && http.Contains(':'))
            {
                this.cleaner = new JSONCleaner();
                return;
            }
            this.cleaner = new WebCleaner();
        }

        public string SecureDataClear(string httpString, params string[] secureParam)
        {
            InitCleaner(httpString);
            return cleaner.ProcessClearing(httpString, secureParam); ;
        }


    }
}
