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
using Microsoft.VisualBasic;

namespace TravelLineHttpHandler.Tests
{
    [TestClass()]
    public class ClearingHttpTests
    {
        

        [TestMethod()]
        public void ClearUrlTest()
        {
            // arrange
            string url = "http://test.com/users/max/info?pass=123456";
            string expectedUrl = "http://test.com/users/XXX/info?pass=XXXXXX";

            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp();
            string actualURL = clearHttp.ClearUrl(url);

            // assert
            Assert.AreEqual(expectedUrl, actualURL);
        }


        [TestMethod()]
        public void ClearGetTest()
        {
            // arrange
            string requestBody = "http://test.com?user=max&pass=123456";
            string responseBody = "http://test.com?user=max&pass=123456";

            string expectedRequestBody = "http://test.com?user=XXX&pass=XXXXXX";
            string expectedResponseBody = "http://test.com?user=XXX&pass=XXXXXX";

            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp();
            string actualRequestBody = clearHttp.ClearGet(requestBody);
            string actualResponseBody = clearHttp.ClearGet(responseBody);

            // assert
            Assert.AreEqual(expectedRequestBody, actualRequestBody);
            Assert.AreEqual(expectedResponseBody, actualResponseBody);
        }


        [TestMethod()]
        public void ClearXMLUrlTest()
        {
            string urlXML = @"<root><SCHEME>http</SCHEME><AUTHORITY>test.com</AUTHORITY><PATH>users/max/info</PATH><QUERE>?pass=123456</QUERE></root>";

            // arrange
            string expectedUrlXML = @"<root><SCHEME>http</SCHEME><AUTHORITY>test.com</AUTHORITY><PATH>users/XXX/info</PATH><QUERE>?pass=XXXXXX</QUERE></root>";

            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp();
            string actualUrlXML = clearHttp.ClearXMLUrl(urlXML);

            // assert
            Assert.AreEqual(expectedUrlXML, actualUrlXML);
        }


        [TestMethod()]
        public void ClearXMLGetTest()
        {
            string requestBodyXML = @"<root><SCHEME>http</SCHEME><AUTHORITY>test.com</AUTHORITY><QUERE>?user=max&amp;pass=123456</QUERE></root>";

            // arrange
            string expectedxmlGet = @"<root><SCHEME>http</SCHEME><AUTHORITY>test.com</AUTHORITY><QUERE>?user=XXX&amp;pass=XXXXXX</QUERE></root>";
            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp();
            string actualUrlXML = clearHttp.ClearXMLGet(requestBodyXML);

            // assert
            Assert.AreEqual(expectedxmlGet, actualUrlXML);
        }
    }
}