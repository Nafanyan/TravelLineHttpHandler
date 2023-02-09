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
    public class ClearingHttpTests
    {


        [TestMethod()]
        public void ClearingHttpTest_Url()
        {
            // arrange
            string url = "http://test.com/users/max/info?pass=123456";
            string requestBody = "http://test.com?user=max&pass=123456";
            string responseBody = "http://test.com?user=max&pass=123456";

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
            string url = "http://test.com/users/max/info?pass=123456";
            string requestBody = "http://test.com?user=max&pass=123456";
            string responseBody = "http://test.com?user=max&pass=123456";

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
            string url = "http://test.com/users/max/info?pass=123456";
            string requestBody = "http://test.com?user=max&pass=123456";
            string responseBody = "http://test.com?user=max&pass=123456";

            string expectedResponseBody = "http://test.com?user=XXX&pass=XXXXXX";

            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp(url, requestBody, responseBody);
            string actualRespinseBody = clearHttp.ResponseBody;

            // assert
            Assert.AreEqual(expectedResponseBody, actualRespinseBody);
        }
    }
}