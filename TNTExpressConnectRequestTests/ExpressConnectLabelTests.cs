namespace TNTExpressConnectRequest.Tests
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using TNTExpressConnectRequest;
    using Xunit;

    public class ExpressConnectLabelTests
    {
        private readonly ExpressConnectLabelSchema schemahelper;
        private readonly ExpressConnectCredentials credentials;
        private readonly ExpressConnectLabelTestRequests requestCollection = new();

        private ExpressLabelRequest CreateRequest(bool useinvalidcredentials = false) => new()
        {
            CustomerId = useinvalidcredentials ? credentials.Username + "_ZZZ" : credentials.Username,
            Password = useinvalidcredentials ? credentials.Password + "_ZZZ" : credentials.Password,
        };
        
        private static void AssertRequest(XDocument result)
        {
            XElement? created = result.Element("labelResponse");
            Assert.NotNull(created);

            XElement? response = created?.Element("consignment");
            response ??= created?.Element("brokenRules");
            Assert.NotNull(response);
        }

        public ExpressConnectLabelTests()
        {
            credentials = ExpressConnectCredentials.Instance;
            schemahelper = ExpressConnectLabelSchema.Instance;
        }

        [Theory]
        [ClassData(typeof(ExpressConnectLabelTestRequests))]
        public async Task A01_SubmitLabelRequestAsync_XDocumentInput_XDocumentResponseExpected(string input)
        {
            ExpressLabelRequest request = CreateRequest();

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input));

            AssertRequest(result);
        }

        [Fact]
        public async Task A01a_SubmitLabelRequestAsync_XDocumentInput_XDocumentResponseExpected()
        {
            ExpressLabelRequest request = CreateRequest(true);

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(requestCollection.FakeInvalidCredentialsRequest()));

            AssertRequest(result);
        }

        [Fact]
        public async Task A01b_SubmitLabelRequestAsync_XDocumentInput_Http406ResponseExpected()
        {
            ExpressLabelRequest request = CreateRequest(true);

            HttpRequestException ex = await Assert.ThrowsAnyAsync<HttpRequestException>(async () => await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(requestCollection.FakeInvalidFormatRequest())));
            Assert.Equal(System.Net.HttpStatusCode.NotAcceptable, ex.StatusCode);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectLabelTestRequests))]
        public void A02_SubmitLabelRequest_XDocumentInput_XDocumentResponseExpected(string input)
        {
            ExpressLabelRequest request = CreateRequest();

            XDocument result = request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(input));

            AssertRequest(result);
        }

        [Fact]
        public void A02a_SubmitLabelRequest_XDocumentInput_XDocumentResponseExpected()
        {
            ExpressLabelRequest request = CreateRequest(true);

            XDocument result = request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(requestCollection.FakeInvalidCredentialsRequest()));

            AssertRequest(result);
        }

        [Fact]
        public void A02b_SubmitLabelRequest_XDocumentInput_Http406ResponseExpected()
        {
            ExpressLabelRequest request = CreateRequest();

            HttpRequestException ex = Assert.ThrowsAny<HttpRequestException>(() => request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(requestCollection.FakeInvalidFormatRequest())));
            Assert.Equal(System.Net.HttpStatusCode.NotAcceptable, ex.StatusCode);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectLabelTestRequests))]
        public void B01_SubmitLabelRequest_StringInput_XDocumentResponseExpected(string input)
        {
            ExpressLabelRequest request = CreateRequest();

            XDocument result = request.SubmitRequest(input);

            AssertRequest(result);
        }

        [Fact]
        public void B01a_SubmitLabelRequest_StringInput_XDocumentResponseExpected()
        {
            ExpressLabelRequest request = CreateRequest(true);

            XDocument result = request.SubmitRequest(requestCollection.FakeInvalidCredentialsRequest());

            AssertRequest(result);
        }

        [Fact]
        public void B01b_SubmitLabelRequest_StringInput_Http406ResponseExpected()
        {
            ExpressLabelRequest request = CreateRequest();

            HttpRequestException ex = Assert.ThrowsAny<HttpRequestException>(() => request.SubmitRequest(requestCollection.FakeInvalidFormatRequest()));
            Assert.Equal(System.Net.HttpStatusCode.NotAcceptable, ex.StatusCode);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectLabelTestRequests))]
        public async Task B02_SubmitLabelRequestAsync_StringInput_XDocumentResponseExpected(string input)
        {
            ExpressLabelRequest request = CreateRequest();

            XDocument result = await request.SubmitRequestAsync(input);

            AssertRequest(result);
        }

        [Fact]
        public async Task B02a_SubmitLabelRequestAsync_StringInput_XDocumentResponseExpected()
        {
            ExpressLabelRequest request = CreateRequest(true);

            XDocument result = await request.SubmitRequestAsync(requestCollection.FakeInvalidCredentialsRequest());

            AssertRequest(result);
        }

        [Fact]
        public async Task B02b_SubmitLabelRequestAsync_StringInput_Http406ResponseExpected()
        {
            ExpressLabelRequest request = CreateRequest();

            HttpRequestException ex = await Assert.ThrowsAnyAsync<HttpRequestException>(async () => await request.SubmitRequestAsync(requestCollection.FakeInvalidFormatRequest()));
            Assert.Equal(System.Net.HttpStatusCode.NotAcceptable, ex.StatusCode);
        }

        [Theory]
        [ClassData(typeof(ExpressConnectLabelTestRequests))]
        public async Task A03_ValidateAndSubmitLabelRequestAsync_XDocumentInput_XDocumentResponseExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest();

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(input), schemahelper.FakeRequestSchema!);

            AssertRequest(result);
        }

        [Fact]
        public async Task A03a_ValidateAndSubmitLabelRequestAsync_XDocumentInput_XDocumentResponseExpected()
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest(true);

            XDocument result = await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(requestCollection.FakeInvalidCredentialsRequest()), schemahelper.FakeRequestSchema!);

            AssertRequest(result);
        }

        [Fact]
        public async Task A03b_ValidateAndSubmitLabelRequestAsync_XDocumentInput_ArgumentExceptionResponseExpected()
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest();

            _ = await Assert.ThrowsAnyAsync<ArgumentException>(async () => await request.SubmitRequestAsync(ExpressConnectTestRequests.ConvertStringToXDocument(requestCollection.FakeInvalidFormatRequest()), schemahelper.FakeRequestSchema!));
        }

        [Theory]
        [ClassData(typeof(ExpressConnectLabelTestRequests))]
        public void A04_ValidateAndSubmitRequest_XDocumentInput_XDocumentResponseExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest();

            XDocument result = request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(input), schemahelper.FakeRequestSchema!);

            AssertRequest(result);
        }

        [Fact]
        public void A04a_ValidateAndSubmitRequest_XDocumentInput_XDocumentResponseExpected()
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest(true);

            XDocument result = request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(requestCollection.FakeInvalidCredentialsRequest()), schemahelper.FakeRequestSchema!);

            AssertRequest(result);
        }

        [Fact]
        public void A04b_ValidateAndSubmitRequest_XDocumentInput_ArgumentExceptionResponseExpected()
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest();

            _ = Assert.ThrowsAny<ArgumentException>(() => request.SubmitRequest(ExpressConnectTestRequests.ConvertStringToXDocument(requestCollection.FakeInvalidFormatRequest()), schemahelper.FakeRequestSchema!));
        }

        [Theory]
        [ClassData(typeof(ExpressConnectLabelTestRequests))]
        public void B03_ValidateAndSubmitRequest_StringInput_XDocumentResponseExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest();

            XDocument result = request.SubmitRequest(input, schemahelper.FakeRequestSchema!);

            AssertRequest(result);
        }

        [Fact]
        public void B03a_ValidateAndSubmitRequest_StringInput_XDocumentResponseExpected()
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest(true);

            XDocument result = request.SubmitRequest(requestCollection.FakeInvalidCredentialsRequest(), schemahelper.FakeRequestSchema!);

            AssertRequest(result);
        }

        [Fact]
        public void B03b_ValidateAndSubmitRequest_StringInput_ArgumentExceptionResponseExpected()
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest();

            _ = Assert.ThrowsAny<ArgumentException>(() => request.SubmitRequest(requestCollection.FakeInvalidFormatRequest(), schemahelper.FakeRequestSchema!));
        }

        [Theory]
        [ClassData(typeof(ExpressConnectLabelTestRequests))]
        public async Task B04_ValidateAndSubmitRequestAsync_StringInput_XDocumentResponseExpected(string input)
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest();

            XDocument result = await request.SubmitRequestAsync(input, schemahelper.FakeRequestSchema!);

            AssertRequest(result);
        }

        [Fact]
        public async Task B04a_ValidateAndSubmitRequestAsync_StringInput_XDocumentResponseExpected()
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest();

            XDocument result = await request.SubmitRequestAsync(requestCollection.FakeInvalidCredentialsRequest(), schemahelper.FakeRequestSchema!);

            AssertRequest(result);
        }

        [Fact]
        public async Task B04b_ValidateAndSubmitRequestAsync_StringInput_ArgumentExceptionResponseExpected()
        {
            Assert.NotNull(schemahelper.FakeRequestSchema);
            ExpressLabelRequest request = CreateRequest();

            _ = await Assert.ThrowsAnyAsync<ArgumentException>(async () => await request.SubmitRequestAsync(requestCollection.FakeInvalidFormatRequest(), schemahelper.FakeRequestSchema!));
        }
    }
}
