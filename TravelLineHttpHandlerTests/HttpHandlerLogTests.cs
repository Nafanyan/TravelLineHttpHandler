using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelLineHttpHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelLineHttpHandler.Tests
{
    [TestClass()]
    public class HttpHandlerLogTests
    {
        [TestMethod()]
        public void HttpHandlerLog_Process_BookingcomHttpResult_ClearSecureData()
        {
            // arrange 
            var bookingcomHttpResult = new HttpResult
            {
                Url = "http://test.com/users/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };

            // act 
            HttpHandler httpLogHandler = new HttpHandler();
            httpLogHandler.Process(bookingcomHttpResult.Url, bookingcomHttpResult.RequestBody, bookingcomHttpResult.ResponseBody, new string[] {"user", "pass"});

            // assert
            Assert.AreEqual("http://test.com/users/XXX/info?pass=XXXXXX", httpLogHandler.CurrentLog.Url);
            Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.RequestBody);
            Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.ResponseBody);
        }
    }
}