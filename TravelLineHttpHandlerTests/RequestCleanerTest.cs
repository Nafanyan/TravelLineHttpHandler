using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelLineHttpHandler.Interfaces;
using TravelLineHttpHandler.ConcreteFactories;

namespace TravelLineHttpHandler.Tests
{
    [TestClass()]
    public class RequestCleanerTest
    {

        [TestMethod()]
        public void RequestCleaner_ClearRequest_HttpResultURLWeb_ClearSecureData()
        {
            // arrange
            string url = "http://test.com/users/max/info?pass=123456";

            // act
            ICleanerFactory cleanerFactory = new CleanerFactory();
            RequestCleaner requestCleaner = new RequestCleaner(cleanerFactory);
            string httpResultURLWeb = requestCleaner.ClearRequest(url, new string[] { "user", "pass" });

            // assert
            Assert.AreEqual("http://test.com/users/XXX/info?pass=XXXXXX", httpResultURLWeb);
        }

        [TestMethod()]
        public void RequestCleaner_ClearRequestClear_HttpResultRequestWeb_ClearSecureData()
        {
            // arrange
            string requestBody = "http://test.com?user=max&pass=123456";

            // act
            ICleanerFactory cleanerFactory = new CleanerFactory();
            RequestCleaner requestCleaner = new RequestCleaner(cleanerFactory);
            string httpResultRequestWeb = requestCleaner.ClearRequest(requestBody, new string[] { "user", "pass" });

            // assert
            Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", httpResultRequestWeb);
        }

        [TestMethod()]
        public void RequestCleaner_ClearRequest_HttpResultResponseWeb_ClearSecureData()
        {
            // arrange
            string responseBody = "http://test.com?user=max&pass=123456";

            // act
            ICleanerFactory cleanerFactory = new CleanerFactory();
            RequestCleaner requestCleaner = new RequestCleaner(cleanerFactory);
            string httpResultResponseWeb = requestCleaner.ClearRequest(responseBody, new string[] { "user", "pass" });

            // assert
            Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", httpResultResponseWeb);
        }

        [TestMethod()]
        public void RequestCleaner_ClearRequest_HttpResultXML_ClearSecureData()
        {
            // arrange
            string xmlString = @"<root>
                        <user_data>
                            <username>max</username>
                            <password>123456</password>
                        </user_data>
                    </root>";
            string expectedXML = @"<root><user_data><username>XXX</username><password>XXXXXX</password></user_data></root>";
            // act
            ICleanerFactory cleanerFactory = new CleanerFactory();
            RequestCleaner requestCleaner = new RequestCleaner(cleanerFactory);
            string httpResultXML = requestCleaner.ClearRequest(xmlString, new string[] { "username", "password" });

            // assert
            Assert.AreEqual(expectedXML, httpResultXML);
        }

        [TestMethod()]
        public void RequestCleaner_ClearRequest_HttpResultJSON_ClearSecureData()
        {
            // arrange
            string jsonString = @"{ ""scheme"":""http"",
                                    ""authority"":""test.com"",
                                    ""user_data"": 
                                    {
                                    ""username"":""max"",
                                    ""password"":""123456""
                                    }
                                }";

            string expectedJSON = @"{""scheme"":""http"",""authority"":""test.com"",""user_data"":{""username"":""XXX"",""password"":""XXXXXX""}}";

            // act
            ICleanerFactory cleanerFactory = new CleanerFactory();
            RequestCleaner requestCleaner = new RequestCleaner(cleanerFactory);
            string httpResultJSON = requestCleaner.ClearRequest(jsonString, new string[] { "user_data.username", "user_data.password" });

            // assert
            Assert.AreEqual(expectedJSON, httpResultJSON);
        }
    }
}