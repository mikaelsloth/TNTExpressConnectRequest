namespace TNTExpressConnectRequest.Tests
{
    public class ExpressConnectShippingTestRequestsError : ExpressConnectShippingTestRequests
    {
        public ExpressConnectShippingTestRequestsError() : base()
        {
            TestRequests.RemoveAt(0);
            TestRequests.RemoveAt(0);
            TestRequests.RemoveAt(0);
        }
    }
}
