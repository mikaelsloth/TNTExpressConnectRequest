namespace TNTExpressConnectRequest.Tests
{
    using Xunit;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using TNTExpressConnectRequest;

    public class ExpressConnectShippingTests
    {
        private readonly ExpressConnectShippingSchema schemahelper;
        private static readonly Dictionary<string, string> accessKeys = new();

        private static string AssertRequest(XDocument result)
        {
            string? created = result.Element("AccessKey")?.Value;
            if (string.IsNullOrEmpty(created))
            {
                created = result.Element("runtime_error")?.Value;

                Assert.NotNull(created);
                return string.Empty;
            }

            Assert.True(!string.IsNullOrEmpty(created) && (created.Length >= 6 & created.Length <= 10));
            return created!;
        }

        private static ExpressConnectShippingRequest SetupResponseTest(string dictionarykey, out string accesskey)
        {
            string? testvalue = accessKeys.GetValueOrDefault(dictionarykey);
            Assert.False(testvalue == null, "Did not retrieve the key from the dictionary");
            accesskey = testvalue!;
            return new();
        }

        public ExpressConnectShippingTests()
        {
            schemahelper = ExpressConnectShippingSchema.Instance;
        }

        [Fact]
        public async Task A210_GetResultAsync_Success()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = await request.GetResultAsync(testvalue);
            XElement? create = result.Root?.Element("CREATE");
            Assert.NotNull(create);
            XElement? success = create.Element("SUCCESS");
            Assert.NotNull(success);
            string created = success.Value;

            Assert.Equal("Y", created);
        }

        [Fact]
        public async Task A220_GetResultAsync_RuntimeWarning()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeDataValidationErrorRequest), out string testvalue);

            XDocument result = await request.GetResultAsync(testvalue);
            XElement? created = result.Root?.Element("ERROR");
            created ??= result.Element("runtime_error");

            Assert.NotNull(created);
        }

        [Fact]
        public async Task A230_GetResultAsync_InvalidCredentials()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeInvalidCredentialsRequest), out string testvalue);

            XDocument result = await request.GetResultAsync(testvalue);
            XElement? created = result.Element("ERROR");

            Assert.NotNull(created);
        }

        [Fact]
        public async Task A240_GetResultAsync_ErrorFormat()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeInvalidFormatRequest), out string testvalue);

            XDocument result = await request.GetResultAsync(testvalue);
            XElement? created = result.Element("parse_error");

            Assert.NotNull(created);
        }

        [Fact]
        public void A211_GetResult_Success()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = request.GetResult(testvalue);
            XElement? create = result.Root?.Element("CREATE");
            Assert.NotNull(create);
            XElement? success = create.Element("SUCCESS");
            Assert.NotNull(success);
            string created = success.Value;

            Assert.Equal("Y", created);
        }

        [Fact]
        public void A221_GetResult_RuntimeWarning()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeDataValidationErrorRequest), out string testvalue);

            XDocument result = request.GetResult(testvalue);
            XElement? created = result.Root?.Element("ERROR");
            created ??= result.Element("runtime_error");

            Assert.NotNull(created);
        }

        [Fact]
        public void A231_GetResult_InvalidCredentials()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeInvalidCredentialsRequest), out string testvalue);

            XDocument result = request.GetResult(testvalue);
            XElement? created = result.Element("ERROR");

            Assert.NotNull(created);
        }

        [Fact]
        public void A241_GetResult_ErrorFormat()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeInvalidFormatRequest), out string testvalue);

            XDocument result = request.GetResult(testvalue);
            XElement? created = result.Element("parse_error");

            Assert.NotNull(created);
        }

        [Fact]
        public void A212_GetManifest_Success()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = request.GetManifest(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A222_GetManifest_Failure(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);
            if (testvalue == string.Empty)
            {
                return;
            }

            _ = Assert.ThrowsAny<HttpRequestException>(() => request.GetManifest(testvalue));
        }

        [Fact]
        public async Task A213_GetManifestAsync_Success()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = await request.GetManifestAsync(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public async Task A223_GetManifestAsync_Failure(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);
            if (testvalue == string.Empty)
            {
                return;
            }

            _ = await Assert.ThrowsAnyAsync<HttpRequestException>(async () => await request.GetManifestAsync(testvalue));
        }

        [Fact]
        public void A214_GetInvoice_Success()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = request.GetInvoice(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A224_GetInvoice_Failure(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);
            if (testvalue == string.Empty)
            {
                return;
            }

            _ = Assert.ThrowsAny<HttpRequestException>(() => request.GetInvoice(testvalue));
        }

        [Fact]
        public async Task A215_GetInvoiceAsync_Success()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = await request.GetInvoiceAsync(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public async Task A225_GetInvoiceAsync_Failure(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);
            if (testvalue == string.Empty)
            {
                return;
            }

            _ = await Assert.ThrowsAnyAsync<HttpRequestException>(async () => await request.GetInvoiceAsync(testvalue));
        }

        [Fact]
        public void A216_GetConnote_Success()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = request.GetConnote(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A226_GetConnote_Failure(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);
            if (testvalue == string.Empty)
            {
                return;
            }

            _ = Assert.ThrowsAny<HttpRequestException>(() => request.GetConnote(testvalue));
        }

        [Fact]
        public async Task A217_GetConnoteAsync_Success()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = await request.GetConnoteAsync(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public async Task A227_GetConnoteAsync_Failure(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);
            if (testvalue == string.Empty)
            {
                return;
            }

            _ = await Assert.ThrowsAnyAsync<HttpRequestException>(async () => await request.GetConnoteAsync(testvalue));
        }

        [Theory]
        [ClassData(typeof(ExpressConnectShippingTestRequestsForLookup))]
        public async Task A01_SubmitShippingRequestAsync_XDocument(string input, string nameoftest)
        {
            ExpressConnectShippingRequest request = new();

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input));

            string created = AssertRequest(result);
            accessKeys.Add(nameoftest, created!);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public void A02_SubmitRequest_XDocument(string input)
        {
            ExpressConnectShippingRequest request = new();

            XDocument result = request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(input));

            _ = AssertRequest(result);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public void B01_SubmitRequest_String(string input)
        {
            ExpressConnectShippingRequest request = new();

            XDocument result = request.SubmitRequest(input);

            _ = AssertRequest(result);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public async Task B02_SubmitRequestAsync_String(string input)
        {
            ExpressConnectShippingRequest request = new();

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input));

            _ = AssertRequest(result);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public async Task A03_ValidateAndSubmitShippingRequestAsync_XDocument(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input), schemahelper.FakeRequestSchema!);

            _ = AssertRequest(result);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public void A04_ValidateAndSubmitRequest_XDocument(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            XDocument result = request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(input), schemahelper.FakeRequestSchema!);

            _ = AssertRequest(result);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public void B03_ValidateAndSubmitRequest_String(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            XDocument result = request.SubmitRequest(input, schemahelper.FakeRequestSchema!);

            _ = AssertRequest(result);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public async Task B04_ValidateAndSubmitRequestAsync_String(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input), schemahelper.FakeRequestSchema!);

            _ = AssertRequest(result);
        }
    }
}