using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelLineHttpHandler.ClearingHttp;

namespace TravelLineHttpHandler.ConcreteCleaner
{
    internal class WebCleaner : Cleaner
    {
        protected override IClearingHttp CreateClearingElement()
        {
            return new ClearingWeb();
        }
    }
}
