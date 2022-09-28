namespace TNTExpressConnectRequest.Tests
{
    using System.Collections.Generic;

    public class ExpressConnectShippingTestRequestsForLookup : ExpressConnectShippingTestRequests
    {
        public ExpressConnectShippingTestRequestsForLookup() : base()
        {
            TestShippingRequests = new List<object[]>()
        {
            new object[] { FakeSuccessfullRequest(), nameof(FakeSuccessfullRequest) },
            new object[] { FakeDataValidationErrorRequest(), nameof(FakeDataValidationErrorRequest) },
            new object[] { FakeInvalidCredentialsRequest(), nameof(FakeInvalidCredentialsRequest) },
            new object[] { FakeInvalidFormatRequest(), nameof(FakeInvalidFormatRequest) }
        };
        }

        private readonly List<object[]> TestShippingRequests;

        public override IEnumerator<object[]> GetEnumerator() => TestShippingRequests.GetEnumerator();

    }
}
