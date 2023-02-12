using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelLineHttpHandler.ClearingHttp
{
    internal class ClearingXML : IClearingHttp
    {
        string IClearingHttp.clearingUrl(string XMLString, params string[] secureParam)
        {
            throw new NotImplementedException();
        }
    }
}
