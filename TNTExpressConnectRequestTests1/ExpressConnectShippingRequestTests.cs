namespace TNTExpressConnectRequest.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using TNTExpressConnectRequest;

    [TestClass()]
    public class ExpressConnectShippingRequestTests
    {
        [TestMethod()]
        public void GetResultTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetResultAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetManifestTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetManifestAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetInvoiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetInvoiceAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetConnoteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetConnoteAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SubmitRequestAsyncTest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public async Task S1_SubmitRequestAsyncTest_XDocument_Success()
        {
            ExpressConnectShippingRequest request = new();
            XDocument xml = XDocument.Parse(ExpressConnectShippingRequestHelper.FakeSuccessfullRequest(ExpressConnectCredentials.Username, ExpressConnectCredentials.Password, ExpressConnectCredentials.Account));

            XDocument result = await request.SubmitRequestAsync(xml);

            _ = result.Element("CREATE");
        }

        [TestMethod()]
        public void SubmitRequestTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SubmitRequestTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SubmitRequestAsyncTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SubmitRequestAsyncTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SubmitRequestTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SubmitRequestTest3()
        {
            Assert.Fail();
        }
    }
}