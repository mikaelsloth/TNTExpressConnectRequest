namespace TNTExpressConnectRequest.Tests
{
    using Xunit;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using TNTExpressConnectRequest;
    using System;

    [TestCaseOrderer("TNTExpressConnectRequest.Tests.ExpressConnectShippingTestsOrdering", "TNTExpressConnectRequest")]
    public class ExpressConnectShippingTests
    {
        private readonly ExpressConnectShippingSchema schemahelper;
        private static readonly Dictionary<string, string> accessKeys = new();

        private static string AssertAccessKeyOrRuntimeError(XDocument result)
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
            Type t = typeof(ExpressConnectShippingTestsOrdering);
            string? test = t.AssemblyQualifiedName;
        }

        [Fact, Priority(2)]
        public void A01a_CheckDictionary_4EntriesExpected()
        {
            Assert.Equal(4, accessKeys.Count);
        }

        [Fact, Priority(1)]
        public async Task A210_GetResultAsync_SuccessExpected()
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
        [Priority(1)]
        public async Task A220_GetResultAsync_RuntimeWarningExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeDataValidationErrorRequest), out string testvalue);

            XDocument result = await request.GetResultAsync(testvalue);
            XElement? created = result.Root?.Element("ERROR");
            created ??= result.Element("runtime_error");

            Assert.NotNull(created);
        }

        [Fact]
        [Priority(1)]
        public void A230_GetResultAsync_InvalidCredentials_NoAccessKeyExpected()
        {
            _  = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeInvalidCredentialsRequest), out string testvalue);
            Assert.Equal(string.Empty, testvalue);
        }

        [Fact]
        [Priority(1)]
        public async Task A240_GetResultAsync_ParseErrorExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeInvalidFormatRequest), out string testvalue);

            XDocument result = await request.GetResultAsync(testvalue);
            XElement? created = result.Element("parse_error");

            Assert.NotNull(created);
        }

        [Fact]
        [Priority(1)]
        public void A211_GetResult_SuccessExpected()
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
        [Priority(1)]
        public void A221_GetResult_RuntimeWarningExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeDataValidationErrorRequest), out string testvalue);

            XDocument result = request.GetResult(testvalue);
            XElement? created = result.Root?.Element("ERROR");
            created ??= result.Element("runtime_error");

            Assert.NotNull(created);
        }

        [Fact]
        [Priority(1)]
        public void A231_GetResult_InvalidCredentials_NoAccessKeyExpected()
        {
            _ = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeInvalidCredentialsRequest), out string testvalue);
            Assert.Equal(string.Empty, testvalue);
        }

        [Fact]
        [Priority(1)]
        public void A241_GetResult_ParseErrorExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeInvalidFormatRequest), out string testvalue);

            XDocument result = request.GetResult(testvalue);
            XElement? created = result.Element("parse_error");

            Assert.NotNull(created);
        }

        [Fact]
        [Priority(1)]
        public void A212_GetManifest_SuccessExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = request.GetManifest(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A222_GetManifest_Http500Expected(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);

            HttpRequestException ex = Assert.ThrowsAny<HttpRequestException>(() => request.GetManifest(testvalue));
            Assert.Equal(System.Net.HttpStatusCode.InternalServerError, ex.StatusCode);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetInvalidCredentialsRequest), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A222a_GetManifest_NoAccessKeyExpected(string input)
        {
            _ = SetupResponseTest(input, out string testvalue);
            Assert.Equal(string.Empty, testvalue);
        }

        [Fact]
        [Priority(1)]
        public async Task A213_GetManifestAsync_SuccessExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = await request.GetManifestAsync(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetInvalidCredentialsRequest), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A223_GetManifestAsync_NoAccessKeyExpected(string input)
        {
            _ = SetupResponseTest(input, out string testvalue);
            Assert.Equal(string.Empty, testvalue);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public async Task A223a_GetManifestAsync_Http500Expected(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);

            HttpRequestException ex = await Assert.ThrowsAnyAsync<HttpRequestException>(async () => await request.GetManifestAsync(testvalue));
            Assert.Equal(System.Net.HttpStatusCode.InternalServerError, ex.StatusCode);
        }

        [Fact]
        [Priority(1)]
        public void A214_GetInvoice_SuccessExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = request.GetInvoice(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A224_GetInvoice_Http500Expected(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);

            HttpRequestException ex = Assert.ThrowsAny<HttpRequestException>(() => request.GetInvoice(testvalue));
            Assert.Equal(System.Net.HttpStatusCode.InternalServerError, ex.StatusCode);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetInvalidCredentialsRequest), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A224a_GetInvoice_NoAccessKeyExpected(string input)
        {
            _ = SetupResponseTest(input, out string testvalue);
            Assert.Equal(string.Empty, testvalue);
        }

        [Fact]
        [Priority(1)]
        public async Task A215_GetInvoiceAsync_SuccessExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = await request.GetInvoiceAsync(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public async Task A225_GetInvoiceAsync_Http500Expected(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);

            HttpRequestException ex = await Assert.ThrowsAnyAsync<HttpRequestException>(async () => await request.GetInvoiceAsync(testvalue));
            Assert.Equal(System.Net.HttpStatusCode.InternalServerError, ex.StatusCode);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetInvalidCredentialsRequest), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A225a_GetInvoiceAsync_NoAccessKeyExpected(string input)
        {
            _ = SetupResponseTest(input, out string testvalue);
            Assert.Equal(string.Empty, testvalue);
        }

        [Fact]
        [Priority(1)]
        public void A216_GetConnote_SuccessExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = request.GetConnote(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A226_GetConnote_Http500Expected(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);

            HttpRequestException ex = Assert.ThrowsAny<HttpRequestException>(() => request.GetConnote(testvalue));
            Assert.Equal(System.Net.HttpStatusCode.InternalServerError, ex.StatusCode);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetInvalidCredentialsRequest), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A226a_GetConnote_NoAccessKeyExpected(string input)
        {
            _ = SetupResponseTest(input, out string testvalue);
            Assert.Equal(string.Empty, testvalue);
        }

        [Fact]
        [Priority(1)]
        public async Task A217_GetConnoteAsync_SuccessExpected()
        {
            ExpressConnectShippingRequest request = SetupResponseTest(nameof(ExpressConnectShippingTestRequests.FakeSuccessfullRequest), out string testvalue);

            XDocument result = await request.GetConnoteAsync(testvalue);

            Assert.NotNull(result);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetFailingRequests), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public async Task A227_GetConnoteAsync_Http500Expected(string input)
        {
            ExpressConnectShippingRequest request = SetupResponseTest(input, out string testvalue);

            HttpRequestException ex = await Assert.ThrowsAnyAsync<HttpRequestException>(async () => await request.GetConnoteAsync(testvalue));
            Assert.Equal(System.Net.HttpStatusCode.InternalServerError, ex.StatusCode);
        }

        [Theory]
        [Priority(1)]
        [MemberData(nameof(ExpressConnectShippingTestRequests.GetInvalidCredentialsRequest), MemberType = typeof(ExpressConnectShippingTestRequests))]
        public void A227a_GetConnoteAsync_NoAccessKeyExpected(string input)
        {
            _ = SetupResponseTest(input, out string testvalue);
            Assert.Equal(string.Empty, testvalue);
        }

        [Theory]
        [Priority(4)]
        [ClassData(typeof(ExpressConnectShippingTestRequestsForLookup))]
        public async Task A01_SubmitShippingRequestAsync_XDocumentInput_AccessKeyOrRuntimeErrorExpected(string input, string nameoftest)
        {
            ExpressConnectShippingRequest request = new();

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input));

            string created = AssertAccessKeyOrRuntimeError(result);
            accessKeys.Add(nameoftest, created!);
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public void A02_SubmitRequest_XDocumentInput_AccessKeyOrRuntimeErrorExpected(string input)
        {
            ExpressConnectShippingRequest request = new();

            XDocument result = request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(input));

            _ = AssertAccessKeyOrRuntimeError(result);
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public void B01_SubmitRequest_StringInput_AccessKeyOrRuntimeErrorExpected(string input)
        {
            ExpressConnectShippingRequest request = new();

            XDocument result = request.SubmitRequest(input);

            _ = AssertAccessKeyOrRuntimeError(result);
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequests))]
        public async Task B02_SubmitRequestAsync_StringInput_AccessKeyOrRuntimeErrorExpected(string input)
        {
            ExpressConnectShippingRequest request = new();

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input));

            _ = AssertAccessKeyOrRuntimeError(result);
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequestsNoError))]
        public async Task A03_ValidateAndSubmitShippingRequestAsync_XDocumentInput_AccessKeyOrRuntimeErrorExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input), schemahelper.FakeRequestSchema!);

            _ = AssertAccessKeyOrRuntimeError(result);
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequestsError))]
        public async Task A03a_ValidateAndSubmitShippingRequestAsync_XDocumentInput_InvalidArgumentExceptionExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            _ = await Assert.ThrowsAnyAsync<ArgumentException>(async () => await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input), schemahelper.FakeRequestSchema!));
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequestsNoError))]
        public void A04_ValidateAndSubmitRequest_XDocumentInput_AccessKeyOrRuntimeErrorExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            XDocument result = request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(input), schemahelper.FakeRequestSchema!);

            _ = AssertAccessKeyOrRuntimeError(result);
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequestsError))]
        public void A04a_ValidateAndSubmitRequest_XDocumentInput_InvalidArgumentExceptionExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            _ = Assert.ThrowsAny<ArgumentException>(() => request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(input), schemahelper.FakeRequestSchema!));
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequestsNoError))]
        public void B03_ValidateAndSubmitRequest_StringInput_AccessKeyOrRuntimeErrorExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            XDocument result = request.SubmitRequest(input, schemahelper.FakeRequestSchema!);

            _ = AssertAccessKeyOrRuntimeError(result);
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequestsError))]
        public void B03a_ValidateAndSubmitRequest_StringInput_InvalidArgumentExceptionExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            _ = Assert.ThrowsAny<ArgumentException>(() => request.SubmitRequest(input, schemahelper.FakeRequestSchema!));
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequestsNoError))]
        public async Task B04_ValidateAndSubmitRequestAsync_StringInput_AccessKeyOrRuntimeErrorExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            XDocument result = await request.SubmitRequestAsync(input, schemahelper.FakeRequestSchema!);

            _ = AssertAccessKeyOrRuntimeError(result);
        }

        [Theory]
        [Priority(3)]
        [ClassData(typeof(ExpressConnectShippingTestRequestsError))]
        public async Task B04a_ValidateAndSubmitRequestAsync_StringInput_InvalidArgumentExceptionExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressConnectShippingRequest request = new();

            _ = await Assert.ThrowsAnyAsync<ArgumentException>(async () => await request.SubmitRequestAsync(input, schemahelper.FakeRequestSchema!));
        }
    }
}