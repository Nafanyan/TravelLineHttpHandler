using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelLineHttpHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Reflection.Emit;
using System.Data.SqlTypes;
using System.Xml;
using System.Net;
using System.Xml.Serialization;
using System.Web;
using System.Xml.Linq;

namespace TravelLineHttpHandler.Tests
{
    [TestClass()]
    public class ClearingHttpTests
    {
        string url = "http://test.com/users/max/info?pass=123456";
        string requestBody = "http://test.com?user=max&pass=123456";
        string responseBody = "http://test.com?user=max&pass=123456";

        [TestMethod()]
        public void ClearingHttpTest_Url()
        {
            // arrange

            string expectedUrl = "http://test.com/users/XXX/info?pass=XXXXXX";

            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp(url, requestBody, responseBody);
            string actualURL = clearHttp.Url;

            // assert
            Assert.AreEqual(expectedUrl, actualURL);
        }

        [TestMethod()]
        public void ClearingHttpTest_requestBody()
        {
            // arrange

            string expectedRequestBody = "http://test.com?user=XXX&pass=XXXXXX";

            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp(url, requestBody, responseBody);
            string actualRequestBody = clearHttp.RequestBody;

            // assert
            Assert.AreEqual(expectedRequestBody, actualRequestBody);
        }

        [TestMethod()]
        public void ClearingHttpTest_responseBody()
        {

            string expectedResponseBody = "http://test.com?user=XXX&pass=XXXXXX";

            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp(url, requestBody, responseBody);
            string actualRespinseBody = clearHttp.ResponseBody;

            // assert
            Assert.AreEqual(expectedResponseBody, actualRespinseBody);
        }


    }
}