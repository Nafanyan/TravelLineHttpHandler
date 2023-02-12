using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelLineHttpHandler
{
    public interface IClearingHttp
    {
        public string clearingUrl (string httpString, params string[] secureParam);
    }
}
