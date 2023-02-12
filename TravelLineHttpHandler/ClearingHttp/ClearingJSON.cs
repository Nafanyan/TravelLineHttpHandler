using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelLineHttpHandler.ClearingHttp 
{
    public class ClearingJSON : IClearingHttp
    {
        string IClearingHttp.clearingUrl(string JSONString, params string[] secureParam)
        {
            throw new NotImplementedException();
        }
    }
}
