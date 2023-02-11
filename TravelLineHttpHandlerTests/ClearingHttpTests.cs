using Microsoft.VisualStudio.TestTools.UnitTesting;


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

        [TestMethod()]
        public void ClearJSONUrlTest()
        {

            string urlJSON = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",
                                   ""PATH"": ""users/max/info"",
                                  ""QUERE"": ""?pass=123456""}";

            // arrange
            string expectedUrlJSON = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",""PATH"":""users/XXX/info"",""QUERE"":""?pass=XXXXXX""}";

            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp();
            string actualUrlJSON = clearHttp.ClearJSONUrl(urlJSON);

            // assert
            Assert.AreEqual(expectedUrlJSON, actualUrlJSON);
        }

        [TestMethod()]
        public void ClearJSONGetTest()
        {
            string getJSON = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",
                                  ""QUERE"": ""?user=max&pass=123456""}";

            // arrange
            string expectedGetJSON = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",""QUERE"":""?user=XXX&pass=XXXXXX""}";

            // act
            TravelLineHttpHandler.ClearingHttp clearHttp = new TravelLineHttpHandler.ClearingHttp();
            string actualGetJSON = clearHttp.ClearJSONGet(getJSON);

            // assert
            Assert.AreEqual(expectedGetJSON, actualGetJSON);
        }
    }
}