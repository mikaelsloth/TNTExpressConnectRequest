namespace TNTExpressConnectRequest.Tests
{
    public class ExpressConnectShippingTestRequestsNoError : ExpressConnectShippingTestRequests
    {
        public ExpressConnectShippingTestRequestsNoError() : base()
        {
            TestRequests.RemoveAt(3);
        }
    }
}
