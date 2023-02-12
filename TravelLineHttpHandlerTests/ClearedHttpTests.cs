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
    public class ClearedHttpTests
    {

        [TestMethod()]
        public void ClearedHttpTests_SecureDataClearTest_HttpResultURLWeb_ClearSecureData()
        {
            // arrange
            string Url = "http://test.com/users/max/info?pass=123456";

            // act
            ClearedHttp app = new ClearedHttp();
            string HttpResultURLWeb = app.SecureDataClear(Url, new string[] { "user", "pass" });

            // assert
            Assert.AreEqual("http://test.com/users/XXX/info?pass=XXXXXX", HttpResultURLWeb);
        }

        [TestMethod()]
        public void ClearedHttpTests_SecureDataClearTest_HttpResultRequestWeb_ClearSecureData()
        {
            // arrange
            string RequestBody = "http://test.com?user=max&pass=123456";

            // act
            ClearedHttp app = new ClearedHttp();
            string HttpResultRequestWeb = app.SecureDataClear(RequestBody, new string[] { "user", "pass" });

            // assert
            Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", HttpResultRequestWeb);
        }

        [TestMethod()]
        public void ClearedHttpTests_SecureDataClearTest_HttpResultResponseWeb_ClearSecureData()
        {
            // arrange
            string ResponseBody = "http://test.com?user=max&pass=123456";

            // act
            ClearedHttp app = new ClearedHttp();
            string HttpResultResponseWeb = app.SecureDataClear(ResponseBody, new string[] { "user", "pass" });

            // assert
            Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", HttpResultResponseWeb);
        }

        [TestMethod()]
        public void ClearedHttpTests_SecureDataClearTest_HttpResultXML_ClearSecureData()
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
            ClearedHttp app = new ClearedHttp();
            string HttpResultXML = app.SecureDataClear(xmlString, new string[] { "username", "password" });

            // assert
            Assert.AreEqual(expectedXML, HttpResultXML);
        }

        [TestMethod()]
        public void ClearedHttpTests_SecureDataClearTest_HttpResultJSON_ClearSecureData()
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
            ClearedHttp app = new ClearedHttp();
            string HttpResultJSON = app.SecureDataClear(jsonString, new string[] { "user_data.username", "user_data.password" });

            // assert
            Assert.AreEqual(expectedJSON, HttpResultJSON);
        }
    }
}