using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelLineHttpHandler.ClearingHttp;

namespace TravelLineHttpHandler
{
    internal abstract class Cleaner
    {
        public string ProcessClearing(string urlString, params string[] secureParam)
        {
            IClearingHttp clearingHttp = CreateClearingElement();
            return clearingHttp.clearingUrl(urlString, secureParam);
        }
        protected abstract IClearingHttp CreateClearingElement();

    }
}
