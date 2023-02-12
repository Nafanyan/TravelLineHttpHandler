//using TravelLineHttpHandler;
//using Microsoft.VisualStudio.TestTools.UnitTesting;


//namespace TravelLineHttpHandler.Tests
//{
//    [TestClass()]
//    public class ClearingHttpTests
//    {

//        [TestMethod()]
//        public void ClearingHttp_Process_BookingcomHttpResultWeb_ClearSecureData()
//        {
//            string expectedUrl = "http://test.com/users/XXX/info?pass=XXXXXX";
//            string expectedRequestBody = "http://test.com?user=XXX&pass=XXXXXX";
//            string expectedResponseBody = "http://test.com?user=XXX&pass=XXXXXX";

//            // arrange
//            HttpResult bookingcomHttpResultWeb = new HttpResult
//            {
//                Url = "http://test.com/users/max/info?pass=123456",
//                RequestBody = "http://test.com?user=max&pass=123456",
//                ResponseBody = "http://test.com?user=max&pass=123456"
//            };

//            // act
//            TravelLineHttpHandler.ClearingHttp clearedHttp = new TravelLineHttpHandler.ClearingHttp();
//            HttpResult actualHttpResult = clearedHttp.Process(bookingcomHttpResultWeb.Url,
//                                                                bookingcomHttpResultWeb.RequestBody,
//                                                                bookingcomHttpResultWeb.ResponseBody);

//            // assert
//            Assert.AreEqual(expectedUrl, actualHttpResult.Url);
//            Assert.AreEqual(expectedRequestBody, actualHttpResult.RequestBody);
//            Assert.AreEqual(expectedResponseBody, actualHttpResult.ResponseBody);
//        }

//        [TestMethod()]
//        public void ClearingHttp_Process_BookingcomHttpResultXML_ClearSecureData()
//        {
//            string expectedUrl = @"<root><SCHEME>http</SCHEME><AUTHORITY>test.com</AUTHORITY><PATH>users/XXX/info</PATH><QUERE>?pass=XXXXXX</QUERE></root>";
//            string expectedRequestBody = @"<root><SCHEME>http</SCHEME><AUTHORITY>test.com</AUTHORITY><QUERE>?user=XXX&amp;pass=XXXXXX</QUERE></root>";
//            string expectedResponseBody = @"<root><SCHEME>http</SCHEME><AUTHORITY>test.com</AUTHORITY><QUERE>?user=XXX&amp;pass=XXXXXX</QUERE></root>";

//            // arrange
//            HttpResult bookingcomHttpResultXML = new HttpResult
//            {
//                Url = @"<root>
//                        <SCHEME>http</SCHEME>
//                        <AUTHORITY>test.com</AUTHORITY>
//                        <PATH>users/max/info</PATH>
//                        <QUERE>?pass=123456</QUERE>
//                    </root>",

//                RequestBody = @"<root>
//                                <SCHEME>http</SCHEME>
//                                <AUTHORITY>test.com</AUTHORITY>
//                                <QUERE>?user=max&amp;pass=123456</QUERE>
//                            </root>",

//                ResponseBody = @"<root>
//                                <SCHEME>http</SCHEME>
//                                <AUTHORITY>test.com</AUTHORITY>
//                                <QUERE>?user=max&amp;pass=123456</QUERE>
//                            </root>"

//            };

//            // act
//            TravelLineHttpHandler.ClearingHttp clearedHttp = new TravelLineHttpHandler.ClearingHttp();
//            HttpResult actualHttpResult = clearedHttp.Process(bookingcomHttpResultXML.Url,
//                                                                bookingcomHttpResultXML.RequestBody,
//                                                                bookingcomHttpResultXML.ResponseBody);

//            // assert
//            Assert.AreEqual(expectedUrl, actualHttpResult.Url);
//            Assert.AreEqual(expectedRequestBody, actualHttpResult.RequestBody);
//            Assert.AreEqual(expectedResponseBody, actualHttpResult.ResponseBody);
//        }

//        [TestMethod()]
//        public void ClearingHttp_Process_ExpectedJSONResult_ClearSecureData()
//        {
//            string expectedUrl = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",""PATH"":""users/XXX/info"",""QUERE"":""?pass=XXXXXX""}";
//            string expectedRequestBody = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",""QUERE"":""?user=XXX&pass=XXXXXX""}";
//            string expectedResponseBody = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",""QUERE"":""?user=XXX&pass=XXXXXX""}";

//            // arrange
//            HttpResult bookingcomHttpResultJSON = new HttpResult
//            {
//                Url = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",
//                                   ""PATH"": ""users/max/info"",
//                                  ""QUERE"": ""?pass=123456""}",

//                RequestBody = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",
//                                  ""QUERE"": ""?user=max&pass=123456""}",

//                ResponseBody = @"{""SCHEME"":""http"",""AUTHORITY"":""test.com"",
//                                  ""QUERE"": ""?user=max&pass=123456""}"
//        };

//            // act
//            TravelLineHttpHandler.ClearingHttp clearedHttp = new TravelLineHttpHandler.ClearingHttp();
//            HttpResult actualHttpResult = clearedHttp.Process(bookingcomHttpResultJSON.Url,
//                                                                bookingcomHttpResultJSON.RequestBody,
//                                                                bookingcomHttpResultJSON.ResponseBody);
//            // assert
//            Assert.AreEqual(expectedUrl, actualHttpResult.Url);
//            Assert.AreEqual(expectedRequestBody, actualHttpResult.RequestBody);
//            Assert.AreEqual(expectedResponseBody, actualHttpResult.ResponseBody);
//        }
//    }
//}